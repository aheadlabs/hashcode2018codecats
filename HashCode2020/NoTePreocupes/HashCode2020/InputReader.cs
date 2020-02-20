using System.Collections.Generic;
using System.IO;
using System.Linq;
using HashCode2020.Models;

namespace HashCode2020
{
    public class InputReader
    {
        private readonly string _filePath;

        public InputReader(string filePath)
        {
            _filePath = filePath;
        }

        public Input GetInput()
        {
            var file = new StreamReader(_filePath);
            var line1 = file.ReadLine();
            Input inputData = new Input();
            // Get Totals from 1st line
            inputData.TotalBooks = int.Parse(line1.Split(' ')[0]);
            inputData.TotalLibraries = int.Parse(line1.Split(' ')[1]);
            inputData.TotalDays = int.Parse(line1.Split(' ')[2]);
            // Get Books from 2nd line
            var line2 = file.ReadLine();
            inputData.Books = line2.Split(' ').Select(int.Parse).ToArray();
            InputLibrary[] libraries = new InputLibrary[inputData.TotalLibraries];
            // Get inputData.TotalLibraries from subsequent lines
            for (int i = 0; i <= inputData.TotalLibraries-1; i++)
            {
                // 1st line of library will hold the library totals
                var libraryLine = file.ReadLine();
                InputLibrary library = new InputLibrary();
                library.NumberOfBooks = int.Parse(libraryLine.Split(' ')[0]);
                library.SignupDays = int.Parse(libraryLine.Split(' ')[1]);
                library.BooksScanningPerDay = int.Parse(libraryLine.Split(' ')[2]);
                // 2nd line contains book ids that the library contains
                var booksPerLibraryLine = file.ReadLine();
                library.Books = booksPerLibraryLine.Split(' ').Select(int.Parse).ToArray();
                libraries[i] = library;
            }

            inputData.Libraries = libraries;
            file.Dispose();
            return inputData;

        }


    }
}