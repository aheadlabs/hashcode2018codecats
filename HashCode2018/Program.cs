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
                vehiclesList.Add(new Vehicle(dataSet.Steps));
            }

            Console.ReadKey();
        }

        #endregion Private Methods
    }
}