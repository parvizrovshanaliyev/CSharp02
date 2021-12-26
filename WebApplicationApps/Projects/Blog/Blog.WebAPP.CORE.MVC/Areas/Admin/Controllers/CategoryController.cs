using System.Threading.Tasks;
using Blog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        #region .::fields::.

        private readonly ICategoryService _categoryService;

        #endregion

        #region .::ctor::.

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllAsync();

            return View(result.Data);
        }
    }
}
