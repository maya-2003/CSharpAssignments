namespace OOPAssignemnt2P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region  Modify the program so that you do not have to create an instance of class to call the four methods.
            Console.WriteLine("5 + 4 = " + Maths.Add(5, 4));
            Console.WriteLine("5 - 3 = "  + Maths.Subtract(5, 3));
            Console.WriteLine("2 * 10 = " + Maths.Multiply(2, 10));
            Console.WriteLine("20 / 4 = " + Maths.Divide(20, 4));
            #endregion
        }
    }
}
