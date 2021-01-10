using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.DAL.Implementations;

namespace Website.Areas.Manage.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    [Area("Manage")]
    public class AdminController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}