using Blog.Entities.Dtos.Post;
using Blog.Services.Abstract;
using Blog.Shared.Attributes;
using Blog.Shared.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        #region fields

        private readonly IPostService _service;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        #endregion

        #region ctor

        public PostController(IPostService service, ICategoryService categoryService,
            IToastNotification toastNotification)
        {
            _service = service;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }

        #endregion

        #region methods

        #region loadData

        [HttpGet]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Post_Read)]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllByNonDeletedAsync();
            return View(result);
        }
        [HttpGet]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Post_Read)]
        public async Task<IActionResult> DeletedPosts()
        {
            var result = await _service.GetAllByDeletedAsync();

            return View(result);
        }
        #endregion

        #region delete

        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Post_Delete)]
        public async Task<JsonResult> Delete([FromRoute] int id)
        {
            var result = await _service.DeleteAsync(id);
            return Json(result);
        }
        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Post_Update)]
        public async Task<JsonResult> UndoDelete([FromRoute] int id)
        {
            var result = await _service.UndoDeleteAsync(id);
            return Json(result);
        }

        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Post_Delete)]
        public async Task<JsonResult> HardDelete([FromRoute] int id)
        {
            var result = await _service.HardDeleteAsync(id);
            return Json(result);
        }
        #endregion

        #region helper

        private async Task FillSelectBox()
        {
            var categoryResult = await _categoryService.GetAllByNonDeletedAsync();

            var categorySelectList = categoryResult.Data.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.Categories = categorySelectList;
        }

        #endregion

        #region create

        [HttpGet]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Post_Create)]
        public async Task<IActionResult> Create()
        {
            // v1 
            //var viewModel = new PostAddViewModel();
            //viewModel.AddDto = new PostAddDto();
            //var result = await _categoryService.GetAllByNonDeletedAsync();
            //viewModel.Categories = result.Data;

            // v2
            await FillSelectBox();

            return View();
        }


        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Post_Create)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostAddDto request)
        {
            await FillSelectBox();

            if (!ModelState.IsValid) return View(request);

            var result = await _service.AddAsync(request);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                if (result.Errors.Any())
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);
                return View(request);
            }

            _toastNotification.AddSuccessToastMessage(result.Message);
            return View(request);
        }

        #endregion

        #region update

        [HttpGet]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Post_Update)]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var result = await _service.GetUpdateDtoAsync(id);
            await FillSelectBox();
            return View(result.Data);
        }

        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Post_Update)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PostUpdateDto request)
        {
            await FillSelectBox();

            if (!ModelState.IsValid) return View(request);

            var result = await _service.UpdateAsync(request);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                if (result.Errors.Any())
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);
                return View(request);
            }

            _toastNotification.AddSuccessToastMessage(result.Message);
            return View(request);
        }

        #endregion

        #endregion
    }
}