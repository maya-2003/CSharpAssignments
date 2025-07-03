namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            Console.WriteLine("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num % 3 == 0 && num % 4 == 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");

            }
            #endregion

            #region Task 2
            Console.WriteLine("Enter a number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num2 < 0)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
            #endregion

            #region Task 3
            Console.WriteLine("Enter three numbers ");
            int numb1 = Convert.ToInt32(Console.ReadLine());
            int numb2 = Convert.ToInt32(Console.ReadLine());
            int numb3 = Convert.ToInt32(Console.ReadLine());
            int max, min;
            if (numb1 >= numb2 && numb1 >= numb3)
            {
                max = numb1;
                if (numb2 <= numb3)
                {
                    min = numb2;
                }
                else
                {
                    min = numb3;
                }
            }
            else if (numb2 >= numb1 && numb2 >= numb3)
            {
                max = numb2;
                if (numb1 <= numb3)
                {
                    min = numb1;

                }
                else
                {
                    min = numb3;
                }

            }
            else
            {
                max = numb3;
                if (numb1 <= numb2)
                {
                    min = numb1;
                }
                else
                {
                    min = numb2;
                }

            }
            Console.WriteLine("Max element = " + max);
            Console.WriteLine("Min element = " + min);

            #endregion

            #region Task 4
            Console.WriteLine("Enter a number ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n % 2 == 0)
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }
            #endregion

            #region Task 5
            Console.WriteLine("Enter a character");
            char charac = Console.ReadLine()[0];
            charac = char.ToLower(charac);
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            if (vowels.Contains(charac))
            {
                Console.WriteLine("Vowel");
            }
            else
            {
                Console.WriteLine("Consonant");
            }

            #endregion
        }
    }
}
