using Assignment4Group3;
using System;
using System.Linq;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace Assignment4Tests
{
    public class DataServiceTests
    {
        /* Categories */
        private readonly string _connectionString;
        public DataServiceTests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
            _connectionString = config["connectionString"];
        }
        [Fact]
        public void Category_Object_HasIdNameAndDescription()
        {
            var category = new Category();
            Assert.Equal(0, category.Id);
            Assert.Null(category.Name);
            Assert.Null(category.Description);
        }

        [Fact]
        public void GetAllCategories_NoArgument_ReturnsAllCategories()
        {
            var service = new DataService(_connectionString);
            var categories = service.GetCategories();
            Assert.Equal(8, categories.Count);
            Assert.Equal("Beverages", categories.First().Name);
        }

        [Fact]
        public void GetCategory_ValidId_ReturnsCategoryObject()
        {
            var service = new DataService(_connectionString);
            var category = service.GetCategory(1);
            Assert.Equal("Beverages", category.Name);
        }

        [Fact]
        public void CreateCategory_ValidData_CreteCategoryAndRetunsNewObject()
        {
            var service = new DataService(_connectionString);
            var category = service.CreateCategory("Test", "CreateCategory_ValidData_CreteCategoryAndRetunsNewObject");
            Assert.True(category.Id > 0);
            Assert.Equal("Test", category.Name);
            Assert.Equal("CreateCategory_ValidData_CreteCategoryAndRetunsNewObject", category.Description);

            //cleanup
            service.DeleteCategory(category.Id);
        }

        [Fact]
        public void DeleteCategory_ValidId_RemoveTheCategory()
        {
            var service = new DataService(_connectionString);
            var category = service.CreateCategory("Test", "DeleteCategory_ValidId_RemoveTheCategory");
            var result = service.DeleteCategory(category.Id);
            Assert.True(result);
            category = service.GetCategory(category.Id);
            Assert.Null(category);
        }

        [Fact]
        public void DeleteCategory_InvalidId_ReturnsFalse()
        {
            var service = new DataService(_connectionString);
            var result = service.DeleteCategory(-1);
            Assert.False(result);
        }

        [Fact]
        public void UpdateCategory_NewNameAndDescription_UpdateWithNewValues()
        {
            var service = new DataService(_connectionString);
            var category = service.CreateCategory("TestingUpdate", "UpdateCategory_NewNameAndDescription_UpdateWithNewValues");

            var result = service.UpdateCategory(category.Id, "UpdatedName", "UpdatedDescription");
            Assert.True(result);

            category = service.GetCategory(category.Id);

            Assert.Equal("UpdatedName", category.Name);
            Assert.Equal("UpdatedDescription", category.Description);

            // cleanup
            service.DeleteCategory(category.Id);
        }

        [Fact]
        public void UpdateCategory_InvalidID_ReturnsFalse()
        {
            var service = new DataService(_connectionString);
            var result = service.UpdateCategory(-1, "UpdatedName", "UpdatedDescription");
            Assert.False(result);
        }


        /* products */

        [Fact]
        public void Product_Object_HasIdNameUnitPriceQuantityPerUnitAndUnitsInStock()
        {
            var product = new Product();
            Assert.Equal(0, product.ProductId);
            Assert.Null(product.ProductName);
            Assert.Equal(0.0, product.UnitPrice);
            Assert.Null(product.QuantityPerUnit);
            Assert.Equal(0, product.UnitsInStock);
        }

        [Fact]
        public void GetProduct_ValidId_ReturnsProductWithCategory()
        {
            var service = new DataService(_connectionString);
            var product = service.GetProduct(1);
            Assert.Equal("Chai", product.ProductName);
            Assert.Equal("Beverages", product.Category.Name);
        }

        [Fact]
        public void GetProductsByCategory_ValidId_ReturnsProductWithCategory()
        {
            var service = new DataService(_connectionString);
            var products = service.GetProductByCategory(1);
            Assert.Equal(12, products.Count);
            Assert.Equal("Chai", products.First().ProductName);
            Assert.Equal("Beverages", products.First().Category.Name);

            //Mistake it not CategoryName -> Category.Name is correct
            Assert.Equal("Beverages", products.First().Category.Name);

            //Mistake -> we had to add missing simbols for name Lakkalikööri
            //Lakkalik??ri
            Assert.Equal("Lakkalikööri", products.Last().ProductName);
        }

        [Fact]
        public void GetProduct_NameSubString_ReturnsProductsThatMachesTheSubString()
        {
            var service = new DataService(_connectionString);
            var products = service.GetProductByName("em");
            Assert.Equal(4, products.Count);
            //Mistake -> we had to add missing simbols for name Nuß
            Assert.Equal("NuNuCa Nuß-Nougat-Creme", products.First().ProductName);
            Assert.Equal("Flotemysost", products.Last().ProductName);

            //shouldn't it be retreived like this:
            Assert.Equal("NuNuCa Nuß-Nougat-Creme", products.First().ProductName);
            Assert.Equal("Flotemysost", products.Last().ProductName);
        }

        /* orders */
        [Fact]
        public void Order_Object_HasIdDatesAndOrderDetails()
        {
            var order = new Order();
            Assert.Equal(0, order.Id);
            Assert.Equal(new DateTime(), order.Date);
            Assert.Equal(new DateTime(), order.Required);
            Assert.Null(order.OrderDetails);
            Assert.Null(order.ShipName);
            Assert.Null(order.ShipCity);
        }

        [Fact]
        public void GetOrder_ValidId_ReturnsCompleteOrder()
        {
            var service = new DataService(_connectionString);
            var order = service.GetOrder(10248);
           Assert.Equal(3, order.OrderDetails.Count);
            Assert.Equal("Queso Cabrales", order.OrderDetails.First().Product.ProductName);
            Assert.Equal("Dairy Products", order.OrderDetails.First().Product.Category.Name);
        }

        [Fact]
        public void GetOrders()
        {
            var service = new DataService(_connectionString);
            var orders = service.GetOrders();
            Assert.Equal(830, orders.Count);
        }


        ///* orderdetails */
        //[Fact]
        //public void OrderDetails_Object_HasOrderProductUnitPriceQuantityAndDiscount()
        //{
        //    var orderDetails = new OrderDetails();
        //    Assert.Equal(0, orderDetails.OrderId);
        //    //Assert.Null(orderDetails.Order);
        //    Assert.Equal(0, orderDetails.ProductId);
        //    Assert.Null(orderDetails.Product);
        //    Assert.Equal(0.0, orderDetails.UnitPrice);
        //    Assert.Equal(0.0, orderDetails.Quantity);
        //    Assert.Equal(0.0, orderDetails.Discount);
        //}

        //[Fact]
        //public void GetOrderDetailByOrderId_ValidId_ReturnsProductNameUnitPriceAndQuantity()
        //{
        //    var service = new DataService(_connectionString);
        //    var orderDetails = service.GetOrderDetailsByOrderId(10248);
        //    Assert.Equal(3, orderDetails.Count);
        //    Assert.Equal("Queso Cabrales", orderDetails.First().Product.ProductName);
        //    Assert.Equal(14, orderDetails.First().UnitPrice);
        //    Assert.Equal(12, orderDetails.First().Quantity);
        //}

        //[Fact]
        //public void GetOrderDetailByProductId_ValidId_ReturnsOrderDateUnitPriceAndQuantity()
        //{
        //    var service = new DataService(_connectionString);
        //    var orderDetails = service.GetOrderDetailsByProductId(11);
        //    Assert.Equal(38, orderDetails.Count);
        //    //Assert.Equal("1997-05-06", orderDetails.First().Order.Date.ToString("yyyy-MM-dd"));
        //    Assert.Equal(21, orderDetails.First().UnitPrice);
        //    Assert.Equal(3, orderDetails.First().Quantity);
        //}
    }
}
