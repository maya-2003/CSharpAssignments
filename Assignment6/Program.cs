using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment6
{
    internal class Program
    {

        #region 1 - Explain the difference between passing (Value type parameters) by value and by reference then write a suitable c# example.
        // in passing by value a copy of the value is pushed onto the stack for the method and the original value stays unchanged
        // while in passing bt refrence the method updates the original value directly since it receives a reference to the original stack location
        
        static int getProduct(int num1, int num2)
        {
            int result = num1 * num2;
            return result;
        }

        static int getSquare(ref int numb)
        {
            numb = numb * numb;
            return numb;
        }
        #endregion

        #region 2- Explain the difference between passing (Reference type parameters) by value and by reference then write a suitable c# example.
        // in passing by value a copy of the reference is on the stack but object stays on the heap so the object contents can be changed but the reference can't be reassigned
        // in passing by reference the object content can be modified on the heap and also the reference can be reassigned
        static void SquareElements(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] * numbers[i];
            }
        }

        static void ChangeElements(ref int[] numbers)
        {
            numbers = new int[] { 10, 20, 30 };
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
        }
        #endregion

        #region 3- Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers
        static void CalcSumAndDiff(int n1, int n2, out int sum, out int diff)
        {
            sum = n1 + n2;
            diff = n1 + n2;
        }
        #endregion

        #region 4- Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.
        static int GetNumbersSum(int num) { 
            int sum = 0;
            while (num != 0) { 
                int currNum = num % 10;
                sum += currNum;
                num = num / 10; 
            }
            return sum;
        }

        #endregion

        #region 5- Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not:
        static bool IsPrime(int num) { 
            if (num <= 1) {
                return false;
            }
            else { 

                for (int i = 2; i <= Math.Sqrt(num); i++) { 
                    if (num % i == 0) { 
                        return false;
                    }
                }

                return true;
            }
        }
        #endregion

        #region 6- Create a function named MinMaxArray, to return the minimum and maximum values stored in an array, using reference parameters

        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            min = arr.Min();
            max = arr.Max();
        }
        #endregion

        #region 7- Create an iterative (non-recursive) function to calculate the factorial of the number specified as parameter
        static int CalcFactorial(int num) { 
            if (num < 2)
            {
                return 1;
            }
            int fact = 1;
            for (int i =2; i <= num; i++) {
                fact *= i;
            }
            return fact;
        }

        #endregion

        #region 8- Create a function named "ChangeChar" to modify a letter in a certain position (0 based) of a string, replacing it with a different letter

        static void ChangeChar(ref string str, int pos, char letter)
        {
            char[] letters = str.ToCharArray();
            letters[pos] = letter;
            str = new string(letters);
        }
        #endregion
        static void Main(string[] args)
        {
            int x = 3;
            int y = 4;
            Console.WriteLine("product: " + getProduct(x, y));
            Console.WriteLine("x brfore: " + x);
            getSquare(ref x);
            Console.WriteLine("x after : " + x);

            int[] numbers = { 1, 2, 3 };
            SquareElements(numbers);
            Console.WriteLine(string.Join(", ", numbers));
            ChangeElements(ref numbers);
            Console.WriteLine();

            int n1 = 50, n2 = 12;
            CalcSumAndDiff(n1, n2, out int sum, out int diff);
            Console.WriteLine($"Sum = {sum}, Difference = {diff}");

            int num = 152;
            Console.WriteLine($"Digits sum: {GetNumbersSum(num)}");
            Console.WriteLine($"Is prime: {IsPrime(5)}");

            int[] arr = { 20, 8, 2, 9, 11 };
            int min = 0, max = 0;
            MinMaxArray(arr, ref min, ref max);
            Console.WriteLine($"Min: {min}, Max: {max}");

            Console.WriteLine($"Factorial: {CalcFactorial(5)}");
            string str = "Hello";
            ChangeChar(ref str, 1, 'a');
            Console.WriteLine($"current string: {str}");











        }
    }
}
