using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Model
{
    public class Library
    {
        int ID { get; set; }
        int BookCapacity { get; set; }
        int StartUpDays { get; set; }
        int BooksPerDay { get; set; }
        List<Book> AvailableBooks { get; set; }
        List<Book> AddedBooks { get; set; }

        public Library(int id, int capacity, int days, int booksPerDay)
        {
            this.ID = id;
            this.BookCapacity = capacity;
            this.StartUpDays = days;
            this.BooksPerDay = booksPerDay;
            this.AvailableBooks = new List<Book>();
            this.AddedBooks = new List<Book>();
        }

        public void addBook(Book book)
        {
            this.AvailableBooks.Add(book);
        }

        public int CalculateScore()
        {
            int score = 0;
            foreach (Book foo in AddedBooks)
            {
                score += foo.Score;
            }
            return score;
        }

        public int CalculatePower(int daysLeft)
        {
            int totalDays = daysLeft - this.StartUpDays;
            return totalDays * this.BooksPerDay;
        }
    }
}
