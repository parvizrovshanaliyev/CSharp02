using Blog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region fields

        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        #endregion

        #region ctor

        public HomeController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        #endregion

        #region loadData

        [HttpGet]
        public async Task<IActionResult> Index([FromRoute] int? id)
        {
            var result = id.HasValue
                ? await _postService.GetAllByCategoryAsync(id.Value)
                : await _postService.GetAllByNonDeletedAndActiveAsync();

            return View(result);
        }

        #endregion
    }
}