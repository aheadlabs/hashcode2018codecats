using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2018
{
    public class Ride
    {
        #region Public Properties

        public int Id { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public Ride(int id)
        {
            Id = id;
        }

        #endregion Public Constructors

        #region Public Properties

        public Location From { get; set; }
        public Location To { get; set; }
        public int EarliestStart { get; set; }
        public int LatestFinish { get; set; }
        public int Distance { get; set; }

        #endregion Public Properties
    }
}