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

            //TODO: Y guardar el resultado con que no está implementado. 
            _provider.SaveFileOutput();
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
