namespace PracticeRound2020.Models
{
    public class PizzaInput
    {
        /// <summary>
        /// M -> Count of maximum slices of pizza
        /// </summary>
        public long MaxPizzaSlices { get; set; }
        /// <summary>
        /// N -> Count of maximum types of pizza
        /// </summary>
        public int MaxPizzaTypes { get; set; }
        /// <summary>
        /// Array containing a type on each index, and its number of slices as value
        /// </summary>
        public int[] PizzaSlices { get; set;}
    }
}
