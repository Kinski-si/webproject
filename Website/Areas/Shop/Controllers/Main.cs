using Microsoft.AspNetCore.Mvc;
using Website.Domain.Contracts;

namespace Website.Areas.Shop.Controllers
{
    [Area("Shop")]
    public class Main : Controller
    {
        private readonly IProductService _manageService;

        public Main(IProductService aManageService)
        {
            _manageService = aManageService;
        }

        public IActionResult Welcome()
        {
            return View(_manageService.GetCategories());
        }
    }
}