using Microsoft.EntityFrameworkCore;
using Online.Data;
using Online.Models;

namespace Online.Repository
{
    public class CardRepository:ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<CardItem> GetCartItems(int shoppingCartId)
        {
            return _context.CardItems
                .Include(ci => ci.Course)
                .Where(ci => ci.ShoppingCartId == shoppingCartId)
                .ToList();
        }
        public CardItem GetCartItem(int cartItemId)
        {
            return _context.CardItems.FirstOrDefault(e => e.CartItemId == cartItemId);
        }
        public void AddToCart(CardItem cartItem)
        {
            _context.CardItems.Add(cartItem);
        }

        public void DeleteFromCart(CardItem cartItem)
        {
            _context.CardItems.Remove(cartItem);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
