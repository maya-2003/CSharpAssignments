using System.Collections.Generic;
using System.Threading;
using static LinqAssignment1.ListGenerator;
namespace LinqAssignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstProduc = from P in ProductList
                              where P.UnitsInStock == 0 && P.Category == "Meat/Poultry"
                              select P;

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

            ///////////////// LINQ - Ordering Operators

            #region 1. Sort a list of products by name
            var sortedProducts = ProductList.OrderBy(prod => prod.ProductName);
            Console.WriteLine("Sorted products:");
            foreach (var p in sortedProducts)
            {
                Console.WriteLine(p);
            }
            #endregion

            #region 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            String[] Arr4 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedArr = Arr4.OrderBy(word => word, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Case-insensitive sorted words: ");
            foreach (var str in sortedArr)
            {
                Console.WriteLine(str);
            }
            #endregion

            #region 3. Sort a list of products by units in stock from highest to lowest.
            var sortedProductsUnits = ProductList.OrderByDescending(prod => prod.UnitsInStock);
            Console.WriteLine("Sorted products by units in stock from highest to lowest:");
            foreach (var p in sortedProductsUnits)
            {
                Console.WriteLine(p);
            }
            #endregion

            #region 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            string[] Arr5 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var sortedDigits = Arr5.OrderBy(digit => digit.Length)
                                    .ThenBy(digit => digit);
            Console.WriteLine("Sorted digits: ");
            foreach (var digit in sortedDigits)
            {
                Console.WriteLine(digit);
            }
            #endregion

            #region 5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            String[] Arr6 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords = Arr6.OrderBy(word => word.Length)
                                  .ThenBy(word => word, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Sorted words first by-word length and then by a case-insensitive sort: ");
            foreach (var str in sortedWords)
            {
                Console.WriteLine(str);
            }
            #endregion

            #region 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            var sortedProductsCatgePrice = ProductList.OrderBy(prod => prod.Category)
                                                      .ThenByDescending(prod => prod.UnitPrice);
            Console.WriteLine("Sorted products by first by category, and then by unit price, from highest to lowest:");
            foreach (var prod in sortedProductsCatgePrice)
            {
                Console.WriteLine(prod);
            }
            #endregion

            #region 7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            String[] Arr7 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords2 = Arr7.OrderBy(word => word.Length)
                                  .ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Sorted words first by-word length and then by a case-insensitive descending sort: ");
            foreach (var str in sortedWords2)
            {
                Console.WriteLine(str);
            }
            #endregion

            #region 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arr8 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var digitsSublist = Arr8.Where(digit => digit[1] == 'i').Reverse().ToList();
            Console.WriteLine("Digits sublist: ");
            foreach (var digit in digitsSublist)
            {
                Console.WriteLine(digit);
            }
            #endregion

            ////////// LINQ – Transformation Operators

            #region 1. Return a sequence of just the names of a list of products.
            var productsNames = from p in ProductList
                                select p.ProductName;
            Console.WriteLine("Products Names: ");
            foreach (var name in productsNames)
            {
                Console.WriteLine(name);
            }
            #endregion

            #region 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            String[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var wordsVersions = from w in words
                                select new
                                {
                                    UppercaseVersion = w.ToUpper(),
                                    LowercaseVersion = w.ToLower(),
                                };
            Console.WriteLine("Words versions: ");
            foreach (var word in wordsVersions)
            {
                Console.WriteLine(word);
            }
            #endregion

            #region 3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            var prodData = from p in ProductList
                           select new
                           {
                               p.ProductID,
                               p.ProductName,
                               Price = p.UnitPrice
                           };

            Console.WriteLine("Products data:");
            foreach (var prod in prodData)
            {
                Console.WriteLine(prod);
            }
            #endregion

            #region 4. Determine if the value of int in an array matches their position in the array.
            int[] nums = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var numbers = nums.Select((num, i) => new
            {
                Value = num,
                IsCorrectPos = (num == i)
            });
            Console.WriteLine("Numbers:");
            foreach (var num in numbers)
            {
                Console.WriteLine($"{num.Value}: {num.IsCorrectPos}");
            }
            #endregion

            #region 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var numsSublist = from numsA in numbersA
                              from numsB in numbersB
                              where numsA < numsB
                              select new
                              {
                                  First = numsA,
                                  Second = numsB
                              };

            Console.WriteLine("Numbers Pairs:");
            foreach (var n in numsSublist)
            {
                Console.WriteLine($"{n.First} is less than {n.Second}");
            }
            #endregion

            #region 6. Select all orders where the order total is less than 500.00.
            var orders = from cust in CustomerList
                         from ord in (cust.Orders ?? Array.Empty<Order>())
                         where ord.Total < 500m
                         select new
                         {
                             cust.CustomerID,
                             cust.CustomerName,
                             ord.OrderID,
                             ord.OrderDate,
                             Total = ord.Total
                         };

            Console.WriteLine("Orders:");
            foreach (var ord in orders)
            {
                Console.WriteLine(ord);
            }
            #endregion

            #region 7. Select all orders where the order was made in 1998 or later.
            var newORders = from cust in CustomerList
                                          select new
                                          {
                                              cust.CustomerID,
                                              cust.CustomerName,
                                              OrdersAfter1998 = (from ord in cust.Orders
                                                              where ord.OrderDate.Year >= 1998
                                                              select ord).ToList()
                                          };

            Console.WriteLine("Orders:");
            foreach (var cust in newORders)
            {
                foreach (var ord in cust.OrdersAfter1998)
                {
                    Console.WriteLine($"{cust.CustomerName} | order id: {ord.OrderID} - {ord.OrderDate}");
                }
            }
            #endregion




        }
    }
}
