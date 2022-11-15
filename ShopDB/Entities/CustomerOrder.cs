using System;

namespace ShopDB
{
    public class CustomerOrder
    {
        public int Id { get; set; }

        public DateTime OperationTime { get; set; }

        public Supermarket Supermarket { get; set; }
        public int? SupermarketId { get; set; }

        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}