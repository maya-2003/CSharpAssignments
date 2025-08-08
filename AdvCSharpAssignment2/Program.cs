using System.Collections;
using System.Security.Cryptography;

namespace AdvCSharpAssignment2
{
    internal class Program
    {
        static void ReverseArrayList(ArrayList list)
        {
            int i = list.Count - 1;
            int j = 0;
            while (i > j)
            {
                int temp = (int)list[i];
                list[i] = list[j];
                list[j] = temp;
                i--;
                j++;
            }
        }

        public static void RemoveDuplicates(ref int[] arr)
        {
            arr = arr.Distinct().ToArray();
        }

        public static void RemoveOddNumbers(ArrayList arrlist)
        {
            for (int i = arrlist.Count - 1; i >= 0; i--)
            {
                if (((int)arrlist[i]) % 2 != 0)
                    arrlist.RemoveAt(i);
            }
        }

        static void Main(string[] args)
        {
            #region 1. try to reverse the order of elements in the ArrayList in-place(in the same arrayList) without using the built-in Reverse. Implement a function that takes the ArrayList as input and modifies it to have the reversed order of elements.
            ArrayList arrayList = new ArrayList(6);
            arrayList.AddRange(new int[] { 20, 35, 12, 8, 2, 1 });

            Console.WriteLine("Original array list");

            foreach (var item in arrayList)
                Console.Write(item + " ");
            Console.WriteLine();

            ReverseArrayList(arrayList);

            Console.WriteLine("Reversed array list");

            foreach (var item in arrayList)
                Console.Write(item + " ");
            Console.WriteLine();
            #endregion

            #region 2. You are given a list of integers. Your task is to find and return a new list containing only the even numbers from the given list.
            List<int> lst = new List<int>();
            lst.InsertRange(index: 0, new int[] { 10, 40, 55, 999, 45, 66 });
            List<int> evenNumbers = lst.Where(n => n % 2 == 0).ToList();
            Console.Write("Even numbers:");
            foreach (var item in evenNumbers)
                Console.Write(item + " ");
            Console.WriteLine();
            #endregion

            #region 3. implement a custom list called FixedSizeList<T> with a predetermined capacity. This list should not allow more elements than its capacity and should provide clear messages if one tries to exceed it or access invalid indices.
            FixedSizeList<double> fl = new FixedSizeList<double>(3);
            fl.Add(5.0);
            fl.Add(7.0);
            fl.Add(8.9);
            Console.WriteLine($"Element at index 2: {fl.Get(2)}");
            #endregion

            #region 4. Given an array  consists of  numbers with size N and number of queries, in each query you will be given an integer X, and you should print how many numbers in array that is greater than  X.
            Console.WriteLine("Enter array size");
            if (!int.TryParse(Console.ReadLine(), out int arrSize))
            {
                Console.WriteLine("Invalid size");
                return;
            }

            Console.WriteLine("Enter number of queries");

            if (!int.TryParse(Console.ReadLine(), out int queriesCount))
            {
                Console.WriteLine("Invalid number");
                return;
            }


            int[] numbers = new int[arrSize];
            for (int i = 0; i < arrSize; i++)
            {
                Console.WriteLine($"Enter element {i}");
                while (true)
                {
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out numbers[i]))
                    {
                        break;
                    }

                    Console.WriteLine("Enter an integer");
                }
            }

            for (int i = 0; i < queriesCount; i++)
            {
                Console.WriteLine("Enter query");
                if (!int.TryParse(Console.ReadLine(), out int queryNum))
                {
                    Console.WriteLine("Invalid number");
                    return;
                }
                int count = numbers.Count(n => n > queryNum);
                Console.WriteLine(count);
            }

            #endregion

            #region 5. Given a number N and an array of N numbers. Determine if it's palindrome or not.
            Console.WriteLine("Enter array size");
            if (!int.TryParse(Console.ReadLine(), out int arrSize2))
            {
                Console.WriteLine("Invalid size");
                return;
            }
            int[] nums = new int[arrSize2];
            for (int i = 0; i < arrSize2; i++)
            {
                Console.WriteLine($"Enter element {i}");
                while (true)
                {
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out nums[i]))
                    {
                        break;
                    }

                    Console.WriteLine("Enter an integer");
                }
            }
            bool palindrome = true;

            for (int i = 0; i < arrSize2 / 2; i++)
            {
                if (nums[i] != nums[arrSize2 - i - 1])
                {
                    palindrome = false;
                    break;
                }
            }

            Console.WriteLine(palindrome ? "YES" : "NO");
            #endregion

            #region 6. Given an array, implement a function to remove duplicate elements from an array.
            int[] arr3 = { 15, 2, 15, 8, 9, 17, 8, 2 };
            RemoveDuplicates(ref arr3);

            Console.Write("After duplicates removal: ");
            foreach (int n in arr3)
            {
                Console.Write(n + " ");

            }
            Console.WriteLine();
            #endregion

            #region 7. Given an array list , implement a function to remove all odd numbers from it.
            ArrayList arrLst = new ArrayList(6);
            arrLst.AddRange(new int[] { 20, 35, 12, 8, 2, 1, 15 });
            RemoveOddNumbers(arrLst);

            Console.Write("After odd numbers removal: ");
            foreach (int n in arrLst)
            {
                Console.Write(n + " ");

            }

            #endregion
        }
    }
}
