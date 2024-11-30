

using Microsoft.AspNetCore.Mvc;
using Online.Data;
using Online.Models;
using Online.Repository;

namespace Online.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context; // Instantiate DbContext manually
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var users = _userRepository.GetAllUsers();
            var lastUserAdded = _userRepository.GetLastUserAdded();

            ViewData["LastUserAdded"] = lastUserAdded;
            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(string id, Users emp)
        {
            if (!ModelState.IsValid)
            {
                return View(emp);
            }

            var empFromDb = _userRepository.GetUserById(id);
            if (empFromDb == null)
            {
                return NotFound();
            }

            // Update fields
            empFromDb.FirstName = emp.FirstName;
            empFromDb.LastName = emp.LastName;
            empFromDb.Email = emp.Email;
            empFromDb.PhoneNumber = emp.PhoneNumber;

            // Save changes
            _userRepository.UpdateUser(empFromDb);
            _userRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Users st)
        {
            if (!ModelState.IsValid)
            {
                return View(st);
            }

            var userFromDb = _userRepository.GetUserById(st.Id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            userFromDb.FirstName = st.FirstName;
            userFromDb.LastName = st.LastName;
            userFromDb.Email = st.Email;
            userFromDb.PhoneNumber = st.PhoneNumber;
            userFromDb.BirthDate = st.BirthDate;

            _userRepository.UpdateUser(userFromDb);
            _userRepository.Save();

            TempData["SuccessMessage"] = "User saved successfully!";
            return RedirectToAction("Edit", new { id = userFromDb.Id });
        }
    }
}

