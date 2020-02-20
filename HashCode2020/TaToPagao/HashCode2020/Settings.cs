using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020
{
    public class Settings
    {
        private string _dataDirectory = string.Empty;

        public string DataDirectory
        {
            get => _dataDirectory;
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

        public string OutputDirectory
        {
            get => _output;
            set
            {
                _output = value.Replace('/', System.IO.Path.DirectorySeparatorChar).Replace('\\', System.IO.Path.DirectorySeparatorChar).Replace($"~{System.IO.Path.DirectorySeparatorChar}", $"{System.IO.Directory.GetCurrentDirectory()}{System.IO.Path.DirectorySeparatorChar}");
                if (!System.IO.Directory.Exists(_output))
                    System.IO.Directory.CreateDirectory(_output);
            }
        }

        public List<string> FilesName { get; set; }
    }
}
