using ShopDB.DBInitializers;
using System;
using System.Data.Entity;
using System.Linq;

namespace ShopDB
{
    public class ShopDBContext : DbContext
    {
        private static ShopDBContext _shopDbContext;

        static ShopDBContext()
        {
        }

        protected ShopDBContext()
            : base("name=ShopDBContext")
        {
            Database.SetInitializer(new ShopDBInitializer());
        }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        public virtual DbSet<ProductTitle> ProductTitles { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

        public virtual DbSet<Supermarket> Supermarkets { get; set; }

        public virtual DbSet<Street> Streets { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<PersonContact> PersonContacts { get; set; }

        public virtual DbSet<ContactType> ContactTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static ShopDBContext CreateInstance()
        {
            if (_shopDbContext == null)
                _shopDbContext = new ShopDBContext();

            Console.WriteLine(_shopDbContext.GetHashCode());

            return _shopDbContext;
        }
    }
}