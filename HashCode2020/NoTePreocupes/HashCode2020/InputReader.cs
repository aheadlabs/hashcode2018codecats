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
            //var file = new StreamReader(_filePath);
            //var line1 = file.ReadLine();
            //int m = int.Parse(line1.Split(' ')[0]);
            //int n = int.Parse(line1.Split(' ')[1]);
            //var line2 = file.ReadLine();
            //var pizzaSlices = line2.Split(' ').Select(int.Parse).ToArray();
            //file.Dispose();
            return new Input();

        }


    }
}