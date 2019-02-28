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
        #region Public Properties

        public static Settings Configuration { get; set; } = new Settings();

        #endregion Public Properties

        #region Private Fields

        private static FilesProvider _provider;

        #endregion Private Fields

        #region Private Methods

        public static List<SimpleSlide> CreateSimpleSlideList(List<Photo> photos)
        {
            var slides = new List<SimpleSlide>();
            var temp = new List<Photo>();

            foreach (var photo in photos)
            {
                if (photo.Orientation == "H")
                {
                    slides.Add(new SimpleSlide(new List<Photo> { photo }));
                }
                else
                {
                    if (photo.Orientation == "V")
                    {
                        temp.Add(photo);
                        if (temp.Count > 1)
                        {
                            slides.Add(new SimpleSlide(temp));
                        }
                    }
                }
            }

            return slides;
        }

        private static void Main(string[] args)
        {
            Setup(args);
            Init();
        }

        private static void Init()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*** START PROCESSING FILES ***");
            Console.WriteLine("");
            List<FileInfo> files = _provider.GetFiles();
            files.ForEach(f =>
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"File: {f.Name}");
                ProcessFile(_provider.GetContentFile(f));
            }
                );

<<<<<<< HEAD
=======

            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**** ALL FILES PROCESSED ****");
>>>>>>> f6a1713c4ff99cc1cdb03d8e807acadeb88f92bd
            Console.ReadKey();
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Creating slideshow with {contentFile.Count} photos...");
            List<SimpleSlide> simpleSlideList = CreateSimpleSlideList(contentFile);
            int score = CalculateScore(simpleSlideList);
            Console.WriteLine($" · Created! Contains {simpleSlideList.Count} elements with score: {score}");
            Console.WriteLine("");

            //TODO: Y guardar el resultado con que no está implementado.
            _provider.SaveFileOutput(simpleSlideList);
        }

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

<<<<<<< HEAD
=======
        public static List<SimpleSlide> CreateSimpleSlideList(List<Photo> photos)
        {
            var slides = new List<SimpleSlide>();
            var temp = new List<Photo>();

            foreach (var photo in photos)
            {
                if (photo.Orientation == "H")
                {
                    slides.Add(new SimpleSlide(new List<Photo> { photo }));
                }
                else
                {
                    if (photo.Orientation == "V")
                    {
                        temp.Add(photo);
                        if (temp.Count > 1)
                        {
                            slides.Add(new SimpleSlide(temp));
                            temp = new List<Photo>();
                        }
                    }
                }
            }

            return slides;
        }

>>>>>>> f6a1713c4ff99cc1cdb03d8e807acadeb88f92bd
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

        #endregion Private Methods
    }
}