namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 6
            Console.WriteLine("Enter a number");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine(i);

            }
            #endregion

            #region Task 7
            Console.WriteLine("Enter a number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine(num2 * i);

            }
            #endregion

            #region Task 8
            Console.WriteLine("Enter a number");
            int num3 = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= num3; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);

                }


            }
            #endregion


            #region Task 9
            Console.WriteLine("Enter two numbers");
            int baseNum = Convert.ToInt32(Console.ReadLine());
            int powerNum = Convert.ToInt32(Console.ReadLine());
            int product = 1;
            for (int i = 0; i < powerNum; i++)
            {
                product = product * baseNum;
            }
            Console.WriteLine(product);
            #endregion

            #region Task 10
            Console.WriteLine("Enter 5 numbers");
            int[] nums = new int[5];
            for (int i = 0; i < 5; i++)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }
            int total = new int();
            for (int i = 0; i < 5; i++)
            {
                total += nums[i];
            }
            float average = (float)total / nums.Length;
            int precentage = (int)(((float)total / 500) * 100);
            Console.WriteLine("Total marks = " + total);
            Console.WriteLine("Average Marks = " + average);
            Console.WriteLine("Percentage = " + precentage);
            #endregion

            #region Task 11
            Console.WriteLine("Enter month number");
            int monthNum = Convert.ToInt32(Console.ReadLine());
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Console.WriteLine("Days in Month: " + days[monthNum - 1]);
            #endregion

            #region Task 12
            Console.WriteLine("Enter two numbers");
            int calcNum = Convert.ToInt32(Console.ReadLine());
            int calcNum2 = Convert.ToInt32(Console.ReadLine());
            char oper = Console.ReadLine()[0];
            switch (oper)
            {
                case '+':
                    Console.WriteLine(calcNum + " + " + calcNum2 + " = " + (calcNum + calcNum2));
                    break;

                case '-':
                    Console.WriteLine(calcNum + " - " + calcNum2 + " = " + (calcNum - calcNum2));
                    break;

                case '*':
                    Console.WriteLine(calcNum + " x " + calcNum2 + " = " + (calcNum * calcNum2));
                    break;

                case '/':
                    if (calcNum2 != 0)
                    {
                        Console.WriteLine(calcNum + " / " + calcNum2 + " = " + (calcNum / calcNum2));
                    }
                    else
                    {
                        Console.WriteLine("Can't divide by zero");
                    }

                    break;

            }
            #endregion


            #region Task 13
            Console.WriteLine("Enter a string");
            string str = Console.ReadLine();
            char[] strArr = str.ToCharArray();
            Array.Reverse(strArr);
            Console.WriteLine(new string(strArr));
            #endregion

            #region Task 14
            Console.WriteLine("Enter a number");
            int orgNum = Convert.ToInt32(Console.ReadLine());
            char[] revNum = (new string(orgNum.ToString())).ToCharArray();
            Array.Reverse(revNum);
            Console.WriteLine(new string(revNum));
            #endregion

            #region Task 15
            Console.WriteLine("Input starting number of range: ");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input ending number of range: ");
            int end = Convert.ToInt32(Console.ReadLine());
            for (int i = start; i <= end; i++)
            {
                if (i < 2)
                {
                    continue;
                }
                bool numIsPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {

                    if (i % j == 0)
                    {
                        numIsPrime = false;
                        break;
                    }
                }
                if (numIsPrime)
                {
                    Console.WriteLine(i);
                }
            }
            #endregion

            #region Task 17
            int[,] points = new int[3, 2];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter point {i + 1} x");
                points[i, 0] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Enter point {i + 1} y");
                points[i, 1] = Convert.ToInt32(Console.ReadLine());
            }

            if ((points[1, 0] - points[0, 0]) * (points[2, 1] - points[0, 1]) == (points[1, 1] - points[0, 1]) * (points[2, 0] - points[0, 0]))
            {
                Console.WriteLine("These points lie on a single straight line");
            }
            else
            {
                Console.WriteLine("These points don't lie on a single straight line");
            }
            #endregion

            #region Task 18
            Console.WriteLine("Enter task time :");
            int time = Convert.ToInt32(Console.ReadLine());
            string message = time switch
            {
                >= 2 and < 3 => "You are highly efficient",
                >= 3 and < 4 => "Increase your speed",
                >= 4 and <= 5 => "You will be provided with training to enhance your speed",
                > 5 => "You are required to leave the company",
                _ => "Invalid time"
            };
            Console.WriteLine(message);
            #endregion
        }
    }
}
