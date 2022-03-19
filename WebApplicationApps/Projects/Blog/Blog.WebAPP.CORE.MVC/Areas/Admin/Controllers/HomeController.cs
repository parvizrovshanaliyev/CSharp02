using Blog.Services.Abstract;
using Blog.Shared.Attributes;
using Blog.Shared.Constants;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeRoles(RoleConstant.Admin, RoleConstant.Editor)]
    public class HomeController : Controller
    {
        #region fields

        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        #endregion
        #region ctor

        public HomeController(ICategoryService categoryService, IUserService userService, IPostService postService, ICommentService commentService)
        {
            _categoryService = categoryService;
            _userService = userService;
            _postService = postService;
            _commentService = commentService;
        }
        #endregion
        // GET
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel();
            var categoriesCountResult = await _categoryService.CountAsync();
            var postsCountResult = await _postService.CountAsync();
            var commentsCountResult = await _commentService.CountAsync();
            var usersCountResult = await _userService.CountAsync();
            // TODO: LastPublishedPosts
            if (categoriesCountResult.IsSuccess && postsCountResult.IsSuccess && usersCountResult.IsSuccess &&
                commentsCountResult.IsSuccess)
            {
                viewModel.CategoriesCount = categoriesCountResult.Data;
                viewModel.PostsCount = postsCountResult.Data;
                viewModel.CommentsCount = commentsCountResult.Data;
                viewModel.UsersCount = usersCountResult.Data;

            }
            return View(viewModel);
        }
    }
}