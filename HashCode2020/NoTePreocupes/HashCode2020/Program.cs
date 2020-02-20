using HashCode2020;
using HashCode2020.Models;

namespace PracticeRound2020
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input from args
            InputReader inputReader = new InputReader(args[0]);
            Input input = inputReader.GetInput();

            // Do the work
            // SuperDuper program will generate output here
            LibrariesContent[] librariesResult =
            {
                new LibrariesContent()
                {
                    libraryId = 1, totalBooksToScan = 3, booksScanned = new[] {5, 2, 3}
                },
                new LibrariesContent()
                {
                    libraryId = 0, totalBooksToScan = 5, booksScanned = new[] {0, 1, 2, 3, 4}
                },
            };
            Output outDataForExample = new Output()
            {
                scoringLibraries = 2,
                librariesContent = librariesResult
            };

            OutputWriter writer = new OutputWriter(outDataForExample);
            writer.Write("Submissions/submission_a.txt");

            // Place output somewhere
        }
    }
}