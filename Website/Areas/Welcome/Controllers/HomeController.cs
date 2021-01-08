using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Website.Areas.Welcome.ViewModels;
using Website.Identity;

namespace Website.Areas.Welcome.Controllers
{
    [Area("Welcome")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public HomeController(UserManager<UserModel> aManager,
            SignInManager<UserModel> aSignInManager)
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
        public async Task<IActionResult> Login(LoginViewModel aLoginModel)
        {
            var user = await _userManager.FindByNameAsync(aLoginModel.Name);

            if (user == null) return View(aLoginModel);

            var result = await _signInManager.PasswordSignInAsync(aLoginModel.Name, aLoginModel.Password,
                aLoginModel.RememberMe, false);

            if (result.Succeeded) return RedirectToAction("LoggedIn");

            return View(aLoginModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel aRegisterViewModel)
        {
            var result = await _userManager.CreateAsync(new UserModel
            {
                UserName = aRegisterViewModel.Name,
                Email = aRegisterViewModel.Email,
            }, aRegisterViewModel.Password);

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }

        public IActionResult LoggedIn()
        {
            return View();
        }
    }
}