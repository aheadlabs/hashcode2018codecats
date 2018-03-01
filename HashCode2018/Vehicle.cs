using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2018
{
    public class Vehicle
    {
        #region Public Properties

        public int Id { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public Vehicle(int maxSteps, int id)
        {
            Position = new Location { Column = 0, Row = 0 };
            _maxSteps = maxSteps;
            _id = id;
        }

        #endregion Public Constructors



        #region Public Properties

        public Location Position { get; private set; }
        public int CompliteSteps { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public List<Ride> RidesList { get; set; } = new List<Ride>();

        public bool CanDoIt(Ride ride)
        {
            var restSteps = _maxSteps - CompliteSteps - (ride.From - ride.To) + (this.Position - ride.From);
            return restSteps > 0 && (_maxSteps - CompliteSteps) >= restSteps;
        }

        public bool RideGo(Ride ride)
        {
            if (!CanDoIt(ride))
                return false;

            CompliteSteps += (ride.From - ride.To);
            Position = ride.To;
            RidesList.Add(ride);
            return true;
        }

        #endregion Public Methods

        #region Private Fields

        public override string ToString()
        {
            string[] a = RidesList.Select(x => x.Id.ToString()).ToArray();
            string b = string.Join(" ", a);
            return $"{_id} {b}";
        }

        private readonly int _id;
        private int _maxSteps;

        #endregion Private Fields
    }
}