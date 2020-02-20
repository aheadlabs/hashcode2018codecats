using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HashCode2020.Model;

namespace HashCode2020
{
    public static class ModelHelpers
    {
        public static List<Book> ParseBooksFromLine(string[] line)
        {
            List<Book> books = new List<Book>();
            for (int b = 0; b < line.Length; b++)
            {
                books.Add(new Book(
                    b, 
                    Int32.Parse(line[b])));
            }
            return books;
        }

        public static Library ParseLibraryFromLine(int id, string[] line)
        {
            return new Library(
                id,
                Int32.Parse(line[0]),
                Int32.Parse(line[1]),
                Int32.Parse(line[2]));
        }

        public static List<Book> GetBooksInLibraryFromLine(string[] line, List<Book> books)
        {
            IEnumerable<Book> temp = line.Select(s => books.First(b => b.ID == Int32.Parse(s)));
            return temp.ToList();
        }
    }
}
