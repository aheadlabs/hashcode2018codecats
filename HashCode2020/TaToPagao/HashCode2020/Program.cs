using HashCode2020.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCode2020
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

            var content = _provider.GetContentFile(files[0]);

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
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables("HashCode2020_")
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
        private static void ProcessFile(Scheduler contentFile)
        {
            //// Create BASIC Slide Show
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine($"Creating slideshows with {contentFile.Count} photos...");
            //List<SimpleSlide> simpleSlideList = CreateSimpleSlideList(contentFile);
            //int score = CalculateScore(simpleSlideList);
            //Console.Write($" · Before processing... Contains {simpleSlideList.Count} elements with score: ");
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine(score);
            ////_provider.SaveFileOutput(simpleSlideList);

            //// STEP 1
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //List<SimpleSlide> enhancedSlideList = CreateEnhancedSlideList(simpleSlideList);
            //Console.Write($" · STEP 1 --> Contains {enhancedSlideList.Count} elements with score: ");
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //score = CalculateScore(enhancedSlideList);
            //Console.WriteLine(score);
            ////_provider.SaveFileOutput(enhancedSlideList);

            //// STEP 2
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //List<SimpleSlide> enhancedSlideList2 = CreateEnhancedSlideList(enhancedSlideList);
            //score = CalculateScore(enhancedSlideList2);
            //Console.Write($" · STEP 2 --> Contains {enhancedSlideList2.Count} elements with score: ");
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine(score);
            ////_provider.SaveFileOutput(enhancedSlideList2);

            //// STEP 3
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //List<SimpleSlide> enhancedSlideList3 = CreateEnhancedSlideList(enhancedSlideList2);
            //score = CalculateScore(enhancedSlideList3);
            //Console.Write($" · STEP 3 --> Contains {enhancedSlideList3.Count} elements with score: ");
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine(score);
            //_provider.SaveFileOutput(enhancedSlideList3);

            //Console.WriteLine("");
        }


        #endregion
    }
}
