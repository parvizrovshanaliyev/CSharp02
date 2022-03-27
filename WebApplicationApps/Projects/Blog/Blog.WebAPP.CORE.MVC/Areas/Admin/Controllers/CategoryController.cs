using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Attributes;
using Blog.Shared.Constants;
using Blog.Shared.Extensions;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
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
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Read)]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllByNonDeletedAsync();
            return View(result);
        }

        [HttpGet]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Read)]
        public async Task<JsonResult> GetAll()
        {
            var result = await _service.GetAllByNonDeletedAsync();

            return Json(result.Data);
        }

        [HttpGet]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Read)]
        public async Task<IActionResult> DeletedCategories()
        {
            var result = await _service.GetAllByDeletedAsync();

            return View(result);
        }

        #endregion

        #region create

        [HttpGet]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Create)]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Create)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryAddDto request)
        {
            if (ModelState.IsValid) //== true
            {
                var result = await _service.AddAsync(request);

                if (result.IsSuccess)
                {
                    var successViewModel = new CategoryCreateAjaxViewModel
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }

            var errorViewModel = new CategoryCreateAjaxViewModel
            {
                AddDto = request,
                Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
            };

            return Json(errorViewModel);
        }

        #endregion

        #region update

        [HttpGet]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Update)]

        public async Task<IActionResult> Update(int id)
        {
            var result = await _service.GetUpdateDtoAsync(id);
            return PartialView("_UpdatePartial", result.Data);
        }


        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Update)]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CategoryUpdateDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(request, "Admin");

                if (result.IsSuccess)
                {
                    var successViewModel = new CategoryUpdateAjaxViewModel
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_UpdatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }

            var errorViewModel = new CategoryUpdateAjaxViewModel
            {
                Partial = await this.RenderViewToStringAsync("_UpdatePartial", request)
            };

            return Json(errorViewModel);
        }

        #endregion

        #region delete

        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Delete)]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id, "Admin");
            return Json(result);
        }
        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Update)]
        public async Task<JsonResult> UndoDelete([FromRoute] int id)
        {
            var result = await _service.UndoDeleteAsync(id);
            return Json(result);
        }

        [HttpPost]
        [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Category_Delete)]
        public async Task<JsonResult> HardDelete([FromRoute] int id)
        {
            var result = await _service.HardDeleteAsync(id);
            return Json(result);
        }
        #endregion

        #endregion
    }
}