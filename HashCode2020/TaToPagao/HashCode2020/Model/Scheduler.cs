using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Model
{
    class Scheduler
    {
        List<Library> Libraries { get; set; }
        List<Book> BookCollection { get; set; }
        int TimeLimit { get; set; }

        Scheduler(int days)
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
                else if (foo.CalculatePower(timeLeft) > bestLibrary.CalculatePower(timeLeft))
                    bestLibrary = foo;
            }
            return bestLibrary;
        }
    }
}
