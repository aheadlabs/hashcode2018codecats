using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Model
{
    public class Scheduler
    {
        public List<Library> Libraries { get; set; }
        public List<Book> BookCollection { get; set; }
        public int TimeLimit { get; set; }

        public Scheduler(int days)
        {
            this.TimeLimit = days;
            this.Libraries = new List<Library>();
            this.BookCollection = new List<Book>();
        }

        public void AddLibrary(Library foo)
        {
            Libraries.Add(foo);
        }

        public void AddBook(Book foo)
        {
            BookCollection.Add(foo);
        }

        public Library GetBestLibrary(int day)
        {
            Library bestLibrary = null;
            int timeLeft = this.TimeLimit - day;
            foreach (Library foo in this.Libraries)
            {
                if (bestLibrary == null)
                    bestLibrary = foo;
                else if (foo.CalculateTotalBooks(timeLeft) > bestLibrary.CalculateTotalBooks(timeLeft))
                    bestLibrary = foo;
            }
            return bestLibrary;
        }
    }
}
