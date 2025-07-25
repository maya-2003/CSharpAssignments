using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignemnt2P2
{

    internal class Maths
    {
        #region Define Class Maths that has four methods: Add, Subtract, Multiply, and Divide, each of them takes two parameters. Call each method in Main ().
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }

        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        public static double Divide(int num1, int num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("inavlid denominator");
                return -1;
            }
            else {
                return (double)num1 / num2;
            }
            
        }
        #endregion
    }

}
