namespace OOPAssignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 2. Override the ToString Function 
            Point3D p = new Point3D(10, 10, 10);
            Console.WriteLine(p);
            #endregion

            #region 3.  Read from the User the Coordinates for 2 points P1, P2 (Check the input using try Pares, Parse, Convert).
            string value;
            int x1, y1, z1;
            int x2, y2, z2;

            do
            {
                Console.Write("Enter x value for point 1: ");
                value = Console.ReadLine();
                if (!int.TryParse(value, out x1))
                    Console.WriteLine("Invalid value");
            } while (!int.TryParse(value, out x1));

            do
            {
                Console.Write("Enter y value for point 1:");
                value = Console.ReadLine();
                try
                {
                    y1 = int.Parse(value);
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid value");
                }
            } while (true);

            do
            {
                Console.Write("Enter z value for point 1:");
                value = Console.ReadLine();
                try
                {
                    z1 = Convert.ToInt32(value);
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid value");
                }
            } while (true);


            do
            {
                Console.Write("Enter x value for point 2: ");
                value = Console.ReadLine();
                if (!int.TryParse(value, out x2))
                    Console.WriteLine("Invalid value");
            } while (!int.TryParse(value, out x2));

            do
            {
                Console.Write("Enter y value for point 2:");
                value = Console.ReadLine();
                try
                {
                    y2 = int.Parse(value);
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid value");
                }
            } while (true);

            do
            {
                Console.Write("Enter z value for point 2:");
                value = Console.ReadLine();
                try
                {
                    z2 = Convert.ToInt32(value);
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid value");
                }
            } while (true);

            Point3D P1 = new Point3D(x1, y1, z1);
            Point3D P2 = new Point3D(x2, y2, z2);
            Console.WriteLine(P1);
            Console.WriteLine(P2);

            #endregion

            #region 4. Try to use == If (P1 == P2)   Does it work properly?
            // this will not work unless operator overloading is done
            if (P1 == P2)
            {
                Console.WriteLine("P1 equals P2");
            }
            else
            {
                Console.WriteLine("P1 and P2 are not equal");
            }
            #endregion

            #region 5. Define an array of points and sort this array based on X & Y coordinates.

            Point3D[] points = new Point3D[3];
            points[0] = new Point3D(7, 8, 9);
            points[1] = new Point3D(1, 2, 3);
            points[2] = new Point3D(4, 5, 6);

            Array.Sort(points);
            foreach (Point3D point in points)
            {
                Console.WriteLine(point);
            }
            #endregion

            #region 6. Implement ICloneable interface to be able to clone the object.
            Point3D p3 = new Point3D(8, 4, 5);
            Point3D p4 = (Point3D)p3.Clone();
            Console.WriteLine(p4);
            #endregion


        }
    }
}
