namespace AdvCSharpAssignment3
{
    internal class Program
    {

        #region 2. Implement a function to check if a string of parentheses is balanced using a stack.
        public static bool CheckParenthesesBalance(String str) { 
            Stack<char> charsSatck = new Stack<char>();
            foreach (char element in str.ToCharArray()) {
                if (element == '(' || element == '{' || element == '[')
                {
                    charsSatck.Push(element);
                }

                else if (element == ')' && charsSatck.Count != 0 && (char)charsSatck.Peek() == '(')
                {
                    charsSatck.Pop();
                }
                else if (element == '}' && charsSatck.Count != 0 && (char)charsSatck.Peek() == '{')
                {
                    charsSatck.Pop();
                }
                else if (element == ']' && charsSatck.Count != 0 && (char)charsSatck.Peek() == '[')
                {
                    charsSatck.Pop();
                }
                else
                {
                    return false;
                }
            }
            return charsSatck.Count == 0;
        }
        #endregion


        static void Main(string[] args)
        {
            #region 1. implement a function to reverse the elements of a queue using a stack.Given a Queue
            Queue<double> initQueue = new Queue<double>();
            initQueue.Enqueue(5.6);
            initQueue.Enqueue(4.2);
            initQueue.Enqueue(8.3);
            Console.Write("Original queue: ");
            foreach (var item in initQueue)
                Console.Write(item + " ");
            Console.WriteLine();

            Helper.ReverseQueue(initQueue);
            Console.Write("Reversed queue: ");
            foreach (var item in initQueue)
                Console.Write(item + " ");
            Console.WriteLine();
            #endregion

            #region 2. Implement a function to check if a string of parentheses is balanced using a stack.

            String str = "([{}]";
            if (CheckParenthesesBalance(str))
            {
                Console.WriteLine("Balanced");
            }
            else
            {
                Console.WriteLine("Not balanced");
            }
            
            #endregion

        }
    }
}
