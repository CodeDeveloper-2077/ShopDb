using System;
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
        Product GetProduct(Expression<Func<Product, bool>> predicate);
        Task<Product> GetProductAsync(Expression<Func<Product, bool>> expression);
        IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<Product>> GetProductsAsync(Expression<Func<Product, bool>> expression);
        decimal GetTotalPrice();
        Task<decimal> GetTotalPriceAsync();
    }
}
