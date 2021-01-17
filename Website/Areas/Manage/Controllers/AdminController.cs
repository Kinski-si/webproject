using Microsoft.AspNetCore.Mvc;

namespace Website.Areas.Manage.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
