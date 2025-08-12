using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvCSharpAssignment3
{
    internal class Helper
    {

        #region 1. implement a function to reverse the elements of a queue using a stack.Given a Queue
        public static void ReverseQueue<T>(Queue<T> initQueue)
        {
            Stack<T> revSatck = new Stack<T>();

            while (initQueue.Count > 0)
            {
                revSatck.Push(initQueue.Dequeue());
            }

            while (revSatck.Count > 0)
            {
                initQueue.Enqueue(revSatck.Pop());
            }
        }
        #endregion
    }
}
