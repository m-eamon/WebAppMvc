namespace WebAppMvc.Models
{
    public class CartItemModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Price {get; set;}

        public string Retailer {get; set;}

        public CartItemModel() {}

        public CartItemModel(long id, string title, string category, string description, 
        decimal price, string retailer) {
            Id = id;
            Title = title;
            Category = category;
            Description = description;
            Price = price;
            Retailer = retailer;
        }

    }


}