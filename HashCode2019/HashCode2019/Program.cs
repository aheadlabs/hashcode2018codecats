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

        private static void Main(string[] args)
        {
            Setup(args);
            Init();
        }

        private static void Init()
        {
            List<FileInfo> files = _provider.GetFiles();
            files.ForEach(f => ProcessFile(_provider.GetContentFile(f)));
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
            // Create slides
            List<Slide> slides = Slide.CreateSlides(contentFile);

            // TODO: Processing logic

            SimpleSlide slide1 = new SimpleSlide(
                new List<Photo> {
                    new Photo
                    {
                        Id = 1,
                        Orientation = "H",
                        Tags = new List<string>
                        {
                            "cat", "car", "house", "animal"
                        }
                    }
                }
            );

            SimpleSlide slide2 = new SimpleSlide(
                new List<Photo> {
                    new Photo
                    {
                        Id = 1,
                        Orientation = "V",
                        Tags = new List<string>
                        {
                            "cat", "car"
                        }
                    },
                    new Photo
                    {
                        Id = 2,
                        Orientation = "V",
                        Tags = new List<string>
                        {
                            "pig", "fox"
                        }
                    }
                }
            );

            int if1 = CalculateInterestFactor(slide1, slide2);

            //TODO: Y guardar el resultado con que no está implementado. 
            _provider.SaveFileOutput();
        }

        private static int CalculateInterestFactor(SimpleSlide slide1, SimpleSlide slide2)
        {
            var inA = new List<string>();
            var inB = new List<string>();
            var inCommon = new List<string>();
            var all = new List<string>();
            var factors = new List<int>();
            
            // Interesection
            inCommon = slide1.Tags.Intersect(slide2.Tags).ToList();

            // In slide1, not in 2
            foreach (var tag in slide1.Tags)
            {
                if (!inCommon.Contains(tag)){
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

            return  factors.Min(f => f);
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

        #endregion Private Methods
    }
}