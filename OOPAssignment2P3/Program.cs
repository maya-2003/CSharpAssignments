namespace OOPAssignment2P3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration dur1 = new Duration(5, 30, 30);
            Console.WriteLine("Duration 1 : " + dur1);

            Duration dur2 = new Duration(666);
            Console.WriteLine("Duration 2 : " + dur2);

            Duration dur3 = new Duration(0, 0, 0);

            dur3=dur1+ dur2;
            Console.WriteLine("Duration 3 : Duration 1 + Duration 2 = " + dur3);

            dur3 = dur2 + 6000;
            Console.WriteLine("Duration 3  + 6000 secs = " + dur3);

            dur2 = 7600 + dur1;
            Console.WriteLine("Duration 2  + 7600 secs = " + dur2);

            dur3 = ++dur3;
            Console.WriteLine("Duration 3  + 1 min = " + dur3);

            dur2 = --dur2;
            Console.WriteLine("Duration 2  - 1 min = " + dur2);

            DateTime dt= (DateTime)dur1;
            Console.WriteLine("Duration 1 to DateTime : " + dt);


        }
    }
}
