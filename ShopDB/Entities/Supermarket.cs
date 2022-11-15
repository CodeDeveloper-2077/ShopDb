namespace ShopDB
{
    public class Supermarket
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Street Street { get; set; }
        public int? StreetId { get; set; }

        public string HouseNumber { get; set; }
    }
}