using System.Collections.Generic;

namespace ShopDB
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public CustomerOrder CustomerOrder { get; set; }
        public int? CustomerOrderId { get; set; }

        public ICollection<Product> Products { get; set; }

        public decimal Price { get; set; }

        public decimal PriceWithDiscount { get; set; }

        public int ProductAmount { get; set; }

        public OrderDetails()
        {
            Products = new HashSet<Product>();
        }
    }
}