using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2018
{
    public static class DataHelper
    {
        #region Public Methods

        public static DataSet MapToDataset(string[] lines)
        {
            string firstLine = lines[0];
            string[] lineSplitted = firstLine.Split(" ".ToCharArray(), StringSplitOptions.None);

            DataSet dataSet = new DataSet
            {
                Rows = Int32.Parse((lineSplitted[0])),
                Columns = Int32.Parse((lineSplitted[1])),
                Vehicles = Int32.Parse((lineSplitted[2])),
                Rides = Int32.Parse((lineSplitted[3])),
                Bonus = Int32.Parse((lineSplitted[4])),
                Steps = Int32.Parse((lineSplitted[5])),
                RidesList = new List<Ride>()
            };

            for (int i = 1; i < lines.Length; i++)
            {
                lineSplitted = lines[i].Split(" ".ToCharArray(), StringSplitOptions.None);
                dataSet.RidesList.Add(new Ride
                {
                    From = new Location
                    {
                        Row = Int32.Parse(lineSplitted[0]),
                        Column = Int32.Parse(lineSplitted[1])
                    },
                    To = new Location
                    {
                        Row = Int32.Parse(lineSplitted[2]),
                        Column = Int32.Parse(lineSplitted[3])
                    },
                    EarliestStart = Int32.Parse(lineSplitted[4]),
                    LatestFinish = Int32.Parse(lineSplitted[5])
                });
            }

            return dataSet;
        }

        #endregion Public Methods
    }
}