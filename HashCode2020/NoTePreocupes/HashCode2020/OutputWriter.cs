using System.IO;
using HashCode2020.Models;

namespace HashCode2020
{
    public class OutputWriter
    {
        public Output _output;

        public OutputWriter(Output output)
        {
            _output = output;
        }

        public void Write(string outputFilePath)
        {
            using StreamWriter writer = File.AppendText(outputFilePath);
            writer.WriteLine(_output.scoringLibraries);
            foreach (var library in _output.librariesContent)
            {
                writer.WriteLine(string.Join(' ', library.libraryId, library.totalBooksToScan));
                writer.WriteLine(string.Join(' ', library.booksScanned));
            }
        }

    }
}
