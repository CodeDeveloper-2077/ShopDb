using System.Collections;
using System.Collections.Generic;

namespace ShopDB
{
    public class Product
    {
        public int Id { get; set; }

        public ProductTitle ProductTitle { get; set; }
        public int? ProductTitleId { get; set; }

        public ICollection<Manufacturer> Manufacturers { get; set; }

        public decimal Price { get; set; }

        public string Comment { get; set; }

        public Product()
        {
            Manufacturers = new HashSet<Manufacturer>();
        }
    }
}