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
    [Area("Admin")]
    [AuthorizeRoles(RoleConstant.Admin, RoleConstant.Editor)]
    public class PostController : Controller
    {
        #region fields

        private readonly IPostService _service;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;
        #endregion

        #region ctor

        public PostController(IPostService service, ICategoryService categoryService, IToastNotification toastNotification)
        {
            _service = service;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }
        #endregion

        #region loadData
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllByNonDeletedAsync();
            return View(result);
        }
        #endregion

        #region create
        [HttpGet]
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
                    {
                        ModelState.AddModelError("", error);
                    }
                return View(request);
            }
            _toastNotification.AddSuccessToastMessage(result.Message);
            return View(request);
        }
        #endregion


        #region Update
        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var result = await _service.GetUpdateDtoAsync(id);
            await FillSelectBox();
            return View(result.Data);
        }

        [HttpPost]
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
                    {
                        ModelState.AddModelError("", error);
                    }
                return View(request);
            }

            _toastNotification.AddSuccessToastMessage(result.Message);
            return View(request);
        }
        #endregion


        #region delete

        [HttpPost]
        public async Task<JsonResult> Delete([FromRoute] int id)
        {
            var result = await _service.DeleteAsync(id);
            return Json(result);
        }
        #endregion

        #region helper

        private async Task FillSelectBox()
        {
            var categoryResult = await _categoryService.GetAllByNonDeletedAsync();

            var categorySelectList = categoryResult.Data.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.Categories = categorySelectList;
        }
        #endregion

    }
}
