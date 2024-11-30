using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Online.Models;
using Online.ViewModels.Auth;
namespace Online.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Users
                {
                    UserName = $"{model.FirstName} {model.LastName}",
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    IsAgree = model.IsAgree,
                    BirthDate = model.BirthDate,
                    RegistrationDate = model.RegistrationDate, // Enum value of Student or Instructor
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var claims = new List<Claim>{
                        new (ClaimTypes.Email,user.Email!),
                        new (ClaimTypes.Name,user.UserName!),

                    };
                    foreach (var claim in claims)
                    {
                        await _userManager.AddClaimsAsync(user, claims);
                    }
                    return RedirectToAction(nameof(SignIn));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    bool flag = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                        if (result.Succeeded)
                        {
                            // Fetch user type (assuming Type is stored in user entity)
                            var userClaim = await _userManager.GetClaimsAsync(user);
                            if ((userClaim?.Count > 0))
                            {
                                var claimIdentity = new ClaimsIdentity(userClaim, CookieAuthenticationDefaults.AuthenticationScheme);
                                var claimPrincible = new ClaimsPrincipal(claimIdentity);
                                await HttpContext.SignInAsync(
                                    CookieAuthenticationDefaults.AuthenticationScheme,
                                    claimPrincible,
                                    new AuthenticationProperties
                                    {
                                        IsPersistent = true,
                                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                                    });
                            }
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }

                        ModelState.AddModelError(string.Empty, "Login Failed");
                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
    }
}
