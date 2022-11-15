using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB.DBInitializers
{
    internal class ShopDBInitializer : DropCreateDatabaseAlways<ShopDBContext>
    {

        public override void InitializeDatabase(ShopDBContext context)
        {
            base.InitializeDatabase(context);

            var productCategories = new List<ProductCategory>
            {
                new ProductCategory() { Id = 1, Name = "Fruits" },
                new ProductCategory() { Id = 2, Name = "Drinks" } ,
                new ProductCategory() { Id = 3, Name = "Vegetables" } ,
                new ProductCategory() { Id = 4, Name = "Fish" }
            };

            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer() { Id = 1, Name = "First manufacturer" },
                new Manufacturer() { Id = 2, Name = "Second manufacturer" },
                new Manufacturer() { Id = 3, Name = "Third manufacturer" },
                new Manufacturer() { Id = 4, Name = "Fourth manufacturer" }
            };

            var productTitles = new List<ProductTitle>
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

            var products = new List<Product>
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

            var cities = new List<City>
            {
                new City() { Id = 1, Name = "Kyiv" },
                new City() { Id = 2, Name = "Vinnitsya" },
                new City() { Id = 3, Name = "Kharkiv" }
            };

            var streets = new List<Street>
            {
                new Street() { Id = 1, Name = "Arsenalnaya", CityId = 1 },
                new Street() { Id = 2, Name = "Shevchenko", CityId = 1 },
                new Street() { Id = 3, Name = "Kyivskaya", CityId = 2 },
                new Street() { Id = 4, Name = "Magistrtskaya", CityId = 2 },
                new Street() { Id = 5, Name = "Lesnaya", CityId = 3 },
                new Street() { Id = 6, Name = "Zelenaya", CityId = 3 },
                new Street() { Id = 7, Name = "Krasnaya", CityId = 3 },
                new Street() { Id = 8, Name = "Chornya", CityId = 2 },
                new Street() { Id = 9, Name = "Franka", CityId = 1 },
                new Street() { Id = 10, Name = "Fantastichna", CityId = 1 }
            };

            var supermarkets = new List<Supermarket>
            {
                new Supermarket() { Id = 1, Name = "Best Choice", StreetId = 1, HouseNumber = "122" },
                new Supermarket() { Id = 2, Name = "Best Choice", StreetId = 2, HouseNumber = "13B" },
                new Supermarket() { Id = 3, Name = "Smart Choice", StreetId = 3, HouseNumber = "177A" },
                new Supermarket() { Id = 4, Name = "Smart Choice", StreetId = 4, HouseNumber = "8/A" },
                new Supermarket() { Id = 5, Name = "Your Choice", StreetId = 5, HouseNumber = "12" },
                new Supermarket() { Id = 6, Name = "Cheep Choice", StreetId = 6, HouseNumber = "5A" },
                new Supermarket() { Id = 7, Name = "Kramnichka", StreetId = 7, HouseNumber = "10" },
                new Supermarket() { Id = 8, Name = "FastMart", StreetId = 8, HouseNumber = "5A" },
                new Supermarket() { Id = 9, Name = "Small market", StreetId = 9, HouseNumber = "89" },
                new Supermarket() { Id = 10, Name = "Big mall", StreetId = 10, HouseNumber = "101" },
                new Supermarket() { Id = 11, Name = "Nice mall", StreetId = 10, HouseNumber = "10A" },
                new Supermarket() { Id = 12, Name = "Metro", StreetId = 2, HouseNumber = "12A" },
                new Supermarket() { Id = 13, Name = "Swey mall", StreetId = 3, HouseNumber = "5A" },
                new Supermarket() { Id = 14, Name = "Boo mall", StreetId = 4, HouseNumber = "23/A" },
                new Supermarket() { Id = 15, Name = "Goo mall", StreetId = 5, HouseNumber = "23-A" }
            };

            var contactTypes = new List<ContactType>
            {
                new ContactType() { Id = 1, Name = "Phone" },
                new ContactType() { Id = 2, Name = "Email" },
                new ContactType() { Id = 3, Name = "Skype" },
                new ContactType() { Id = 4, Name = "Viber" }
            };

            var people = new List<Person>
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

            var personContacts = new List<PersonContact>
            {
                new PersonContact() { Id = 1, PersonId = 9, ContactValue = "+38(077)123-45-67" },
                new PersonContact() { Id = 2, PersonId = 9, ContactValue = "user9@example.com" },
                new PersonContact() { Id = 3, PersonId = 10, ContactValue = "+38(088)123-45-67" },
                new PersonContact() { Id = 4, PersonId = 10, ContactValue = "user10@example.com" },
                new PersonContact() { Id = 5, PersonId = 8, ContactValue = "+38(099)123-45-67" },
                new PersonContact() { Id = 6, PersonId = 8, ContactValue = "user8@example.com" },
                new PersonContact() { Id = 7, PersonId = 7, ContactValue = "+38(007)123-45-67" },
                new PersonContact() { Id = 8, PersonId = 7, ContactValue = "user7@example.com" },
                new PersonContact() { Id = 9, PersonId = 6, ContactValue = "+38(066)123-45-67" },
                new PersonContact() { Id = 10, PersonId = 6, ContactValue = "user6@example.com" },
                new PersonContact() { Id = 11, PersonId = 5, ContactValue = "+38(055)123-45-67" },
                new PersonContact() { Id = 12, PersonId = 5, ContactValue = "user5@example.com" },
                new PersonContact() { Id = 13, PersonId = 4, ContactValue = "+38(044)123-45-67" },
                new PersonContact() { Id = 14, PersonId = 4, ContactValue = "user4@example.com" },
                new PersonContact() { Id = 15, PersonId = 3, ContactValue = "+38(033)123-45-67" },
                new PersonContact() { Id = 16, PersonId = 3, ContactValue = "user3@example.com" },
                new PersonContact() { Id = 17, PersonId = 2, ContactValue = "+38(022)123-45-67" },
                new PersonContact() { Id = 18, PersonId = 2, ContactValue = "user2@example.com" },
                new PersonContact() { Id = 19, PersonId = 1, ContactValue = "+38(011)123-45-67" },
                new PersonContact() { Id = 20, PersonId = 1, ContactValue = "user1@example.com" }
        };

            var customers = new List<Customer>
            {
                new Customer() { PersonId = 1, CardNumber = "921212121", Discount = 0.1 },
                new Customer() { PersonId = 2, CardNumber = "935456021", Discount = 0.02 },
                new Customer() { PersonId = 3, CardNumber = "909090283", Discount = 0.1 },
                new Customer() { PersonId = 4, CardNumber = "120985320", Discount = 0.02 },
                new Customer() { PersonId = 5, CardNumber = "437238943", Discount = 0.1 },
                new Customer() { PersonId = 6, CardNumber = "129034871", Discount = 0.02 },
                new Customer() { PersonId = 7, CardNumber = "438927489", Discount = 0.05 },
                new Customer() { PersonId = 8, CardNumber = "321794012", Discount = 0.05 },
                new Customer() { PersonId = 9, CardNumber = "218324131", Discount = 0 },
                new Customer() { PersonId = 10, CardNumber = "423443222", Discount = 0 },
                new Customer() { PersonId = 11, CardNumber = "4324236", Discount = 0 },
                new Customer() { PersonId = 12, CardNumber = "34912748", Discount = 0.1 },
                new Customer() { PersonId = 13, CardNumber = "231893122", Discount = 0.1 },
                new Customer() { PersonId = 14, CardNumber = "2130931293", Discount = 0.05 },
                new Customer() { PersonId = 15, CardNumber = "23418941894", Discount = 0.05 },
                new Customer() { PersonId = 16, CardNumber = "2341034128931", Discount = 0.05 },
                new Customer() { PersonId = 17, CardNumber = "231983189", Discount = 0.05 },
                new Customer() { PersonId = 18, CardNumber = "213839189321", Discount = 0.05 },
                new Customer() { PersonId = 19, CardNumber = "23108932189", Discount = 0.05 },
                new Customer() { PersonId = 20, CardNumber = "64893589", Discount = 0.05 }

            };

            var customerOrders = new List<CustomerOrder>
            {
                new CustomerOrder() { Id = 1, OperationTime = new DateTime(2020, 1, 1), SupermarketId = 1, CustomerId = 1 },
                new CustomerOrder() { Id = 2, OperationTime = new DateTime(2020, 2, 2), SupermarketId = 2, CustomerId = 2 },
                new CustomerOrder() { Id = 3, OperationTime = new DateTime(2020, 2 , 2), SupermarketId = 3, CustomerId = 3 },
                new CustomerOrder() { Id = 4, OperationTime = new DateTime(2020, 3, 3), SupermarketId = 4, CustomerId = 4 },
                new CustomerOrder() { Id = 5, OperationTime = new DateTime(2020, 4, 4), SupermarketId = 5, CustomerId = 5 },
                new CustomerOrder() { Id = 6, OperationTime = new DateTime(2020, 5, 5), SupermarketId = 6, CustomerId = 6 },
                new CustomerOrder() { Id = 7, OperationTime = new DateTime(2020, 6, 6), SupermarketId = 7, CustomerId = 7 },
                new CustomerOrder() { Id = 8, OperationTime = new DateTime(2020, 7, 7), SupermarketId = 1, CustomerId = 8 },
                new CustomerOrder() { Id = 9, OperationTime = new DateTime(2020, 8, 8), SupermarketId = 2, CustomerId = 9 },
                new CustomerOrder() { Id = 10, OperationTime = new DateTime(2020, 9, 11), SupermarketId = 3, CustomerId = 10 },
                new CustomerOrder() { Id = 11, OperationTime = new DateTime(2020, 10, 10), SupermarketId = 4, CustomerId = 11 },
                new CustomerOrder() { Id = 12, OperationTime = new DateTime(2020, 11, 11), SupermarketId = 5, CustomerId = 12 },
                new CustomerOrder() { Id = 13, OperationTime = new DateTime(2021, 1, 1), SupermarketId = 6, CustomerId = 13 },
                new CustomerOrder() { Id = 14, OperationTime = new DateTime(2021, 1, 1), SupermarketId = 7, CustomerId = 14 },
                new CustomerOrder() { Id = 15, OperationTime = new DateTime(2022, 1, 1), SupermarketId = 8, CustomerId = 15 },
                new CustomerOrder() { Id = 16, OperationTime = new DateTime(2022, 1, 1), SupermarketId = 9, CustomerId = 1 },
                new CustomerOrder() { Id = 17, OperationTime = new DateTime(2021, 1, 1), SupermarketId = 1, CustomerId = 2 },
                new CustomerOrder() { Id = 18, OperationTime = new DateTime(2019, 1, 1), SupermarketId = 1, CustomerId = 3 },
                new CustomerOrder() { Id = 19, OperationTime = new DateTime(2017, 1, 1), SupermarketId = 1, CustomerId = 4 },
                new CustomerOrder() { Id = 20, OperationTime = new DateTime(2018, 1, 1), SupermarketId = 1, CustomerId = 5 }
            };

            var orderDetails = new List<OrderDetails>
            {
                new OrderDetails() { Id = 1, CustomerOrderId = 1, Price = 20, PriceWithDiscount = 18, ProductAmount = 4 },
                new OrderDetails() { Id = 2, CustomerOrderId = 2, Price = 80, PriceWithDiscount = 78.4m, ProductAmount = 5 },
                new OrderDetails() { Id = 3, CustomerOrderId = 3, Price = 90, PriceWithDiscount = 81, ProductAmount = 6 },
                new OrderDetails() { Id = 4, CustomerOrderId = 4, Price = 30, PriceWithDiscount = 29.4m, ProductAmount = 2 },
                new OrderDetails() { Id = 5, CustomerOrderId = 5, Price = 40, PriceWithDiscount = 36, ProductAmount = 1 },
                new OrderDetails() { Id = 6, CustomerOrderId = 6, Price = 50, PriceWithDiscount = 49, ProductAmount = 3 },
                new OrderDetails() { Id = 7, CustomerOrderId = 7, Price = 60, PriceWithDiscount = 57, ProductAmount = 11 },
                new OrderDetails() { Id = 8, CustomerOrderId = 8, Price = 70, PriceWithDiscount = 66.5m, ProductAmount = 13 },
                new OrderDetails() { Id = 9, CustomerOrderId = 9, Price = 80, PriceWithDiscount = 80, ProductAmount = 14 },
                new OrderDetails() { Id = 10, CustomerOrderId = 10, Price = 90, PriceWithDiscount = 90, ProductAmount = 2 },
                new OrderDetails() { Id = 11, CustomerOrderId = 11, Price = 120, PriceWithDiscount =  120, ProductAmount = 1 },
                new OrderDetails() { Id = 12, CustomerOrderId = 12, Price = 130, PriceWithDiscount =  130, ProductAmount = 5 },
                new OrderDetails() { Id = 13, CustomerOrderId = 13, Price = 40, PriceWithDiscount =  36, ProductAmount = 6 },
                new OrderDetails() { Id = 14, CustomerOrderId = 14, Price = 50, PriceWithDiscount =  45, ProductAmount = 7 },
                new OrderDetails() { Id = 15, CustomerOrderId = 15, Price = 33, PriceWithDiscount =  31.35m, ProductAmount = 8 }

            };

            context.ProductCategories.AddRange(productCategories);
            context.Manufacturers.AddRange(manufacturers);
            context.ProductTitles.AddRange(productTitles);
            context.Products.AddRange(products);
            context.Cities.AddRange(cities);
            context.Streets.AddRange(streets);
            context.Supermarkets.AddRange(supermarkets);
            context.ContactTypes.AddRange(contactTypes);
            context.People.AddRange(people);
            context.PersonContacts.AddRange(personContacts);
            context.Customers.AddRange(customers);
            context.CustomerOrders.AddRange(customerOrders);
            context.OrderDetails.AddRange(orderDetails);

            context.SaveChanges();
        }
    }
}
