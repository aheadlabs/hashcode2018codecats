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

        void AddLibrary(Library foo)
        {
            Libraries.Add(foo);
        }

        void AddBook(Book foo)
        {
            BookCollection.Add(foo);
        }
    }
}
