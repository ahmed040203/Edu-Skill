using Online.Models;


namespace Online.Repository
{
    public interface ICardRepository
    {
        IEnumerable<CardItem> GetCartItems(int shoppingCartId);
        CardItem GetCartItem(int cartItemId);
        void AddToCart(CardItem cartItem);
        void DeleteFromCart(CardItem cartItem);
        void Save();
    }
}
