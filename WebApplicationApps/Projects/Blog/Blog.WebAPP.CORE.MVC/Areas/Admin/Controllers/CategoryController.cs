using System.Threading.Tasks;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Attributes;
using Blog.Shared.Constants;
using Blog.Shared.Extensions;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeRoles(RoleConstant.Admin, RoleConstant.Editor)]
    public class CategoryController : Controller
    {
        #region .::fields::.

        private readonly ICategoryService _service;

        #endregion

        #region .::ctor::.

        public CategoryController(ICategoryService categoryService)
        {
            _service = categoryService;
        }

        #endregion

        #region methods


        #region loadData
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllByNonDeletedAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var result = await _service.GetAllByNonDeletedAsync();

            return Json(result.Data);
        }

        #endregion

        #region create
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryAddDto request)
        {
            if (ModelState.IsValid) //== true
            {
                var result = await _service.AddAsync(request, "Admin");

                if (result.IsSuccess)
                {
                    var successViewModel = new CategoryCreateAjaxViewModel()
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }
            var errorViewModel = new CategoryCreateAjaxViewModel()
            {
                AddDto = request,
                Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
            };

            return Json(errorViewModel);
        }
        #endregion

        #region update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _service.GetUpdateDtoAsync(id);
            return PartialView("_UpdatePartial", result.Data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CategoryUpdateDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(request, "Admin");

                if (result.IsSuccess)
                {
                    var successViewModel = new CategoryUpdateAjaxViewModel()
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_UpdatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }

            var errorViewModel = new CategoryUpdateAjaxViewModel()
            {
                Partial = await this.RenderViewToStringAsync("_UpdatePartial", request)
            };

            return Json(errorViewModel);
        }


        #endregion

        #region delete
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id, "Admin");
            return Json(result);
        }
        #endregion

        #endregion
    }
}
