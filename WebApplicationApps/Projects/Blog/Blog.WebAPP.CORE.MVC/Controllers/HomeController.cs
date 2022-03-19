using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}