namespace ShopDB
{
    public class Customer
    {
        public int Id { get; set; }

        public Person Person { get; set; }
        public int? PersonId { get; set; }

        public string CardNumber { get; set; }

        public double Discount { get; set; }
    }
}