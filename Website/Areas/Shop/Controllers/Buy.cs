using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Website.Areas.Shop.Controllers
{
    [Authorize]
    public class Buy : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}