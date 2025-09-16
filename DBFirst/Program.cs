using DBFirst.Models;

namespace DBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using NorthwindContext context = new NorthwindContext();
            var res = context.Procedures.SelectAllCategoriesAsync().Result;
            foreach (var item in res)
            {
                Console.WriteLine(item.CategoryName);
            }

            NorthwindContextProcedures contextProcedures =  new NorthwindContextProcedures(context);
            var res2 = contextProcedures.SalesByCategoryAsync("Beverages", "2018").Result;
            foreach (var item in res2)
            {
                Console.WriteLine($"{item.ProductName} - {item.TotalPurchase}");
            }
        }
    }
}
