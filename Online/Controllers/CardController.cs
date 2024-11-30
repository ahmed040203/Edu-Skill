using Microsoft.AspNetCore.Mvc;
using Online.Data;
using Online.Models;
using Online.Repository;

public class CardController : Controller
{
    private readonly ICardRepository _cardRepository;
    private readonly ApplicationDbContext _context;

    // Constructor to initialize the repository manually
    public CardController(ApplicationDbContext context, ICardRepository cardRepository)
    {
        _context = context;
        _cardRepository = cardRepository;
    }

    public IActionResult Index()
    {
        var cartItems = _cardRepository.GetCartItems(1); // Replace 1 with actual ShoppingCartId
        return View(cartItems);
    }

    [HttpPost]
    public IActionResult AddToCart(int courseId)
    {
        var course = _context.Courses.Find(courseId);

        if (course == null)
        {
            return NotFound();
        }

        var cartItem = new CardItem
        {
            CourseId = courseId,
            ShoppingCartId = 1, // Replace with actual ShoppingCartId logic
            CreatedDate = DateTime.Now
        };

        _cardRepository.AddToCart(cartItem);
        _cardRepository.Save();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var cartItem = _cardRepository.GetCartItem(id);

        if (cartItem != null)
        {
            _cardRepository.DeleteFromCart(cartItem);
            _cardRepository.Save();
            return RedirectToAction("Index");
        }

        return NotFound();
    }
    public IActionResult Pay()
    {
        return View();
    }
}
