using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using ShopDB.Tests.DbAsyncQueryProvider;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace ShopDB.Tests
{
    [TestClass]
    public class ShopDBContextTests
    {
        private List<Product> products;
        private List<Person> people;
        private List<ProductTitle> productTitles;

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
            people = new List<Person>
            {
                new Person() { Id = 1, Name = "Yevgen", Surname = "Kojevskiy", BirthDate = new DateTime(2000, 1, 1) },
                new Person() { Id = 2, Name = "Yan", Surname = "Petrenko", BirthDate = new DateTime(2001, 11, 1) },
                new Person() { Id = 3, Name = "Janna", Surname = "Ivanova", BirthDate = new DateTime(2002, 12, 12) },
                new Person() { Id = 4, Name = "Denis", Surname = "Galushko", BirthDate = new DateTime(1995, 10, 1) },
                new Person() { Id = 5, Name = "Filip", Surname = "Kromvel", BirthDate = new DateTime(1980, 8, 8) },
                new Person() { Id = 6, Name = "Bogdan", Surname = "Steciuk", BirthDate = new DateTime(2002, 7, 1) },
                new Person() { Id = 7, Name = "Yeva", Surname = "Krasivaya", BirthDate = new DateTime(1992, 8, 8) },
                new Person() { Id = 8, Name = "Nadegda", Surname = "Vesela", BirthDate = new DateTime(1997, 5, 11) },
                new Person() { Id = 9, Name = "Arsen", Surname = "Govorliviy", BirthDate = new DateTime(1990, 11, 21) },
                new Person() { Id = 10, Name = "Mariya", Surname = "Velikolepnaya", BirthDate = new DateTime(1988, 4, 1) },
                new Person() { Id = 11, Name = "Dasha", Surname = "Ruda", BirthDate = new DateTime(1987, 10, 1) },
                new Person() { Id = 12, Name = "Bohdan", Surname = "Chervoniy", BirthDate = new DateTime(1950, 12, 1) },
                new Person() { Id = 13, Name = "Ivan", Surname = "Chorniy", BirthDate = new DateTime(2000, 1, 13) },
                new Person() { Id = 14, Name = "Vasyl", Surname = "Anotin", BirthDate = new DateTime(2001, 12, 12) },
                new Person() { Id = 15, Name = "Leha", Surname = "Katin", BirthDate = new DateTime(1977, 12, 12) },
                new Person() { Id = 16, Name = "Vadim", Surname = "Patin", BirthDate = new DateTime(1966, 8, 8) },
                new Person() { Id = 17, Name = "Vova", Surname = "Yellow", BirthDate = new DateTime(1998, 4, 2) },
                new Person() { Id = 18, Name = "Katya", Surname = "Adushkina", BirthDate = new DateTime(1999, 3, 4) },
                new Person() { Id = 19, Name = "Roman", Surname = "Valekiy", BirthDate = new DateTime(2010, 6, 5) },
                new Person() { Id = 20, Name = "Ivan", Surname = "Paliy", BirthDate = new DateTime(1994, 8, 7) }
            };
            productTitles = new List<ProductTitle>
            {
                new ProductTitle() { Id = 1, Title = "Red Apple", ProductCategoryId = 1 },
                new ProductTitle() { Id = 2, Title = "Banana", ProductCategoryId = 1 },
                new ProductTitle() { Id = 3, Title = "Orange", ProductCategoryId = 1 },
                new ProductTitle() { Id = 4, Title = "Water", ProductCategoryId = 2 },
                new ProductTitle() { Id = 5, Title = "Juice", ProductCategoryId = 2 },
                new ProductTitle() { Id = 6, Title = "Cola", ProductCategoryId = 2 },
                new ProductTitle() { Id = 7, Title = "Carrot", ProductCategoryId = 3 },
                new ProductTitle() { Id = 8, Title = "Potato", ProductCategoryId = 3 },
                new ProductTitle() { Id = 9, Title = "Cabbage", ProductCategoryId = 3 },
                new ProductTitle() { Id = 10, Title = "Tomato", ProductCategoryId = 3 },
                new ProductTitle() { Id = 11, Title = "Cod", ProductCategoryId = 4 },
                new ProductTitle() { Id = 12, Title = "Pike", ProductCategoryId = 4 },
                new ProductTitle() { Id = 13, Title = "Carp", ProductCategoryId = 4 }
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            products.Clear();
            people.Clear();
            productTitles.Clear();
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
            var infrastructure = new Infrastructure(mockContext.Object);
            infrastructure.AddProduct(1, 10.8m, "Red Apple");

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
            var infrastructure = new Infrastructure(mockContext.Object);
            infrastructure.AddProduct(1, 0, "");
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
            var infrastructure = new Infrastructure(mockContext.Object);
            infrastructure.AddProduct(1, 10.8m, "Sweet Apple");
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
            var infrastructure = new Infrastructure(mockContext.Object);
            Product product = infrastructure.GetProduct("Sweet Apple");

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
            var infrastructure = new Infrastructure(mockContext.Object);
            Product product = infrastructure.GetProduct(null);
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
            var infrastructure = new Infrastructure(mockContext.Object);
            Product product = infrastructure.GetProduct("Invalid product");
        }

        [TestMethod]
        public void GetSortedPeople_By_Descending()
        {
            //Arrange
            var queryablePeople = people.AsQueryable();

            var mockSet = new Mock<DbSet<Person>>();
            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(queryablePeople.Provider);
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(queryablePeople.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(queryablePeople.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(queryablePeople.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.People).Returns(mockSet.Object);

            //Act
            var infrastructure = new Infrastructure(mockContext.Object);
            var sortedPeople = infrastructure.GetSortedPeople();

            //Assert
            Assert.AreEqual(20, sortedPeople.Count());
            Assert.AreEqual("Yevgen", sortedPeople[0].Name);
            Assert.AreEqual("Yeva", sortedPeople[1].Name);
            Assert.AreEqual("Yan", sortedPeople[2].Name);
        }

        [TestMethod]
        public void GetProductsFromCategory_Returns_Products_From_1()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();
            var expected = from p in products
                           join pt in productTitles
                               on p.ProductTitleId equals pt.Id
                           select p;

           var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryableProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryableProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryableProducts.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryableProducts.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            //Act
            var infrastructure = new Infrastructure(mockContext.Object);
            var actual = infrastructure.GetProductsFromCategory(1);

            //Assert
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetProductsFromCategory_Throws_ArgumentNullException()
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
            var infrastructure = new Infrastructure(mockContext.Object);
            infrastructure.GetProductsFromCategory(0);
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
            var infrastructure = new Infrastructure(mockContext.Object);
            var totalPrice = infrastructure.GetTotalPrice();

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
            var infrastructure = new Infrastructure(mockContext.Object);
            Product product = await infrastructure.GetProductAsync("Sweet Apple");

            //Assert
            Assert.IsNotNull(product, "Product doesn't exist!");
        }

        [TestMethod]
        public async Task GetProductsFromCategoryAsync_Returns_Products_From_1()
        {
            //Arrange
            var queryableProducts = products.AsQueryable();
            var expected = from p in products
                           join pt in productTitles
                               on p.ProductTitleId equals pt.Id
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
            var infrastructure = new Infrastructure(mockContext.Object);
            var actual = await infrastructure.GetProductsFromCategoryAsync(1);

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
            var infrastructure = new Infrastructure(mockContext.Object);
            var totalPrice = await infrastructure.GetTotalPriceAsync();

            //Assert
            Assert.AreEqual(expected, totalPrice, "Prices aren't equal!");
        }

        [TestMethod]
        public async Task GetSortedPeopleAsync_By_Descending()
        {
            //Arrange
            var queryablePeople = people.AsQueryable();

            var mockSet = new Mock<DbSet<Person>>();

            mockSet.As<IDbAsyncEnumerable<Person>>()
                                            .Setup(m => m.GetAsyncEnumerator())
                                            .Returns(new ShopDbAsyncEnumerator<Person>(queryablePeople.GetEnumerator()));

            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(new ShopDbAsyncQueryProvider<Person>(queryablePeople.Provider));
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(queryablePeople.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(queryablePeople.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(queryablePeople.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.People).Returns(mockSet.Object);

            //Act
            var infrastructure = new Infrastructure(mockContext.Object);
            var sortedPeople = await infrastructure.GetSortedPeopleAsync();

            //Assert
            Assert.AreEqual(20, sortedPeople.Count());
            Assert.AreEqual("Yevgen", sortedPeople[0].Name);
            Assert.AreEqual("Yeva", sortedPeople[1].Name);
            Assert.AreEqual("Yan", sortedPeople[2].Name);
        }

        [TestMethod]
        public void GetPeopleOlderThanDate_Returns_People_Older_Than_Date()
        {
            //Arrange
            var queryablePeople = people.AsQueryable();
            var expected = from p in people
                           where p.BirthDate.Year > 2000
                           select p;

            var mockSet = new Mock<DbSet<Person>>();
            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(queryablePeople.Provider);
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(queryablePeople.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(queryablePeople.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(queryablePeople.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.People).Returns(mockSet.Object);

            //Act
            var infrastructure = new Infrastructure(mockContext.Object);
            var actual = infrastructure.GetPeopleOlderThanDate(new DateTime(2000, 1, 1));

            //Assert
            Assert.AreEqual(expected.Count(), actual.Count(), "Collections aren't equal!");
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList(), "Collections aren't equivalent!");
        }

        [TestMethod]
        public async Task GetPeopleOlderThanDateAsync_Returns_People_Older_Than_Date()
        {
            //Arrange
            var queryablePeople = people.AsQueryable();
            var expected = from p in people
                           where p.BirthDate.Year > 2000
                           select p;

            var mockSet = new Mock<DbSet<Person>>();

            mockSet.As<IDbAsyncEnumerable<Person>>()
                                                    .Setup(m => m.GetAsyncEnumerator())
                                                    .Returns(new ShopDbAsyncEnumerator<Person>(queryablePeople.GetEnumerator()));

            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(new ShopDbAsyncQueryProvider<Person>(queryablePeople.Provider));
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(queryablePeople.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(queryablePeople.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(queryablePeople.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.People).Returns(mockSet.Object);

            //Act
            var infrastructure = new Infrastructure(mockContext.Object);
            var actual = await infrastructure.GetPeopleOlderThanDateAsync(new DateTime(2000, 1, 1));

            //Assert
            Assert.AreEqual(expected.Count(), actual.Count(), "Collections aren't equal!");
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList(), "Collections aren't equivalent!");
        }
    }
}
