using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2018
{
    public class DataSet
    {
        #region Public Properties

        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Vehicles { get; set; }
        public int Rides { get; set; }
        public int Bonus { get; set; }
        public int Steps { get; set; }

        public List<Ride> RidesList { get; set; }

        #endregion Public Properties
    }
}

//3 4 2 3 2 10
//0 0 1 3 2 9
//1 2 1 0 0 9
//2 0 2 2 0 9
//3 rows, 4 columns, 2 vehicles, 3 rides, 2 bonus and 10 steps
//ride from[0, 0] to[1, 3], earliest start 2, latest finish 9
//ride from[1, 2] to[1, 0], earliest start 0, latest finish 9
//ride from[2, 0] to[2, 2], earliest start 0, latest finish 9

//The first line of the input file contains the following integer numbers separated by single spaces:
//● R – number of rows of the grid(1 ≤ R ≤ 10000)
//● C – number of columns of the grid(1 ≤ C ≤ 10000)
//● F – number of vehicles in the fleet(1 ≤ F ≤ 1000)
//● N – number of rides(1 ≤ N ≤ 10000)
//● B – per-ride bonus for starting the ride on time(1 ≤ B ≤ 10000)
//● T – number of steps in the simulation(1 ≤ T ≤ 109)
//N subsequent lines of the input file describe the individual rides, from ride 0 to ride N − 1 . Each line
//contains the following integer numbers separated by single spaces:
//● a – the row of the start intersection(0 ≤ a<R)
//● b – the column of the start intersection(0 ≤ b<C)
//● x – the row of the finish intersection(0 ≤ x<R)
//● y – the column of the finish intersection(0 ≤ y<C)
//● s – the earliest start(0 ≤ s<T)
//● f – the latest finish(0 ≤ f ≤ T) , (f ≥ s + |x − a| + |y − b|)
//○ note that f can be equal to T – this makes the latest finish equal to the end of the simulation