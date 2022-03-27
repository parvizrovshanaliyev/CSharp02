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
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 6)
        {
            var result = await _postService.GetAllByPagingAsync(categoryId, currentPage, pageSize);
            ViewBag.CategoryId = categoryId;
            return View(result);
        }

        #endregion
    }
}