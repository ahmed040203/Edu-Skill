using Microsoft.AspNetCore.Mvc;
using Online.Data;
using Online.Models;

namespace Online.Controllers
{
    public class AboutController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
