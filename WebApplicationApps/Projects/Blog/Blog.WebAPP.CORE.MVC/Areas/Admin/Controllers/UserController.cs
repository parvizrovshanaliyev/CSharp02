using System.Linq;
using System.Threading.Tasks;
using Blog.Entities.Dtos.User;
using Blog.Services.Abstract;
using Blog.Shared.Extensions;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        #region fields

        private readonly IUserService _service;
        #endregion
        #region ctor
        public UserController(IUserService service)
        {
            _service = service;
        }
        #endregion

        #region methods
        #region loadData
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();

            return View(result);
        }
        #endregion
        #region create

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF
        public async Task<IActionResult> Create(UserAddDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddAsync(request, "Admin");

                if (result.Errors.Any())
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error);
                    }
                }

                if (result.IsSuccess)
                {
                    var successViewModel = new UserCreateAjaxViewModel()
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }
            var errorViewModel = new UserCreateAjaxViewModel()
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

            return PartialView("_UpdatePartial",result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UserUpdateDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(request, "Admin");

                if (result.Errors.Any())
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (result.IsSuccess)
                {
                    var successViewModel = new UserUpdateAjaxViewModel()
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_UpdatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }
            var errorViewModel = new UserUpdateAjaxViewModel()
            {
                UpdateDto = request,
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
