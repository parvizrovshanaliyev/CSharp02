using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
