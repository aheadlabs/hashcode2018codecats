using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020
{
    /// <summary>
    /// Objeto de configuración.
    /// </summary>
    public class Settings
    {
        private string _dataDirectory = string.Empty;
        /// <summary>
        /// Ruta del directorio donde se encuentran los ficheros.
        /// Puede ser relativa (~/) o absoluta.
        /// </summary>
        public string DataDirectory
        {
            get
            {
                return _dataDirectory;
            }
            set
            {
                if (!value.StartsWith("~/") && !System.IO.Directory.Exists(value))
                    throw new Exception("La ruta del directorio no existe. Solo rutas absolutas o relativas mediante la convención '~/'.");

                _dataDirectory = value.Replace('/', System.IO.Path.DirectorySeparatorChar).Replace('\\', System.IO.Path.DirectorySeparatorChar).Replace($"~{System.IO.Path.DirectorySeparatorChar}", $"{System.IO.Directory.GetCurrentDirectory()}{System.IO.Path.DirectorySeparatorChar}");
                if (!System.IO.Directory.Exists(_dataDirectory))
                    throw new Exception($"La ruta del directorio '{_dataDirectory}' no existe.");
            }
        }

        private string _output = string.Empty;
        /// <summary>
        /// Ruta del directorio donde guardar el fichero de salida.
        /// Puede ser relativa (~/) o absoluta.
        /// </summary>
        public string OutputDirectory
        {
            get
            {
                return _output;
            }
            set
            {
                _output = value.Replace('/', System.IO.Path.DirectorySeparatorChar).Replace('\\', System.IO.Path.DirectorySeparatorChar).Replace($"~{System.IO.Path.DirectorySeparatorChar}", $"{System.IO.Directory.GetCurrentDirectory()}{System.IO.Path.DirectorySeparatorChar}");
                if (!System.IO.Directory.Exists(_output))
                    System.IO.Directory.CreateDirectory(_output);
            }
        }

        /// <summary>
        /// Nombres de los ficheros que se quieren tener en cuenta para su lectura.
        /// </summary>
        public List<string> FilesName { get; set; }
    }
}
