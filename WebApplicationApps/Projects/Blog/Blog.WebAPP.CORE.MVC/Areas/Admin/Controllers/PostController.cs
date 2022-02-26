using System.Threading.Tasks;
using Blog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Blog.Shared.Attributes;
using Blog.Shared.Constants;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeRoles(RoleConstant.Admin,RoleConstant.Editor)]
    public class PostController : Controller
    {
        #region fields

        private readonly IPostService _service;
        #endregion

        #region ctor

        public PostController(IPostService service)
        {
            _service = service;
        }
        #endregion

        #region loadData
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllByNonDeletedAsync();
            return View(result);
        }
        #endregion

        #region create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        #endregion

    }
}
