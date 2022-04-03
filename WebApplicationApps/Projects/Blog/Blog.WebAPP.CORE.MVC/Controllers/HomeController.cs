using Blog.Entities.Dtos.Post;
using Blog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region fields

        private readonly IPostService _postService;

        #endregion

        #region ctor

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        #endregion

        #region loadData

        [HttpGet]
        public async Task<IActionResult> Index(PostFilterDto request)
        {
            var result = await _postService.GetAllByPagingAsync(request);
            ViewBag.CategoryId = request.CategoryId;
            ViewBag.IsAsc = request.IsAsc;
            return View(result);
        }

        #endregion
    }
}