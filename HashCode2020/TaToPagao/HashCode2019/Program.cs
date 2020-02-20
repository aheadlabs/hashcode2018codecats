using HashCode2019.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCode2019
{
    internal class Program
    {

        public static Settings Configuration { get; set; } = new Settings();

        private static FilesProvider _provider;

        #region Core Methods
        private static void Main(string[] args)
        {
            Setup(args);
            Init();
        }

        private static void Init()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"*** START PROCESSING FILES AT {System.DateTime.Now} ***");
            Console.WriteLine("");

            List<FileInfo> files = _provider.GetFiles();
            files.ForEach
            (f =>
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"File: {f.Name}");
                    ProcessFile(_provider.GetContentFile(f));
                }
            );

            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"**** ALL FILES PROCESSED AT {System.DateTime.Now}****");
            Console.ReadKey();
        }

        private static void Setup(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables("HashCode2019_")
            .AddCommandLine(args);

            builder.Build().Bind(nameof(Settings), Configuration);
            _provider = new FilesProvider(Configuration);
        }

        /// <summary>
        /// Processes every input file
        /// </summary>
        /// <param name="contentFile">
        ///     File content. Every element in the list represents a line in the file.
        ///     Line format is space separated numbers, thus an array of integers.
        ///     un array de integers.
        /// </param>
        private static void ProcessFile(List<Photo> contentFile)
        {
            // Create BASIC Slide Show
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Creating slideshows with {contentFile.Count} photos...");
            List<SimpleSlide> simpleSlideList = CreateSimpleSlideList(contentFile);
            int score = CalculateScore(simpleSlideList);
            Console.Write($" · Before processing... Contains {simpleSlideList.Count} elements with score: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(score);
            //_provider.SaveFileOutput(simpleSlideList);

            // STEP 1
            Console.ForegroundColor = ConsoleColor.DarkGray;
            List<SimpleSlide> enhancedSlideList = CreateEnhancedSlideList(simpleSlideList);
            Console.Write($" · STEP 1 --> Contains {enhancedSlideList.Count} elements with score: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            score = CalculateScore(enhancedSlideList);
            Console.WriteLine(score);
            //_provider.SaveFileOutput(enhancedSlideList);

            // STEP 2
            Console.ForegroundColor = ConsoleColor.DarkGray;
            List<SimpleSlide> enhancedSlideList2 = CreateEnhancedSlideList(enhancedSlideList);
            score = CalculateScore(enhancedSlideList2);
            Console.Write($" · STEP 2 --> Contains {enhancedSlideList2.Count} elements with score: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(score);
            //_provider.SaveFileOutput(enhancedSlideList2);

            // STEP 3
            Console.ForegroundColor = ConsoleColor.DarkGray;
            List<SimpleSlide> enhancedSlideList3 = CreateEnhancedSlideList(enhancedSlideList2);
            score = CalculateScore(enhancedSlideList3);
            Console.Write($" · STEP 3 --> Contains {enhancedSlideList3.Count} elements with score: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(score);
            _provider.SaveFileOutput(enhancedSlideList3);

            Console.WriteLine("");

          
        }


        #endregion

        #region CONTEST (Algorithm) Methods
        private static int CalculateScore(List<SimpleSlide> simpleSlides)
        {
            int score = 0;
            for (int i = 0; i < simpleSlides.Count - 1; i++)
            {
                var s1 = simpleSlides.ElementAt(i);
                var s2 = simpleSlides.ElementAt(i + 1);

                score += CalculateInterestFactor(s1, s2);
            }

            return score;
        }

        private static int CalculateInterestFactor(SimpleSlide slide1, SimpleSlide slide2)
        {
            var inA = new List<string>();
            var inB = new List<string>();
            var inCommon = new List<string>();
            var factors = new List<int>();

            // Interesection
            inCommon = slide1.Tags.Intersect(slide2.Tags).ToList();

            // In slide1, not in 2
            foreach (var tag in slide1.Tags)
            {
                if (!inCommon.Contains(tag))
                {
                    inA.Add(tag);
                }
            }

            // In slide2, not in 1
            foreach (var tag in slide2.Tags)
            {
                if (!inCommon.Contains(tag))
                {
                    inB.Add(tag);
                }
            }

            factors.Add(inA.Count);
            factors.Add(inB.Count);
            factors.Add(inCommon.Count);

            return factors.Min(f => f);
        }

        public static List<SimpleSlide> CreateSimpleSlideList(List<Photo> photos)
        {
            var slides = new List<SimpleSlide>();
            var temp = new List<Photo>();
            int id = 0;

            foreach (var photo in photos)
            {
                if (photo.Orientation == "H")
                {
                    slides.Add(new SimpleSlide(new List<Photo> { photo }, id++));
                }
                else
                {
                    if (photo.Orientation == "V")
                    {
                        temp.Add(photo);
                        if (temp.Count > 1)
                        {
                            slides.Add(new SimpleSlide(temp, id++));
                            temp = new List<Photo>();
                        }
                    }
                }
            }

            return slides;
        }

        private static List<SimpleSlide> CreateEnhancedSlideList(List<SimpleSlide> slidesBefore)
        {
            List<SimpleSlide> slidesAfter = new List<SimpleSlide>();
            int slideCount = slidesBefore.Count;
            int bestInterest = 0;
            int bestId = 0;
            bool matchFound = false;

            for (int i = 0; i < slideCount; i++)
            {
                SimpleSlide masterSlide = slidesBefore.ElementAt(i);

                if (!masterSlide.Processed)
                {
                    slidesBefore.ElementAt(i).Processed = true;

                    for (int j = 0; j < slideCount; j++)
                    {
                        SimpleSlide currentSlide = slidesBefore.ElementAt(j);
                        matchFound = false;

                        if (!currentSlide.Processed && i != j)
                        {
                            var interest = CalculateInterestFactor(masterSlide, currentSlide);
                            if (interest > bestInterest)
                            {
                                bestInterest = interest;
                                bestId = j;
                            }
                            matchFound = true;
                        }
                        else
                        {
                            matchFound = false;
                        }
                       
                    }

                    if (matchFound)
                    {
                        slidesAfter.Add(masterSlide);
                        var bestSlide = slidesBefore.ElementAt(bestId);
                        slidesAfter.Add(bestSlide);
                        slidesBefore.ElementAt(bestId).Processed = true;
                        //Console.WriteLine($"Best match for Ids {masterSlide.Id} and {bestSlide.Id} is {bestInterest}");
                        
                        bestInterest = 0;
                    }
                    else
                    {
                        // No match found.... this one, was the last slide to match
                        //Console.WriteLine($"Adding single slide {masterSlide.Id}");

                        slidesAfter.Add(masterSlide);
                    }
                }
            }
            slidesAfter.ForEach(s => s.Processed = false);
            return slidesAfter;
        }
        #endregion



    }
}