namespace advancedAssignment1Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = { 3.5, 6.93, 8.8, 2.1, 4.7 };

            Console.WriteLine("Before sorting:");
            foreach (double number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Helper<double>.BubbleSort(numbers);

            Console.WriteLine("After sorting:");
            foreach (double number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\n--------------------------------");

            /////////////////////////////////////////////

            Range<double> doubleRange = new Range<double>(3.5, 7.2);
            Console.WriteLine($"Min: {doubleRange.Min}, Max: {doubleRange.MAx}");
            Console.WriteLine($"1.2 in range: {doubleRange.IsInRange(1.2)}");
            Console.WriteLine($"5.1 in range: {doubleRange.IsInRange(5.1)}"); 
            Console.WriteLine($"9.9 in range: {doubleRange.IsInRange(9.9)}");
            Console.WriteLine($"Length: {doubleRange.Length()}");
        }
    }
}
