using Blog.Entities.Dtos.Comment;
using Blog.Services.Abstract;
using Blog.Shared.Extensions;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        #region fields

        private readonly ICommentService _service;
        private readonly IPostService _postService;

        #endregion

        #region ctor

        public CommentController(ICommentService service, IPostService postService)
        {
            _service = service;
            _postService = postService;
        }

        #endregion

        #region loadData

        [HttpGet]
        //[AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Comment_Read)]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllByNonDeletedAsync();

            return View(result);
        }

        // TODO: DeletedComments

        [HttpGet]
        //[AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Comment_Read)]
        public async Task<IActionResult> Detail([FromRoute] int id)
        {
            var result = await _service.GetAsync(id);

            return PartialView("_DetailPartial", result.Data);
        }

        #endregion

        #region create

        [HttpGet]
        //[AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Comment_Create)]
        public async Task<IActionResult> Create()
        {
            await FillSelectBox();

            return PartialView("_CreatePartial");
        }

        [HttpPost]
        //[AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Comment_Create)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommentAddDto request)
        {
            if (ModelState.IsValid)
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

            var errorViewModel = new CommentCreateAjaxViewModel
            {
                AddDto = request,
                Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
            };
            await FillSelectBox();
            return Json(errorViewModel);
        }

        #endregion

        #region Update

        [HttpGet]
        //[AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Comment_Update)]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var result = await _service.GetUpdateDtoAsync(id);
            return PartialView("_UpdatePartial", result.Data);
        }

        [HttpPost]
        //[AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Comment_Update)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CommentUpdateDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(request);

                if (result.IsSuccess)
                {
                    var successViewModel = new CommentUpdateAjaxViewModel
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_UpdatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }

            var errorViewModel = new CommentUpdateAjaxViewModel
            {
                Partial = await this.RenderViewToStringAsync("_UpdatePartial", request)
            };

            return Json(errorViewModel);
        }

        #endregion

        #region delete

        [HttpPost]
        //[AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Comment_Delete)]
        public async Task<JsonResult> Delete([FromRoute] int id)
        {
            var result = await _service.DeleteAsync(id);
            return Json(result);
        }

        // TODO : UndoDelete

        // TODO : HardDelete

        #endregion

        private async Task FillSelectBox()
        {
            var result = await _postService.GetAllByNonDeletedAsync();

            var postSelectList = result.Data.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString()
            });

            ViewBag.Posts = postSelectList;
        }
    }
}
