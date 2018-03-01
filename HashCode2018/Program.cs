using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace HashCode2018
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            string currentPath = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName, "data");
            string filePath = Path.Combine(currentPath, "a_example.in");

            string[] contents = FilesHelper.ReadFile(filePath);
            DataSet dataSet = DataHelper.MapToDataset(contents);

            List<Vehicle> vehiclesList = new List<Vehicle>();
            for (int i = 0; i < dataSet.Vehicles; i++)
            {
                vehiclesList.Add(new Vehicle(dataSet.Steps, i));
            }

            int distance1To2 = Math.Abs(dataSet.RidesList[0].From - dataSet.RidesList[1].To);
            int distance2To3 = Math.Abs(dataSet.RidesList[1].From - dataSet.RidesList[2].To);
            int distance0To3 = Math.Abs(new Location { Row = 0, Column = 0 } - dataSet.RidesList[2].To);

            int totalDistance = distance1To2 + distance2To3
                                             + dataSet.RidesList[0].Distance
                                             + dataSet.RidesList[1].Distance
                                             + dataSet.RidesList[2].Distance;

            bool canDoRide = totalDistance <= dataSet.Steps;

            foreach (Vehicle vehicle in vehiclesList)
            {
                for (var index = 0; index < dataSet.RidesList.Count; index++)
                {
                    Ride ride = dataSet.RidesList[index];
                    bool ok = vehicle.RideGo(ride);
                    if (ok) break;
                }
            }

            Console.ReadKey();
        }

        #endregion Private Methods
    }
}