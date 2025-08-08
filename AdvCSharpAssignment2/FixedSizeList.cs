using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvCSharpAssignment2
{
    internal class FixedSizeList<T>
    {

        private int capacity;
        private readonly List<T> fixedList;

        public int Capacity
        {
            get { return capacity; }
        }

        public FixedSizeList(int cap)
        {
            if (cap < 0)
                throw new ArgumentException("Capacity should be greater a positive number");
            capacity = cap;
            fixedList = new List<T>(capacity);
        }
        public FixedSizeList(): this(2) 
        { }

        public void Add(T value)
        {
            if (fixedList.Count >= capacity)
                throw new InvalidOperationException("The List is full and the item can not be added");

            fixedList.Add(value);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= fixedList.Count)
                throw new ArgumentOutOfRangeException("Index is out of range.");

            return fixedList[index];
        }

        public override string ToString()
        {
            return string.Join(", ", fixedList);
        }

    }
}
