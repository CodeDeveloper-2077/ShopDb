﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB.Services
{
    public interface IProductService
    {
        Product AddProduct(int? productTitleId, decimal price, string comment);
        Product GetProduct(Func<Product, bool> predicate);
        Task<Product> GetProductAsync(Expression<Func<Product, bool>> expression);
        IEnumerable<object> GetProductsFromCategory(int productCategoryId);
        Task<IEnumerable<Product>> GetProductsFromCategoryAsync(int productCategoryId);
        decimal GetTotalPrice();
        Task<decimal> GetTotalPriceAsync();
    }
}
