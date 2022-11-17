﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB.Services
{
    public class ProductService
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

        public Product GetProduct(string comment)
        {
            if (comment == String.Empty || comment == null)
                throw new ArgumentNullException($"Argument {nameof(comment)} can't be empty!");

            if (!_context.Products.Any(p => p.Comment == comment))
                throw new ArgumentException("This product hasn't been found!");

            return _context.Products.FirstOrDefault(p => p.Comment == comment);
        }

        public async Task<Product> GetProductAsync(string comment)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Comment == comment);
        }

        public IEnumerable<object> GetProductsFromCategory(int productCategoryId)
        {
            if (productCategoryId == 0)
                throw new ArgumentNullException($"Value {nameof(productCategoryId)} cannot be null!");

            var productsFromCategory = from p in _context.Products.ToList()
                                       join pt in _context.ProductTitles.ToList()
                                           on p.ProductTitleId equals pt.Id
                                       select new { Product = p, ProductCategoryId = pt.ProductCategoryId };

            return productsFromCategory
                                        .Where(p => p.ProductCategoryId == productCategoryId)
                                        .ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsFromCategoryAsync(object state)
        {
            int productCategoryId = (int)state;
            return await _context.Products
                                    .Where(p => p.ProductTitle.ProductCategoryId == productCategoryId)
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