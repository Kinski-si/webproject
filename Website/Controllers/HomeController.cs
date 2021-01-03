using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Website.Models;

namespace Website.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context aContext)
        {
            _context = aContext;
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
            var user = _context.Users.SingleOrDefault(x =>
                x.Name.Equals(applicationUser.Name) && x.Password.Equals(applicationUser.Password));

            if (user == null) return View("Login", applicationUser);

            await HttpContext.SignInAsync(Startup.COOKIE,
                new ClaimsPrincipal(new ClaimsIdentity(new[] {new Claim(ClaimTypes.Name, applicationUser.Name)},
                    Startup.COOKIE)));

            return RedirectToAction("SignIn");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(ApplicationUser applicationUser)
        {
            _context.Users.AddAsync(applicationUser);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(Startup.COOKIE);
            return View("Login");
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}