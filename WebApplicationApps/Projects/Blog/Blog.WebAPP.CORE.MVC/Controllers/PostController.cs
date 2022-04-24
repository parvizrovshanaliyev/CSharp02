using Blog.Entities.ComplexTypes;
using Blog.Entities.Dtos.Post;
using Blog.Services.Abstract;
using Blog.WebAPP.CORE.MVC.Attributes;
using Blog.WebAPP.CORE.MVC.Models;
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
        [ViewCountFilter]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var result = await _postService.GetAsync(i => i.Id == id,
                p => p.Comments.Where(c => c.IsActive && c.IsDeleted == false),
                                    p => p.User);

            if (!result.IsSuccess) return NotFound();

            var postDetail = result.Data;

            var filterInput = new PostFilterDto()
            {
                UserId = postDetail.UserId,
                CategoryId = postDetail.CategoryId,
                OrderBy = OrderBy.Date,
                CurrentPage = 1,
                PageSize = 5,
                MinViewCount = 0,
                MaxViewCount = int.MaxValue,
                MinCommentCount = 0,
                MaxCommentCount = int.MaxValue,
            };

            var relatedPostsResult = await _postService.GetAllByPagingAsync(filterInput);

            if (!relatedPostsResult.IsSuccess) return NotFound();

            var postDetailRightSideBarViewModel = new PostDetailRightSideBarViewModel
            {
                Header = "The user's most read posts on the same category.",
                Author = postDetail.User,
                RelatedPosts = relatedPostsResult.Data.Results,
            };


            //await _postService.IncreaseViewCountAsync(result.Data.Id);

            return View((postDetail, postDetailRightSideBarViewModel));
        }

        #endregion
    }
}
