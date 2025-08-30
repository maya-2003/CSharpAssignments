using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using static LINQAssignment02.ListGenerators;
using static System.Net.Mime.MediaTypeNames;
namespace LINQAssignment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///////////////// LINQ - Element Operators

            #region 1. Get first Product out of Stock 
            var firstProduct = ProductList.First(p => p.UnitsInStock == 0);
            Console.WriteLine($"First Product out of Stock: {firstProduct}");
            #endregion

            #region 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            var firstProduct2 = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine(firstProduct2 != null ? $"The first product whose Price > 1000: {firstProduct2}"
            : "No product found with Price > 1000.");
            #endregion


            #region 3. Retrieve the second number greater than 5 
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondNum = Arr.Where(x => x > 5).ElementAt(1);
            Console.WriteLine($"Second number greater than 5: {secondNum}");
            #endregion

            ///////////////// LINQ - Aggregate Operators

            #region 1. Uses Count to get the number of odd numbers in the array
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddNumbersCount = Arr2.Count(n => n % 2 != 0);
            Console.WriteLine($"Number of odd numbers: {oddNumbersCount}");
            #endregion

            #region 2. Return a list of customers and how many orders each has.
            var customerOrders = from cust in CustomerList
                                 where cust.Orders != null && cust.Orders.Any(ord => ord != null)
                                 select new
                                 {
                                     cust.CustomerName,
                                     OrdersCount = cust.Orders.Count(ord => ord != null)
                                 };
            Console.WriteLine("Customer order count:");
            foreach (var customerOrder in customerOrders)
            {
                Console.WriteLine(customerOrder);
            }
            #endregion

            #region 3. Return a list of categories and how many products each has
            var categProducts = from prod in ProductList
                                group prod by prod.Category into products
                                select new
                                {
                                    CategoryName = products.Key,
                                    ProductsCount = products.Count()
                                };
            Console.WriteLine("Categories product count:");
            foreach (var categ in categProducts)
            {
                Console.WriteLine(categ);
            }
            #endregion

            #region 4. Get the total of the numbers in an array.
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int arrSum = Arr3.Sum();
            Console.WriteLine($"Numbers sum: {arrSum}");
            #endregion

            string[] dictText = File.ReadAllLines("dictionary_english.txt");
            #region 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            int charsCount = dictText.Sum(word => word.Length);
            Console.WriteLine($"Total number of characters of all words: {charsCount}");
            #endregion


            #region 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            int minLen = dictText.Min(word => word.Length);
            Console.WriteLine($"Length of the shortest word in dictionary_english.txt: {minLen}");
            #endregion

            #region 7. Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            int maxLen = dictText.Max(word => word.Length);
            Console.WriteLine($"Length of the longest word in dictionary_english.txt: {maxLen}");
            #endregion

            #region 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            double avgLen = dictText.Average(word => word.Length);
            Console.WriteLine($"Average length of the words in dictionary_english.txt: {avgLen}");
            #endregion

            #region 9. Get the total units in stock for each product category.
            var categUnits = from prod in ProductList
                             group prod by prod.Category into products
                             select new
                             {
                                 CategoryName = products.Key,
                                 UnitsCount = products.Sum(p => p.UnitsInStock)
                             };
            Console.WriteLine("Total units in stock for each product category:");
            foreach (var categ in categUnits)
            {
                Console.WriteLine(categ);
            }
            #endregion

            #region 10. Get the cheapest price among each category's products
            var categMinPrices = from prod in ProductList
                                 group prod by prod.Category into products
                                 select new
                                 {
                                     CategoryName = products.Key,
                                     CheapestPrice = products.Min(prod => prod.UnitPrice)
                                 };

            Console.WriteLine("Cheapest price in each category:");
            foreach (var categ in categMinPrices)
            {
                Console.WriteLine(categ);
            }
            #endregion

            #region 11. Get the products with the cheapest price in each category (using let)
            var categCheapestProducts = from prod in ProductList
                                        group prod by prod.Category into Categs
                                        let cheapestPrice = Categs.Min(prod => prod.UnitPrice)
                                        select new
                                        {
                                            Category = Categs.Key,
                                            CheapestProducts = Categs.Where(pr => pr.UnitPrice == cheapestPrice)
                                        };

            Console.WriteLine("Products with the cheapest price in each category:");
            foreach (var categ in categCheapestProducts)
            {
                foreach (var prod in categ.CheapestProducts)
                {
                    Console.WriteLine($"{categ.Category} | {prod}");
                }
            }
            #endregion

            #region 12. Get the most expensive price among each category's products.
            var categMaxPrices = from prod in ProductList
                                 group prod by prod.Category into products
                                 select new
                                 {
                                     CategoryName = products.Key,
                                     ExpensivePrice = products.Max(prod => prod.UnitPrice)
                                 };

            Console.WriteLine("Most expensive price among each category's products:");
            foreach (var categ in categMaxPrices)
            {
                Console.WriteLine(categ);
            }
            #endregion

            #region 13. Get the products with the most expensive price in each category.
            var categMostExpensiveProducts = from prod in ProductList
                                             group prod by prod.Category into Categs
                                             let expenPrice = Categs.Max(prod => prod.UnitPrice)
                                             select new
                                             {
                                                 Category = Categs.Key,
                                                 MostExpensiveProducts = Categs.Where(pr => pr.UnitPrice == expenPrice)
                                             };

            Console.WriteLine("Products with the most expensive price in each category:");
            foreach (var categ in categMostExpensiveProducts)
            {
                foreach (var prod in categ.MostExpensiveProducts)
                {
                    Console.WriteLine($"{categ.Category} | {prod}");
                }
            }
            #endregion

            #region 14. Get the average price of each category's products.
            var categAvgPrices = from prod in ProductList
                                 group prod by prod.Category into products
                                 select new
                                 {
                                     CategoryName = products.Key,
                                     AvgPrice = products.Average(prod => prod.UnitPrice)
                                 };

            Console.WriteLine("Average price of each category's products:");
            foreach (var categ in categAvgPrices)
            {
                Console.WriteLine(categ);
            }
            #endregion

            /////////////// LINQ - Set Operators

            #region 1. Find the unique Category names from Product List
            var categNamesUniq = (from prod in ProductList
                                  select prod.Category).Distinct();
            foreach (var name in categNamesUniq)
            {
                Console.WriteLine(name);
            }
            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customer names.
            var firstLettersSeq = (from prod in ProductList
                                   select prod.ProductName[0])
                                   .Union
                                   (from cust in CustomerList
                                    select cust.CustomerName[0]);
            Console.WriteLine("Sequence containing the unique first letter from both product and customer names");
            foreach (var item in firstLettersSeq)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 3. Create one sequence that contains the common first letter from both product and customer names.
            var commonLettersSeq = (from prod in ProductList
                                   select prod.ProductName[0])
                                   .Intersect
                                   (from cust in CustomerList
                                    select cust.CustomerName[0]);
            Console.WriteLine("Sequence that contains the common first letter from both product and customer names");
            foreach (var item in commonLettersSeq)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var differentLettersSeq = (from prod in ProductList
                                    select prod.ProductName[0])
                                   .Except
                                   (from cust in CustomerList
                                    select cust.CustomerName[0]);
            Console.WriteLine("Sequence that contains the first letters of product names that are not also first letters of customer names");
            foreach (var item in differentLettersSeq)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            var threeCharSeq =from name in
                                   (from prod in ProductList select prod.ProductName) .Concat(from cust in CustomerList select cust.CustomerName)
                                   select name.Length >= 3 ? name.Substring(name.Length - 3) : name;

            Console.WriteLine("Sequence that contains the last Three Characters in each name of all customers and products, including any duplicates");
            foreach (var item in threeCharSeq)
            {
                Console.WriteLine(item);
            }
            #endregion

            /////////////// LINQ - Quantifiers

            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            bool conatinSub = dictText.Any(w => w.Contains("ei"));
            Console.WriteLine($"are there any of the words in dictionary_english.txt contain the substring 'ei' ? : {conatinSub}");
            #endregion

            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
            var categoriesWithOutOfStock = from prod in ProductList
                                           group prod by prod.Category into categs
                                           let outOfStockCategs = categs.Any(p => p.UnitsInStock == 0)
                                           where outOfStockCategs
                                           select new
                                           {
                                               Category = categs.Key,
                                               Products = categs.ToList()
                                           };

            Console.WriteLine("list of products only for categories that have at least one product that is out of stock:");
            foreach (var cat in categoriesWithOutOfStock) { 
                Console.WriteLine($"Category: {cat.Category}");
                foreach (var prod in cat.Products)
                {
                    Console.WriteLine(prod);
                }
            }
            #endregion

            #region 3. Return a grouped a list of products only for categories that have all of their products in stock.
            var categoriesWithoutOutOfStock = from prod in ProductList
                                           group prod by prod.Category into categs
                                           let outOfStockCategs = categs.All(p => p.UnitsInStock != 0)
                                           where outOfStockCategs
                                           select new
                                           {
                                               Category = categs.Key,
                                               Products = categs.ToList()
                                           };

            Console.WriteLine("list of products only for categories that have all of their products in stock:");
            foreach (var cat in categoriesWithoutOutOfStock)
            {
                Console.WriteLine($"Category: {cat.Category}");
                foreach (var prod in cat.Products)
                {
                    Console.WriteLine(prod);
                }
            }
            #endregion

            /////////////// LINQ – Grouping Operators

            #region 1. Use group by to partition a list of numbers by their remainder when divided by 5
            List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var partitionedList = numbers.GroupBy(num => num % 5);

            foreach (var partation in partitionedList){
                Console.WriteLine($"Numbers with remainder of {partation.Key} when divided by 5:");
                foreach (var n in partation)
                {
                    Console.WriteLine($"{n}");
                }
            }
            #endregion

            #region 2. Use group by to partition a list of words by their first letter. Use dictionary_english.txt for Input
            var wordsPartation = dictText.GroupBy(w => w[0]);
            //foreach (var partation in wordsPartation)
            //{
            //    Console.WriteLine($"words with {partation.Key} as the first letter:");
            //    foreach (var w in partation)
            //    {
            //        Console.WriteLine($"{w}");
            //    }
            //}
            #endregion

            #region 3. Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            String[] wordsArr = { "from", "salt", "earn", "last", "near", "form" };
            var groupedWords = wordsArr.GroupBy(w => w, new WordsComparer());
            foreach (var partation in groupedWords)
            {
                Console.WriteLine($"words consiting of letters {partation.Key}:");
                foreach (var w in partation)
                {
                    Console.WriteLine($"{w}");
                }
            }

            #endregion








        }
    }
}
