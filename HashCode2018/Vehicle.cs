using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2018
{
    public class Vehicle
    {
        #region Public Constructors

        public Vehicle(int maxSteps)
        {
            Position = new Location { Column = 0, Row = 0 };
            _maxSteps = maxSteps;
        }

        #endregion Public Constructors

        #region Public Properties

        public Location Position { get; private set; }
        public int CompliteSteps { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public bool CanDoIt(Ride ride)
        {
            var restSteps = _maxSteps - CompliteSteps - (ride.From - ride.To);
            return restSteps > 0 && (_maxSteps - CompliteSteps) <= restSteps;
        }

        public bool RideGo(Ride ride)
        {
            if (!CanDoIt(ride))
                return false;

            CompliteSteps += (ride.From - ride.To);
            Position = ride.To;
            return true;
        }

        #endregion Public Methods

        #region Private Fields

        private int _maxSteps;

        #endregion Private Fields
    }
}