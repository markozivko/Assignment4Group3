using System;

namespace Assignment4Group3
{
    class Program
    {
        static void Main(string[] args)
        {

            using var context = new DatabaseContext();
            var dataService = new DataService();

            foreach (var product in context.Products)
            {
                Console.WriteLine(product);
            }

            //foreach (var x in dataService.GetProducts())
            //{
            //    Console.WriteLine(x);
            //}
        }
    }
}
