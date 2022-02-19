using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    //[Authorize(Roles = "Admin,Editor")]
    public class HomeController : Controller
    {
        // [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

    }
}
