using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShopDB.Tests.DbAsyncQueryProvider;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using ShopDB.Services;

namespace ShopDB.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        private List<Product> products;

        [TestInitialize]
        public void TestInitialize()
        {
            products = new List<Product>
            {
                new Product() { Id = 1, ProductTitleId = 1, Price = 10.11m, Comment = "Sweet Apple" },
                new Product() { Id = 2, ProductTitleId = 1, Price = 5.05m, Comment = "Small Apple" },
                new Product() { Id = 3, ProductTitleId = 2, Price = 15, Comment = "African Banana" },
                new Product() { Id = 4, ProductTitleId = 2, Price = 20, Comment = "Brazilian Banana" },
                new Product() { Id = 5, ProductTitleId = 3, Price = 16.2m, Comment = "Ukrainian Orange" },
                new Product() { Id = 6, ProductTitleId = 3, Price = 12, Comment = "Italian Orange" },
                new Product() { Id = 7, ProductTitleId = 4, Price = 13, Comment = "Clear Water" },
                new Product() { Id = 8, ProductTitleId = 4, Price = 50, Comment = "Sweet Water" },
                new Product() { Id = 9, ProductTitleId = 5, Price = 100, Comment = "Orange Juice" },
                new Product() { Id = 10, ProductTitleId = 5, Price = 120, Comment = "Banana Juice" },
                new Product() { Id = 11, ProductTitleId = 6, Price = 60, Comment = "Coca Cola" },
                new Product() { Id = 12, ProductTitleId = 6, Price = 5.5m, Comment = "Pepsi Cola" },
                new Product() { Id = 13, ProductTitleId = 7, Price = 12.23m, Comment = "Big Carrot" },
                new Product() { Id = 14, ProductTitleId = 7, Price = 10.02m, Comment = "Small Carrot" },
                new Product() { Id = 15, ProductTitleId = 8, Price = 89, Comment = "Big Potato" },
                new Product() { Id = 16, ProductTitleId = 8, Price = 88.89m, Comment = "Ukrainian Potato" },
                new Product() { Id = 17, ProductTitleId = 9, Price = 32, Comment = "Green Cabbage" },
                new Product() { Id = 18, ProductTitleId = 9, Price = 33.33m, Comment = "Typical Cabbage" },
                new Product() { Id = 19, ProductTitleId = 10, Price = 44.44m, Comment = "Yellow Tomato" },
                new Product() { Id = 20, ProductTitleId = 10, Price = 55.55m, Comment = "Pink Tomato" }
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            products.Clear();
        }

        [TestMethod]
        public void AddProduct_Saves_Product_Via_Context()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            productService.AddProduct(1, 10.8m, "Red Apple");

            //Assert
            mockSet.Verify(x => x.Add(It.IsAny<Product>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddProduct_Should_Throw_ArgumentNullException()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            productService.AddProduct(1, 0, "");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddProduct_Should_Throw_ArgumentException()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            productService.AddProduct(1, 10.8m, "Sweet Apple");
        }

        [TestMethod]
        public void GetProduct_Returns_Selected_Product()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            Product product = productService.GetProduct(p => p.Comment == "Sweet Apple");

            //Assert
            Assert.IsNotNull(product, "Product doesn't exist!");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetProduct_Throws_ArgumentNullException()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            Product product = productService.GetProduct(null);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetProduct_Throws_ArgumentException()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            Product product = productService.GetProduct(p => p.Comment == "Invalid product");
        }

        [TestMethod]
        public void GetProducts_Returns_Products_From_First_Category()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();
            var expected = from p in products
                           where p.ProductTitle.ProductCategoryId == 1
                           select p;

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            var actual = productService.GetProducts(p => p.ProductTitle.ProductCategoryId == 1);

            //Assert
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetProducts_Throws_ArgumentNullException()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            productService.GetProducts(p => p.ProductTitle.ProductCategoryId == 0);
        }

        [TestMethod]
        public void GetTotalPrice_Returns_Total_Price_Of_All_Products()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();
            var expected = 792.32m;

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            var totalPrice = productService.GetTotalPrice();

            //Assert
            Assert.AreEqual(expected, totalPrice, "Prices aren't equal!");
        }

        [TestMethod]
        public async Task GetProductAsync_Returns_Selected_Product()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IDbAsyncEnumerable<Product>>()
                                                    .Setup(m => m.GetAsyncEnumerator())
                                                    .Returns(new ShopDbAsyncEnumerator<Product>(queryableProducts.GetEnumerator()));

            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(new ShopDbAsyncQueryProvider<Product>(queryableProducts.Provider));
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            Product product = await productService.GetProductAsync(p => p.Comment == "Sweet Apple");

            //Assert
            Assert.IsNotNull(product, "Product doesn't exist!");
        }

        [TestMethod]
        public async Task GetProductsAsync_Returns_Products_From_First_Category()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();
            var expected = from p in products
                           where p.ProductTitle.ProductCategoryId == 1
                           select p;

            var mockSet = new Mock<DbSet<Product>>();

            mockSet.As<IDbAsyncEnumerable<Product>>()
                                                    .Setup(m => m.GetAsyncEnumerator())
                                                    .Returns(new ShopDbAsyncEnumerator<Product>(queryableProducts.GetEnumerator()));

            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(new ShopDbAsyncQueryProvider<Product>(queryableProducts.Provider));
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            var actual = await productService.GetProductsAsync(p => p.ProductTitle.ProductCategoryId == 1);

            //Assert
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public async Task GetTotalPriceAsync_Returns_Total_Price_Of_All_Products()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();
            var expected = 792.32m;

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IDbAsyncEnumerable<Product>>()
                                                    .Setup(m => m.GetAsyncEnumerator())
                                                    .Returns(new ShopDbAsyncEnumerator<Product>(queryableProducts.GetEnumerator()));

            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(new ShopDbAsyncQueryProvider<Product>(queryableProducts.Provider));
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var productService = new ProductService(mockContext.Object);
            var totalPrice = await productService.GetTotalPriceAsync();

            //Assert
            Assert.AreEqual(expected, totalPrice, "Prices aren't equal!");
        }
    }
}
