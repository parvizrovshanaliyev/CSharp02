using Blog.Services.Abstract;
using Blog.WebAPP.CORE.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.ViewComponents
{
    public class RightSideBarViewComponent : ViewComponent
    {
        #region fields

        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        #endregion

        #region ctor

        public RightSideBarViewComponent(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryResult = await _categoryService.GetAllByNonDeletedAsync();
            var postResult = await _postService.GetAllByViewCountAsync(false, 5);
            return View(new RightSideBarViewModel
            {
                Categories = categoryResult.Data,
                Posts = postResult.Data
            });
        }
    }
}
