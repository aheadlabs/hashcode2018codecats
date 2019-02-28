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

            // Generate output files
            _provider.SaveFileOutput();
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