using Blog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Controllers
{
    public class PostController : Controller
    {
        #region fields

        private readonly IPostService _postService;

        #endregion
        #region ctor

        public PostController(IPostService postService)
        {
            _postService = postService;

        }

        #endregion
        #region methods

        [HttpGet]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var postResult = await _postService.GetAsync(i => i.Id == id,
                p => p.Comments.Where(c => c.IsActive && c.IsDeleted == false));
            return View(postResult.Data);
        }

        #endregion
    }
}
