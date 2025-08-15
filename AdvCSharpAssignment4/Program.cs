using static AdvCSharpAssignment4.BookFunctions;

namespace AdvCSharpAssignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using user defined delegate: ");
            string[] authors = { "Jhon", "Liam" };
            Book book = new Book("1256", "C# programming", authors, new DateTime(2025, 8, 15), 150);
            BookGettersDelegate bookGettersDelegate;
            bookGettersDelegate = BookFunctions.GetTitle;
            string title = bookGettersDelegate(book);
            Console.WriteLine("Title: " + title);

            bookGettersDelegate += BookFunctions.GetAuthors;
            string auth = bookGettersDelegate(book);
            Console.WriteLine("Authors: " + auth);

            Console.WriteLine("-------------------------------------");

            Console.WriteLine("Using bulit in delegate: ");
            Func<Book, string> getPriceDelegate = BookFunctions.GetPrice;
            string price = getPriceDelegate(book);
            Console.WriteLine("Price: " + price);

            Func<Book, string> getAuthorsDelegate = BookFunctions.GetAuthors;
            string author = getAuthorsDelegate(book);
            Console.WriteLine("Authors: " + author);

            string isbn = BookFunctions.GetISBN(book);
            Console.WriteLine("ISBN: " + isbn);

            DateTime date = BookFunctions.GetPublicationDate(book);
            Console.WriteLine("Publication Date: " + date.ToString());

            Console.WriteLine("-------------------------------------");
            List<Book> books = new List<Book>{ 
                new Book("456", "C# Guide", new string[] { "Hana" }, new DateTime(2024, 5, 1), 200),
                new Book("987", "Advanced C#", new string[] { "Mariam" }, new DateTime(2023, 8, 15), 500)
            };
            Console.WriteLine("Library Engine: ");
            Console.WriteLine("Titles: ");
            LibraryEngine.ProcessBooks(books, BookFunctions.GetTitle);

            Console.WriteLine("Authors: ");
            LibraryEngine.ProcessBooks(books, BookFunctions.GetAuthors);

            Console.WriteLine("Prices: ");
            LibraryEngine.ProcessBooks(books, BookFunctions.GetPrice);

        }



    }
}
