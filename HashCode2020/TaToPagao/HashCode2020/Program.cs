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
            List<Scheduler> results = null;
            files.ForEach
            (f =>
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"File: {f.Name}");
                    Scheduler result = _provider.GetContentFile(f);
                    result.Process();
                    results.Add(result);
                }
            );

            _provider.SaveFileOutput(results);
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
            .AddEnvironmentVariables("HashCode2020_")
            .AddCommandLine(args);

            builder.Build().Bind(nameof(Settings), Configuration);
            _provider = new FilesProvider(Configuration);
        }

        #endregion



    }
}