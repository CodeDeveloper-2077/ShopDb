namespace ShopDB
{
    public class Street
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public City City { get; set; }
        public int? CityId { get; set; }
    }
}