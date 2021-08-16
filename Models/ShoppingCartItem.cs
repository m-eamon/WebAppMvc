namespace WebAppMvc.Models
{
    public class ShoppingCartItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Price {get; set;}

        public string Retailer {get; set;}
    }
}