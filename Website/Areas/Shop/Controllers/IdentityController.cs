using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website.Domain.Contracts;
using Website.Domain.Contracts.Models;

namespace Website.Areas.Shop.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService aIdentityService, AuthorizeForm aAuthorizeForm)
        {
            _identityService = aIdentityService;
        }

        public IActionResult Identity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthorizeForm aAuthorizeForm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Identity", aAuthorizeForm);
            }
            await _identityService.RegisterUserAsync(aAuthorizeForm.RegisterForm);
            return RedirectToAction("Identity");
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthorizeForm aAuthorizeForm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Identity", aAuthorizeForm);
            }

            var user = await _identityService.FindUser(aAuthorizeForm.LoginForm);
            if (user == null)
            {
                // TODO: required another handler
                return RedirectToAction("Identity", aAuthorizeForm);
            }

            await _identityService.SignInUserAsync(user, aAuthorizeForm.LoginForm);
            return RedirectToAction("Identity");
        }
    }
}