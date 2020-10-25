using System;

namespace Assignment4Group3
{
    class Program
    {
        static void Main(string[] args)
        {

            using var context = new DatabaseContext();
            var dataService = new DataService();

            foreach (var orderd in context.OrderDetails)
            {
                Console.WriteLine(orderd);
            }

            //foreach (var x in dataService.GetProducts())
            //{
            //    Console.WriteLine(x);
            //}
        }
    }
}
