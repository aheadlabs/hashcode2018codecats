using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HashCode2020.Model
{
    public class Scheduler
    {
        public List<Library> AvailableLibraries { get; set; }
        public List<Library> SelectedLibraries { get; set; }
        public List<Book> BookCollection { get; set; }
        public int TimeLimit { get; set; }

        public FileInfo FileInfo { get; set; }

        public Scheduler(int days, FileInfo fileInfo)
        {
            this.TimeLimit = days;
            this.FileInfo = fileInfo;
            this.AvailableLibraries = new List<Library>();
            this.BookCollection = new List<Book>();
        }

        public void AddLibrary(Library foo)
        {
            AvailableLibraries.Add(foo);
        }

        public void AddBook(Book foo)
        {
            BookCollection.Add(foo);
        }

        public Library FindBestLibrary(int day)
        {
            Library bestLibrary = null;
            int timeLeft = this.TimeLimit - day;
            foreach (Library foo in this.AvailableLibraries)
            {
                if (bestLibrary == null)
                    bestLibrary = foo;
                else if (foo.CalculateLibraryScore(timeLeft) > bestLibrary.CalculateLibraryScore(timeLeft))
                    bestLibrary = foo;
            }
            return bestLibrary;
        }

        public Book FindBestBook()
        {
            Book bestBook = null;
            foreach (Book foo in BookCollection)
            {
                if (bestBook == null)
                    bestBook = foo;

                if (foo.Score > bestBook.Score)
                    bestBook = foo;
            }
            BookCollection.Remove(bestBook);
            return bestBook;
        }

        public Book FindBestBookInCatalogue(List<Book> catalogue)
        {
            Book bestBook = null;
            foreach (Book foo in catalogue)
            {
                if (bestBook == null)
                    bestBook = foo;

                if (foo.Score > bestBook.Score)
                    bestBook = foo;
            }

            return bestBook;
        }

        public void Process()
        {
            Library bar = null;
            Book bestBook = null;
            for (int currentDay = 0; currentDay < this.TimeLimit && this.BookCollection.Count > 0; currentDay++)
            {
                bar = FindBestLibrary(currentDay);
                bar.DaysToWork = this.TimeLimit - currentDay;
                for (int i = bar.BookCapacity; i > 0 && bar.HasRoom(); i--)
                {
                    while (bestBook == null)
                    {
                        Book foo = FindBestBookInCatalogue(bar.AvailableBooks);
                        if (this.BookCollection.Contains(foo))
                        {
                            bestBook = foo;
                        }
                    }

                    if (bestBook != null)
                    {
                        bar.AddAddedBook(bestBook);
                        this.BookCollection.Remove(bestBook);
                    }
                    bestBook = null;
                }

                if (bar.AddedBooks.Count > 0)
                {
                    this.SelectedLibraries.Add(bar);
                    this.AvailableLibraries.Remove(bar);
                    currentDay += bar.StartUpDays;
                }
            }
        }

        public List<Library> GetProcessedLibraries()
        {
            return this.SelectedLibraries;
        }
    }
}
