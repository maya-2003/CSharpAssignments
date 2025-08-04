using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace advancedAssignment1Project
{
    internal class Range<T> where T : IComparable<T>, INumber<T>
    {
        private T min;
        private T max;
        public T MAx { get { return max; } set { max = value; } }
        public T Min { get { return min; } set {  min = value; } }

        public Range(T min, T max)
        {
            this.min = min;
            this.max = max;
        }

        public bool IsInRange(T value)
        {
            if (value == null) return false;

            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }

        public T Length()
        {
            return max - min;
        }
    }
}
