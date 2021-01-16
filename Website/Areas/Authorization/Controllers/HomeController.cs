﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.Domain.Contracts;
using Website.Domain.Contracts.Models;

namespace Website.Areas.Authorization.Controllers
{
    [Area("Authorization")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IIdentityService _authorizeService;

        public HomeController(IIdentityService aAuthorizeService)
        {
            _authorizeService = aAuthorizeService;
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
        public async Task<IActionResult> Login(LoginForm aLoginModel)
        {
            if (!ModelState.IsValid) return View(aLoginModel);

            var user = await _authorizeService.FindUser(aLoginModel);

            if (user == null) return View(aLoginModel);

            var result = await _authorizeService.SignInUserAsync(user, aLoginModel);

            if (result.Succeeded) return RedirectToAction("LoggedIn");

            return View(aLoginModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterForm aRegisterViewModel)
        {
            if (!ModelState.IsValid) return View(aRegisterViewModel);

            await _authorizeService.RegisterUserAsync(aRegisterViewModel);
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _authorizeService.SignOutUserAsync();
            return View("Login");
        }

        public IActionResult LoggedIn()
        {
            return RedirectToAction("Welcome", "Main", new {area = "Shop"});
        }

        public string Denied()
        {
            return "You don't have an access to this page.";
        }
    }
}