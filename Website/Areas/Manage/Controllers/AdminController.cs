using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.DAL.Implementations;
using Website.Domain.Contracts;
using Website.Domain.Contracts.Models;

namespace Website.Areas.Manage.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    [Area("Manage")]
    public class AdminController : Controller
    {
        private readonly IProductService _manageService;

        public AdminController(IProductService aManageService)
        {
            _manageService = aManageService;
        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category aCategory)
        {
            _manageService.AddCategory(aCategory);
            return RedirectToAction("Main", "Admin");
        }
    }
}