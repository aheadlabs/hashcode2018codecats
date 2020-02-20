namespace HashCode2020.Models
{
    public class Input
    {
        public int TotalBooks;
        public int TotalLibraries;
        public int TotalDays;

        // Books will contain ID of book as index and score of book as value
        public int[] Books = { };

        public InputLibrary[] Libraries;

    }


}
