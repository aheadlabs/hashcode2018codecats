using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2018
{
    public class Location
    {
        #region Public Properties

        public int Row { get; set; }
        public int Column { get; set; }

        public static int operator -(Location self, Location other)
        {
            return Math.Abs(self.Column - other.Column) + Math.Abs(self.Row - other.Row);
        }

        #endregion Public Properties
    }
}