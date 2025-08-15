using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvCSharpAssignment4
{
    internal class LibraryEngine
    {
        #region You need to parameterize ProcessBooks function
        public static void ProcessBooks <T> (List<Book> bList, Func<Book, T> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
        #endregion
    }
}
