using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Model
{
    public class Library
    {
        public int ID { get; set; }
        public int BookCapacity { get; set; }
        public int StartUpDays { get; set; }
        public int BooksPerDay { get; set; }
        public List<Book> AvailableBooks { get; set; }
        public List<Book> AddedBooks { get; set; }

        public Library(int id, int capacity, int days, int booksPerDay)
        {
            this.ID = id;
            this.BookCapacity = capacity;
            this.StartUpDays = days;
            this.BooksPerDay = booksPerDay;
            this.AvailableBooks = new List<Book>();
            this.AddedBooks = new List<Book>();
        }

        public void AddAvailableBook(Book book)
        {
            this.AvailableBooks.Add(book);
        }
        public void AddAddedBook(Book book)
        {
            this.AddedBooks.Add(book);
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

        public int CalculateTotalBooks(int daysLeft)
        {
            int totalDays = daysLeft - this.StartUpDays;
            return totalDays * this.BooksPerDay;
        }
    }
}
