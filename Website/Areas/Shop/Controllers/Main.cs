using Microsoft.AspNetCore.Mvc;
using Website.Domain.Contracts;

namespace Website.Areas.Shop.Controllers
{
    [Area("Shop")]
    public class Main : Controller
    {
        private readonly IManageService _manageService;

        public Main(IManageService aManageService)
        {
            _manageService = aManageService;
        }

        public IActionResult Welcome()
        {
            return View(_manageService.GetCategories());
        }
    }
}