using Blog.Shared.Attributes;
using Blog.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeRoles(RoleConstant.Admin, RoleConstant.Editor)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}