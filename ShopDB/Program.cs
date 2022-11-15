using ShopDB.DBInitializers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ShopDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var infrastructure = new Infrastructure(ShopDBContext.CreateInstance());

            Console.WriteLine("Enter the comment of the product:");
            string comment = Console.ReadLine();

            Console.WriteLine("Enter productCategoryId to the wished product: ");
            int productCategoryId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter year, month and day of the comparance: ");
            string[] time = Console.ReadLine().Split();
            DateTime date = new DateTime(int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));

            infrastructure
                            .GetProductAsync(comment)
                            .ContinueWith(t =>
                            {
                                if (t.Result != null)
                                {
                                    Console.WriteLine($"Id: {t.Result.Id}\nComment: {t.Result.Comment}");
                                }
                                else
                                    throw new NullReferenceException("There is no product with such comment!");

                            });

            infrastructure
                            .GetSortedPeopleAsync()
                            .ContinueWith(t =>
                            {
                                Console.WriteLine("Async iteration has been completed!");
                            });

            infrastructure
                            .GetProductsFromCategoryAsync(productCategoryId)
                            .ContinueWith(t =>
                            {
                                var products = t.Result;

                                foreach (var product in products)
                                {
                                    Console.WriteLine($"Id: {product.Id}\nComment: {product.Comment}");
                                }
                            });


            infrastructure
                            .GetTotalPriceAsync()
                            .ContinueWith(t =>
                            {
                                Console.WriteLine("Result: {0}", t.Result);
                            });

            infrastructure
                            .GetPeopleOlderThanDateAsync(date)
                            .ContinueWith(t =>
                            {
                                var people = t.Result;
                                foreach (var p in people)
                                    Console.WriteLine($"Id: {p.Id},\nName: {p.Name + " " + p.Surname}");
                            });

            Console.ReadKey();
        }
    }
}
