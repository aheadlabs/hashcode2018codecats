using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace HashCode2019
{
    /// <summary>
    /// Provee la recuperación de los ficheros, su lectura en lineas de arrays de integer y el volcado 
    /// del fichero resultado (no implementado).
    /// </summary>
    public class FilesProvider
    {
        private Settings _config;

        /// <summary>
        /// Objeto de configuración de donde recuperar, ruta de la carpeta y nombres de ficheros.
        /// </summary>
        /// <param name="config"></param>
        public FilesProvider(Settings config)
        {
            _config = config;
        }

        public List<FileInfo> GetFiles()
        {
            var pathFiles = Directory.GetFiles(_config.DataDirectory).Where(x => _config.FilesName.Any(f => x.EndsWith(f)));
            var files = pathFiles.Select(p => new FileInfo(p)).ToList();

            return files;
        }

        public List<T[]> GetContentFile<T>(FileInfo file)
        {
            var stream = file.OpenText();
            var rows = new List<T[]>();

            while (!stream.EndOfStream)
            {
                rows.Add(
                    stream.ReadLine().Split(' ')
                    .Select(x => (T)Convert.ChangeType(x, typeof(T))).ToArray()
                );
            }

            return rows;
        }

        /// <summary>
        /// No implementado.
        /// TODO: pendiente de ver que pasar le para guardar.
        /// </summary>
        /// <returns></returns>
        public bool SaveFileOutput()
        {
            throw new NotImplementedException();
        }
    }
}
