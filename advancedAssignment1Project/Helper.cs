using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advancedAssignment1Project
{
    internal static class Helper<T> where T : IComparable<T>
    {
        public static void Swap(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        #region 1. How we can optimize the Bubble Sort algorithm And implement the code of this optimized bubble sort algorithm
        public static void BubbleSort(T[] array)
        {
            if (array != null)
            {
                bool swapped;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    swapped = false;
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].CompareTo(array[j + 1]) > 0)
                        {
                            Swap(ref array[j], ref array[j + 1]);
                            swapped = true;
                        }
                    }
                    if (!swapped)
                        break;
                }
            }
        }
        #endregion
    }
}
