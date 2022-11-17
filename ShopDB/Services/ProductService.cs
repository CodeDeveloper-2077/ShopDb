using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB.Services
{
    public class ProductService : IProductService
    {
        private readonly ShopDBContext _context;

        public ProductService(ShopDBContext context)
        {
            _context = context;
        }

        public Product AddProduct(int? productTitleId, decimal price, string comment)
        {
            if (price == 0 || comment == String.Empty || comment == null)
                throw new ArgumentNullException($"Provide {nameof(price)} and {nameof(comment)} please!");

            if (_context.Products.Any(p => p.Comment == comment))
                throw new ArgumentException("Can't add same product to database!");

            var product = _context.Products.Add(new Product
            {
                Id = _context.Products.Count(),
                ProductTitleId = productTitleId,
                Price = price,
                Comment = comment
            });
            _context.SaveChanges();

            return product;
        }

        public Product GetProduct(Expression<Func<Product, bool>> predicate)
        {
            if (!_context.Products.Any(predicate))
                throw new ArgumentException("This product hasn't been found!");

            return _context.Products.FirstOrDefault(predicate);
        }

        public async Task<Product> GetProductAsync(Expression<Func<Product, bool>> expression)
        {
            return await _context.Products.FirstOrDefaultAsync(expression);
        }

        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.Where(predicate);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(Expression<Func<Product, bool>> expression)
        {
            return await _context.Products
                                            .Where(expression)
                                            .ToListAsync();
        }

        public decimal GetTotalPrice()
        {
            return _context.Products.Sum(p => p.Price);
        }

        public async Task<decimal> GetTotalPriceAsync()
        {
            return await _context.Products.SumAsync(p => p.Price);
        }
    }
}
