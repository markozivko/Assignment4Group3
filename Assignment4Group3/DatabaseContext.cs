using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment4Group3
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString;
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        // Log into the console all the queries
        public static readonly ILoggerFactory MyLoggerFactory 
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Categories table
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");

            //Products table
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.ProductId).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(x => x.SupplierId).HasColumnName("supplierid");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName("unitsinstock");

            //Order table
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(x => x.Required).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(x => x.DateShipped).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(x => x.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");
            //modelBuilder.Entity<Order>().HasMany(x => x.OrderDetails).WithOne

            //Order Details table
            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>().Property(x => x.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetails>().Property(x => x.ProductId).HasColumnName("productid");
            //modelBuilder.Entity<OrderDetails>().HasMany(x => x.Order);
        }
    }
}
