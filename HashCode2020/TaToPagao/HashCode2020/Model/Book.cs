using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Model
{
    public class Book
    {
        public int ID { get; set; }
        public int Score { get; set; }

        public Book(int id, int score)
        {
            this.ID = id;
            this.Score = score;
        }
    }
}
