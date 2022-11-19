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
using ShopDB.Entities;

namespace ShopDB.Tests
{
    [TestClass]
    public class PersonServiceTests
    {
        private List<Person> people;

        [TestInitialize]
        public void TestInitialize()
        {
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
        }

        [TestCleanup]
        public void TestCleanup()
        {
            people.Clear();
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
            var personService = new PersonService(mockContext.Object);
            var sortedPeople = personService.GetSortedPeople(p => p.Name, SortMode.Descending);

            //Assert
            Assert.AreEqual(20, sortedPeople.Count());
            Assert.AreEqual("Yevgen", sortedPeople[0].Name);
            Assert.AreEqual("Yeva", sortedPeople[1].Name);
            Assert.AreEqual("Yan", sortedPeople[2].Name);
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
            var personService = new PersonService(mockContext.Object);
            var sortedPeople = await personService.GetSortedPeopleAsync(p => p.Name, SortMode.Descending);

            //Assert
            Assert.AreEqual(20, sortedPeople.Count());
            Assert.AreEqual("Yevgen", sortedPeople[0].Name);
            Assert.AreEqual("Yeva", sortedPeople[1].Name);
            Assert.AreEqual("Yan", sortedPeople[2].Name);
        }

        [TestMethod]
        public void GetSortedPeople_By_Ascending()
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
            var personService = new PersonService(mockContext.Object);
            var sortedPeople = personService.GetSortedPeople(p => p.Name, SortMode.Ascending);

            //Assert
            Assert.AreEqual("Arsen", sortedPeople[0].Name);
            Assert.AreEqual("Bogdan", sortedPeople[1].Name);
            Assert.AreEqual("Bohdan", sortedPeople[2].Name);
        }

        [TestMethod]
        public async Task GetSortedPeopleAsync_By_Ascending()
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
            var personService = new PersonService(mockContext.Object);
            var sortedPeople = await personService.GetSortedPeopleAsync(p => p.Name, SortMode.Ascending);

            //Assert
            Assert.AreEqual("Arsen", sortedPeople[0].Name);
            Assert.AreEqual("Bogdan", sortedPeople[1].Name);
            Assert.AreEqual("Bohdan", sortedPeople[2].Name);
        }

        [TestMethod]
        public void GetPeople_Returns_People_Older_Than_Date()
        {
            //Arrange
            var queryablePeople = people.AsQueryable();
            var expected = from p in people
                           where p.BirthDate > new DateTime(2000, 1, 1)
                           select p;

            var mockSet = new Mock<DbSet<Person>>();
            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(queryablePeople.Provider);
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(queryablePeople.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(queryablePeople.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(queryablePeople.GetEnumerator());

            var mockContext = new Mock<ShopDBContext>();
            mockContext.Setup(m => m.People).Returns(mockSet.Object);

            //Act
            var personService = new PersonService(mockContext.Object);
            var actual = personService.GetPeople(p => p.BirthDate > new DateTime(2000, 1, 1));

            //Assert
            Assert.AreEqual(expected.Count(), actual.Count(), "Collections aren't equal!");
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList(), "Collections aren't equivalent!");
        }

        [TestMethod]
        public async Task GetPeopleAsync_Returns_People_Older_Than_Date()
        {
            //Arrange
            var queryablePeople = people.AsQueryable();
            var expected = from p in people
                           where p.BirthDate > new DateTime(2000, 1, 1)
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
            var personService = new PersonService(mockContext.Object);
            var actual = await personService.GetPeopleAsync(p => p.BirthDate > new DateTime(2000, 1, 1));

            //Assert
            Assert.AreEqual(expected.Count(), actual.Count(), "Collections aren't equal!");
            CollectionAssert.AreEquivalent(expected.ToList(), actual.ToList(), "Collections aren't equivalent!");
        }

        [TestMethod]
        public void GetPerson_Returns_Selected_Person()
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
            var personService = new PersonService(mockContext.Object);
            var person1 = personService.GetPerson(p => p.Name == "Dasha");
            var person2 = personService.GetPerson(p => p.Name == "Vasyl");
            var person3 = personService.GetPerson(p => p.Name == "Ivan");

            //Assert
            Assert.AreEqual("Dasha", person1.Name);
            Assert.AreEqual("Vasyl", person2.Name);
            Assert.AreEqual("Ivan", person3.Name);
        }

        [TestMethod]
        public async Task GetPersonAsync_Returns_Selected_Person()
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
            var personService = new PersonService(mockContext.Object);
            var person1 = await personService.GetPersonAsync(p => p.Name == "Dasha");
            var person2 = await personService.GetPersonAsync(p => p.Name == "Vasyl");
            var person3 = await personService.GetPersonAsync(p => p.Name == "Ivan");

            //Assert
            Assert.AreEqual("Dasha", person1.Name);
            Assert.AreEqual("Vasyl", person2.Name);
            Assert.AreEqual("Ivan", person3.Name);
        }

        [TestMethod]
        public void AddPerson_Saves_Person_Via_Context()
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
            var personService = new PersonService(mockContext.Object);
            personService.AddPerson(21, "Oleh", "Shevchenko");

            //Assert
            mockSet.Verify(x => x.Add(It.IsAny<Person>()), Times.Once);
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AddPerson_Throw_ArgumentNullException()
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
            var personService = new PersonService(mockContext.Object);
            personService.AddPerson(21, "", "");
        }
    }
}
