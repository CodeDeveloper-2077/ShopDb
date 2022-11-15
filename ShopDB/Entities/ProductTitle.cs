namespace ShopDB
{
    public class ProductTitle
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public int? ProductCategoryId { get; set; }
    }
}