using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2018
{
    public static class FilesHelper
    {
        #region Public Methods

        public static string[] ReadFile(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }

        #endregion Public Methods
    }
}