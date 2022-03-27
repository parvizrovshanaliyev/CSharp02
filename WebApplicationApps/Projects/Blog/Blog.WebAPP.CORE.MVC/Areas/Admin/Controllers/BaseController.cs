using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BaseController : Controller
    {
    }
}
