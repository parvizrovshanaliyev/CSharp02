using Blog.Entities.Dtos.Comment;
using Blog.Services.Abstract;
using Blog.Shared.Extensions;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Controllers
{
    public class CommentController : Controller
    {
        #region fields

        private readonly ICommentService _service;

        #endregion

        #region ctor

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        #endregion

        #region methods
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommentAddDto request)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(request.CreatedBy))
            {
                var result = await _service.AddAsync(request);

                if (result.IsSuccess)
                {
                    var successViewModel = new CommentCreateAjaxViewModel
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }

            if (string.IsNullOrEmpty(request.CreatedBy))
            {
                ModelState.AddModelError("CreatedBy", "Created By Name is required");
            }

            var errorViewModel = new CommentCreateAjaxViewModel
            {
                AddDto = request,
                Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
            };
            return Json(errorViewModel);
        }
        #endregion
    }
}
