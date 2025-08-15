using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AdvCSharpAssignment4
{
    internal class BookFunctions
    {
        #region b) Use the Proper build in delegate c) Anonymous Method(GetISBN) d) Lambda Expression(GetPublicationDate)
        public static Func<Book, string> GetISBN = delegate (Book B) { return B.ISBN; };
        public static Func<Book, DateTime> GetPublicationDate = B => B.PublicationDate;
        #endregion

        #region a) Create User Defined Delegate with the same signature of methods existed in Bookfunctions class.

        public delegate string BookGettersDelegate(Book B);
        public static string GetTitle(Book B)
        {
            return B.Title;
        }
        public static string GetAuthors(Book B)
        {
            return string.Join(", ", B.Authors);
        }
        public static string GetPrice(Book B)
        {
            return B.Price.ToString();
        }
        #endregion
    }
}
