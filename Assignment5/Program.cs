using static System.Net.Mime.MediaTypeNames;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 19 - Write a program that prints an identity matrix using for loop, in other words takes a value n from the user and shows the identity table of size n * n.
            Console.WriteLine("Enter value of n");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        matrix[row, col] = 1;
                    }
                    else
                    {
                        matrix[row, col] = 0;
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " | ");
                }
                Console.WriteLine();
            }
            #endregion


            #region 20 - Write a program in C# Sharp to find the sum of all elements of the array.
            Console.WriteLine("Enter size of array");
            int arrSize = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[arrSize];
            int sum = 0;
            Console.WriteLine("Enter array elements");
            for (int i = 0; i < arrSize; i++)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());

            }

            for (int i = 0; i < arrSize; i++)
            {
                sum += nums[i];
            }
            Console.WriteLine("Sum = " + sum);
            #endregion


            #region 21 - Write a program in C# Sharp to merge two arrays of the same size sorted in ascending order.
            Console.WriteLine("Enter size of the arrays");
            int numsSize = Convert.ToInt32(Console.ReadLine());
            int[] nums1 = new int[numsSize];
            Console.WriteLine("Enter array 1 elements");
            for (int i = 0; i < numsSize; i++)
            {
                nums1[i] = Convert.ToInt32(Console.ReadLine());

            }
            int[] nums2 = new int[numsSize];
            Console.WriteLine("Enter array 2 elements");
            for (int i = 0; i < numsSize; i++)
            {
                nums2[i] = Convert.ToInt32(Console.ReadLine());

            }
            int[] nums3 = new int[nums1.Length + nums2.Length];
            Array.Copy(nums1, 0, nums3, 0, numsSize);
            Array.Copy(nums2, 0, nums3, numsSize, nums2.Length);
            Array.Sort(nums3);
            foreach (int numb in nums3)
            {
                Console.Write(numb + " ");
            }

            #endregion


            #region 22 - Write a program in C# Sharp to count the frequency of each element of an array.
            Console.WriteLine("Enter array size");
            int arrLen = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[arrLen];
            Console.WriteLine("Enter array elements");
            for (int i = 0; i < arrLen; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] freqArr = new int[arrLen];
            for (int i = 0; i < arrLen; i++)
            {
                freqArr[i] = -1;
            }

            for (int i = 0; i < arrLen; i++)
            {
                int numFreq = 1;
                for (int j = i + 1; j < arrLen; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        numFreq++;
                        freqArr[j] = 0;
                    }
                }
                if (freqArr[i] != 0)
                {
                    freqArr[i] = numFreq;
                }
            }
            for (int i = 0; i < arrLen; i++)
            {
                if (freqArr[i] != 0)
                {
                    Console.WriteLine($"{arr[i]} frequency : {freqArr[i]} ");
                }
            }
            #endregion

            #region 23 - Write a program in C# Sharp to find maximum and minimum element in an array
            Console.WriteLine("Enter size of array");
            int arSize = Convert.ToInt32(Console.ReadLine());
            int[] numsArr = new int[arSize];

            Console.WriteLine("Enter array elements");
            for (int i = 0; i < arSize; i++)
            {
                numsArr[i] = Convert.ToInt32(Console.ReadLine());

            }

            int min = numsArr[0];
            int max = numsArr[0];
            for (int i = 1; i < arSize; i++)
            {
                if (numsArr[i] > max)
                {
                    max = numsArr[i];
                }

                if (numsArr[i] < min)
                {
                    min = numsArr[i];
                }
            }
            Console.WriteLine("Min: " + min + " - " + "Max: " + max);
            #endregion

            #region 24 - Write a program in C# Sharp to find the second largest element in an array.
            Console.WriteLine("Enter size of array");
            int numSize = Convert.ToInt32(Console.ReadLine());
            int[] numbersArr = new int[numSize];

            Console.WriteLine("Enter array elements");
            for (int i = 0; i < numSize; i++)
            {
                numbersArr[i] = Convert.ToInt32(Console.ReadLine());

            }
            if (numbersArr.Length < 2)
            {
                Console.WriteLine("Array has less than two elements");
            }
            else
            {

                int maxElem = int.MinValue;
                int secLargElem = int.MinValue;

                foreach (int elem in numbersArr)
                {
                    if (elem > maxElem)
                    {
                        secLargElem = maxElem;
                        maxElem = elem;
                    }
                    else if (elem > secLargElem && elem != maxElem)
                    {
                        secLargElem = elem;
                    }
                }

                Console.WriteLine("Second largest element : " + secLargElem);
            }
            #endregion


            #region 25 - write a program find the longest distance between Two equal cells.
            Console.WriteLine("Enter size of array");
            int s = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[s];

            Console.WriteLine("Enter array elements");
            for (int i = 0; i < s; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());

            }
            int maxDist = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        int dist = j - i - 1;
                        if (dist > maxDist)
                        {
                            maxDist = dist;
                        }
                    }
                }

            }
            Console.WriteLine("Max distance : " + maxDist);
            #endregion

            #region 26 - Given a list of space separated words, reverse the order of the words.
            Console.WriteLine("Enter a string");
            string str = Console.ReadLine();
            string[] words = str.Split(' ');
            Array.Reverse(words);
            string revStr = string.Join(" ", words);
            Console.WriteLine(revStr);
            #endregion

            #region 27 - Write a program to create two multidimensional arrays of same size. Accept value from user and store them in first array. Now copy all the elements of first array on second array and print second array.
            Console.WriteLine("Enter array dimensions (rows and cols)");
            int rowNum = Convert.ToInt32(Console.ReadLine());
            int colNum = Convert.ToInt32(Console.ReadLine());

            int[,] orgArr = new int[rowNum, colNum];
            int[,] copyArr = new int[rowNum, colNum];


            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    Console.WriteLine($"Enter element [{i},{j}]");
                    orgArr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Array.Copy(orgArr, copyArr, orgArr.Length);
            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    Console.Write(copyArr[i, j] + " ");
                }
                Console.WriteLine();
            }
            #endregion

            #region 28- Write a Program to Print One Dimensional Array in Reverse Order
            Console.WriteLine("Enter size of array");
            int orSize = Convert.ToInt32(Console.ReadLine());
            int[] originArr = new int[orSize];

            Console.WriteLine("Enter array elements");
            for (int i = 0; i < orSize; i++) { 
                originArr[i] = Convert.ToInt32(Console.ReadLine());

            }
            for (int i = orSize-1;i >= 0; i--) {
                Console.WriteLine(originArr[i]);

            }
            #endregion
        }
    }
    }
