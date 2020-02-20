using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Model
{
    class Library
    {
        int ID { get; set; }
        int BookCapacity { get; set; }
        int StartUpDays { get; set; }
        int BooksPerDay { get; set; }
        List<Book> AvailableBooks { get; set; }

        Library(int id, int capacity, int days, int booksPerDay)
        {
            this.ID = id;
            this.BookCapacity = capacity;
            this.StartUpDays = days;
            this.BooksPerDay = booksPerDay;
            this.AvailableBooks = new List<Book>();
        }

        void addBook(Book book)
        {
            this.AvailableBooks.Add(book);
        }

        int CalculateScore()
        {
            return 0;
        }

        int CalculatePowert(int daysLeft)
        {
            return 0;
        }
    }
}
