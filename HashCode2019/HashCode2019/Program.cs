using HashCode2019.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCode2019
{
    class Program
    {
        public static Settings Configuracion { get; set; } = new Settings();
        private static FilesProvider _provider;

        static void Main(string[] args)
        {
            Setup(args);
            Init();
        }

        private static void Init()
        {
            var files = _provider.GetFiles();
            files.ForEach(f => ProcessFile(_provider.GetContentFile(f)));
        }

        /// <summary>
        /// Procesa cada fichero de entrada.
        /// </summary>
        /// <param name="contentFile">
        ///     Contenido del fichero. Cada elemento en la lista representa una fila del documento.
        ///     El formato de las filas del documento son números separados por espacios, es decir,
        ///     un array de integers.
        /// </param>
        private static void ProcessFile(List<Photo> contentFile)
        {
            //TODO: Una vez obtenido el contenido del fichero, hacer algo con él...
            var result = Slide.CreateSlids(contentFile);

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

            builder.Build().Bind(nameof(Settings), Configuracion);
            _provider = new FilesProvider(Configuracion);
        }
    }
}
