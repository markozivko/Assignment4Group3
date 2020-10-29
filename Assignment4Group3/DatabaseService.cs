using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Assignment4Group3
{
    public class DataService
    {

        public IList<Product> GetProducts()
        {
            using var ctx = new DatabaseContext();
            return ctx.Products
                .Include(x => x.Category)
                .ToList();
        }

        public IList<OrderDetail> GetOrderDetails()
        {
            using var ctx = new DatabaseContext();
            return ctx.OrderDetails
                .Include(x => x.Product)
                .ToList();
        }


        public Order GetOrder(int id)
        {
            //missing natural join with order details in order to show all data
            using var ctx = new DatabaseContext();
            return ctx.Orders
                .FromSqlRaw($"select * from orders where orderid = {id}").FirstOrDefault();
        }

        public Order GetOrderByShippingName(string shippingName)
        {
            using var ctx = new DatabaseContext();
            return ctx.Orders
                .FromSqlRaw($"select * from orders where shipname like \'%{shippingName}\'").FirstOrDefault();
        }

        public IList<Order> GetOrders()
        {
            using var ctx = new DatabaseContext();
            return ctx.Orders
                .ToList();
        }

        public IList<OrderDetail> GetOrderDetailsByOrderId(int id)
        {
            using var ctx = new DatabaseContext();
            return ctx.OrderDetails
                .FromSqlRaw($"select orderid, productid, unitprice, quantity, discount from orderdetails where orderid = {id}")
                .Include(x => x.Product)
                .ToList();
                
        }

        public IList<OrderDetail> GetOrderDetailsByProductId(int id)
        {
            using var ctx = new DatabaseContext();
            return ctx.OrderDetails
                .FromSqlRaw($"select orderid, productid, unitprice, quantity, discount from orderdetails where productId = {id}")
                .Include(x => x.Product)
                .ToList();
        }

        public IList<Product> GetProduct(int id)
        {
            //missing natural join with order details in order to show all data
            using var ctx = new DatabaseContext();
            return ctx.Products
                .FromSqlRaw($"select * from products where productid = {id}")
                .Include(x => x.Category)
                .ToList();
        }

        public IList<Product> GetProductByName(string prodName)
        {
            using var ctx = new DatabaseContext();
            return ctx.Products
                .FromSqlRaw($"select * from products where productname like \'%{prodName}%\'")
                .Include(x => x.Category)
                .ToList();
        }

        public IList<Product> GetProductByCategory(int id)
        {
            using var ctx = new DatabaseContext();
            return ctx.Products
                .FromSqlRaw($"select * from products where categoryId = {id}")
                .Include(x => x.Category)
                .ToList();
        }

        public Category GetCategory(int id)
        {
            using var ctx = new DatabaseContext();
            return ctx.Categories
                .FromSqlRaw($"select * from categories where categoryid = {id}").FirstOrDefault();
        }

        public IList<Category> GetCategories()
        {
            using var ctx = new DatabaseContext();
            return ctx.Categories
                .ToList();
        }
    }
}
