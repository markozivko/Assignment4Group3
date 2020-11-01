using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Assignment4Group3
{
    public class DataService
    {

        private readonly string _connectionString;
        public DataService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IList<Product> GetProducts()
        {
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.Products
                .Include(x => x.Category)
                .ToList();
        }
        public Product GetProduct(int id)
        {
            using var ctx = new DatabaseContext(_connectionString);

            return ctx.Products
               .Where(p => p.ProductId == id)
               .Include(x => x.Category)
               .FirstOrDefault();
        }
        public IList<OrderDetails> OrderDetails()
        {
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.OrderDetails
                .Include(x => x.Product)
                .ToList();
        }

       

        public Order GetOrder(int id)
        {
            //missing natural join with order details in order to show all data
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.Orders
               .Include(o => o.OrderDetails)
               .Where(o => o.Id == id)
               .FirstOrDefault();
            
        }

        public Order GetOrderByShippingName(string shippingName)
        {
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.Orders
                .FromSqlRaw($"select * from orders where shipname like \'%{shippingName}\'").FirstOrDefault();
        }

        public IList<Order> GetOrders()
        {
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.Orders
                .ToList();
        }

        public IList<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.OrderDetails
                .Where(o => o.OrderId == id)
                .Include(x => x.Product)
                .ToList(); 
        }

        public IList<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.OrderDetails
                .Where(o => o.ProductId == id)
                .Include(x => x.Product)
                .ToList();
        }



        public IList<Product> GetProductByName(string prodName)
        {
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.Products
                .FromSqlRaw($"select * from products where productname like \'%{prodName}%\'")
                .Include(x => x.Category)
                .ToList();
        }

        public IList<Product> GetProductByCategory(int id)
        {
            using var ctx = new DatabaseContext(_connectionString);
            
            return ctx.Products
                .Where(p => p.CategoryId == id)
                .Include(x => x.Category)
                .ToList();
        }

        public Category GetCategory(int id)
        {
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.Categories
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public IList<Category> GetCategories()
        {
            using var ctx = new DatabaseContext(_connectionString);
            return ctx.Categories
                .ToList();
        }
        public Category CreateCategory(string name, string description) 
        {
            using var ctx = new DatabaseContext(_connectionString);
            var currentId = ctx.Categories.Max(x => x.Id);
            ctx.Categories.Add(new Category {Id = currentId +1, Name = name, Description = description  });
            ctx.SaveChanges();
            return GetCategory(currentId + 1);
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            using var ctx = new DatabaseContext(_connectionString);
            var category = ctx.Categories.Find(id);
            if (category != null)
            {
                category.Name = name;
                category.Description = description;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCategory(int id)
        {
            using var ctx = new DatabaseContext(_connectionString);
            var category = ctx.Categories.Find(id);
            if(category!= null)
            {
                ctx.Categories.Remove(category);
                ctx.SaveChanges();
                return true;
            }
            return false;
            
        }
    }
}
