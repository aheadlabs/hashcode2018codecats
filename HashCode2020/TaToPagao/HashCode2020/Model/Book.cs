using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Model
{
    class Book
    {
        int ID { get; set; }
        int Score { get; set; }

        Book(int id, int score)
        {
            this.ID = id;
            this.Score = score;
        }
    }
}
