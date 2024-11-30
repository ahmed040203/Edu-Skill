namespace Online.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string? Description { get; set; }
        public List<CardItem> CartItems { get; set; } = new List<CardItem>();
    }
}
