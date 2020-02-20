using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020.Models
{
    public class WorkingData
    {
        private readonly Input _input;

        public WorkingData(Input input)
        {
            _input = input;
        }

        public Dictionary<int, int> RegisterMap;
        public Dictionary<int, int> BooksByLibraryMap;
        public Dictionary<int, int> LibraryBooksByDay;

        public Dictionary<int, int> createRegisterMap(int[] books)
        {
            Dictionary<int, int> registerMap = new Dictionary<int, int>();
            foreach (int bookId in books)
            {
                registerMap.Add(bookId, books[bookId]);
            }

            return registerMap;
        }
 
        public Dictionary<int, int> createBooksByLibraryMap(InputLibrary[] libraries)
        {
  
            Dictionary<int, Dictionary<int, int>> booksByLibraryMap = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i <= libraries.Length-1; i++ )
            {
                var booksInLibrary = createRegisterMap(libraries[i].Books);
                booksByLibraryMap.Add(i, booksInLibrary);
            }

            return BooksByLibraryMap;
        }

        public Dictionary<int, int> createLibraryBooksByDay(InputLibrary[] libraries)
        {
  
            Dictionary<int,int> libraryBooksByDay = new Dictionary<int, int>();
            for (int i = 0; i <= libraries.Length-1; i++ )
            {
                libraryBooksByDay.Add(i, libraries[i].BooksScanningPerDay);
            }

            return BooksByLibraryMap;
        }



    }
}
