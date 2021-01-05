using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Website.Areas.Welcome.Models;

namespace Website.Areas.Welcome.Controllers
{
    [Area("Welcome")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> aManager,
            SignInManager<ApplicationUser> aSignInManager)
        {
            _userManager = aManager;
            _signInManager = aSignInManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(ApplicationUser applicationUser)
        {
            var user = await _userManager.FindByNameAsync(applicationUser.UserName);
            if (user == null) return View(applicationUser);

            var result =
                await _signInManager.PasswordSignInAsync(applicationUser.UserName, applicationUser.Password, false,
                    false);

            if (result.Succeeded) return RedirectToAction("SignIn");

            return View(applicationUser);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(ApplicationUser applicationUser)
        {
            var result= _userManager.CreateAsync(applicationUser, applicationUser.Password).GetAwaiter().GetResult();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}