using System;
using Microsoft.EntityFrameworkCore;
namespace Assignment4Group3
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=marko");
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
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(x => x.SupplierId).HasColumnName("supplierid");
            modelBuilder.Entity<Product>().Property(x => x.UnitQuantity).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(x => x.UnitStock).HasColumnName("unitsinstock");

            //Order table
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(x => x.DateOrder).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(x => x.DateRequired).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(x => x.DateShipped).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(x => x.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");

            //Order Details table
            modelBuilder.Entity<OrderDetail>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetail>().Property(x => x.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetail>().Property(x => x.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetail>().Property(x => x.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetail>().Property(x => x.ProductId).HasColumnName("productid");

        }
    }
}
