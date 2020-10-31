using Microsoft.Extensions.Configuration;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace Assignment4Group3
{
    class Program
    {
        static void Main(string[] args)
        {
            //secure the databas elogin by creating a json file with the user id and pwd
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
         
            using var context = new DatabaseContext(config["connectionString"]);
            var dataService = new DataService(config["connectionString"]);

            // Order #1
            //var order = dataService.GetOrder(10500);
            //Console.WriteLine($"order id: {order.Id} \n" +
            //                  $"order date: {order.Date.Year}-{order.Date.Month}-{order.Date.Day}\n" +
            //                  $"date shipped: {order.DateShipped.Year}-{order.DateShipped.Month}-{order.DateShipped.Day}\n" +
            //                  $"date required: {order.Required.Year}-{order.Required.Month}-{order.Required.Day}\n" +
            //                  $"freight: {order.Required.Year}-{order.Required.Month}-{order.Required.Day}\n" +
            //                  $"ship name: {order.ShipName} \n" +
            //                  $"ship city: {order.ShipCity} \n");

            //Console.WriteLine("======================================================");


            //Order #2

            //var order = dataService.GetOrderByShippingName("North/South");
            //Console.WriteLine($"order id: {order.Id} \n" +
            //                  $"order date: {order.Date.Year}-{order.Date.Month}-{order.Date.Day}\n" +
            //                  $"date shipped: {order.DateShipped.Year}-{order.DateShipped.Month}-{order.DateShipped.Day}\n" +
            //                  $"date required: {order.Required.Year}-{order.Required.Month}-{order.Required.Day}\n" +
            //                  $"freight: {order.Required.Year}-{order.Required.Month}-{order.Required.Day}\n" +
            //                  $"ship name: {order.ShipName} \n" +
            //                  $"ship city: {order.ShipCity}");

            //Console.WriteLine("======================================================");


            //Order #3

            //partially working
            //returns list of all orders but also throws an exception that there is an EMPTY calumn somewhere
            //foreach (var order3 in context.Orders)
            //{
            //    Console.WriteLine(order3);
            //}

            //Console.WriteLine("======================================================");


            //Order details #4
            //var orderDetail = dataService.GetOrderDetailsByOrderId(10748);
            //Console.WriteLine($"Order id: {orderDetail[0].OrderId}, Product Name: {orderDetail[0].Product.Name}, Price: {orderDetail[0].UnitPrice}, Quanitity: {orderDetail[0].Quantity}");

            //Console.WriteLine("======================================================");

            //Order details #5
            //var orderDetail = dataService.GetOrderDetailsByProductId(69);

            //foreach (var x in orderDetail)
            //{
            //    Console.WriteLine($"Order id: {x.OrderId}, Product Name: {x.Product.Name}, Price: {x.UnitPrice}, Quanitity: {x.Quantity}");

            //}

            //Product #6
            Console.WriteLine("======================================================");

          //  I don't know how to include x.Category -> we are returning single Product and not a list
            var product = dataService.GetProduct(1);
            Console.WriteLine(
                              $"name: {product.Name} " +
                              $"price: {product.UnitPrice} " +
                              $"category: {product.Category.Name}");

            //Product #7

            //var product = dataService.GetProductByName("Ch");
            //foreach (var x in product)
            //{
            //    Console.WriteLine($"Product: {x.Name}, Category: {x.Category.Name}");
            //}

            //Product #8

            //Console.WriteLine("======================================================");

            //var product2 = dataService.GetProductByCategory(1);
            //foreach (var x in product2)
            //{
            //    Console.WriteLine($"ProductId: {x.Id}, " +
            //                      $"name: {x.Name}, " +
            //                      $"price: {x.UnitPrice}, " +
            //                      $"category: {x.Category.Name}");
            //}

            //Category #9
            // we need to check what happens if ID does not exist
            //Console.WriteLine("======================================================");
            //var category = dataService.GetCategory(1);
            //Console.WriteLine($"Category name: {category.Name}");

            //Category 10
            //Console.WriteLine("======================================================");

            //var category2 = dataService.GetCategories();
            //foreach (var x in category2)
            //{
            //    Console.WriteLine($"Id: {x.Id} Name: {x.Name} Description: {x.Description} ");
            //}

            //Question 11
            //dataService.RemoveCategory(9) ;
            //foreach(var el in dataService.GetCategories())
            //{
            //    Console.WriteLine(el);
            //}
          
        }
    }
}
