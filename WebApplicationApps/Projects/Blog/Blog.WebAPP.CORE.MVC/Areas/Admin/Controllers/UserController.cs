using System.Linq;
using System.Threading.Tasks;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.User;
using Blog.Services.Abstract;
using Blog.Shared.Attributes;
using Blog.Shared.Constants;
using Blog.Shared.Extensions;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        #region ctor

        public UserController(IUserService service, UserManager<User> userManager, IToastNotification toastNotification)
        {
            _service = service;
            _userManager = userManager;
            _toastNotification = toastNotification;
        }

        #endregion

        #region fields

        private readonly IUserService _service;
        private readonly UserManager<User> _userManager;
        private readonly IToastNotification _toastNotification;

        #endregion

        #region methods

        #region loadData

        [HttpGet]
        [Authorize(Roles = RoleConstant.Admin)]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();

            return View(result);
        }

        #endregion

        #region create

        [HttpGet]
        [Authorize(Roles = RoleConstant.Admin)]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        [HttpPost]
        [Authorize(Roles = RoleConstant.Admin)]
        [ValidateAntiForgeryToken] // CSRF
        public async Task<IActionResult> Create(UserAddDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddAsync(request, "Admin");

                if (result.Errors.Any())
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);

                if (result.IsSuccess)
                {
                    var successViewModel = new UserCreateAjaxViewModel
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }

            var errorViewModel = new UserCreateAjaxViewModel
            {
                AddDto = request,
                Partial = await this.RenderViewToStringAsync("_CreatePartial", request)
            };

            return Json(errorViewModel);
        }

        #endregion

        #region update

        [HttpGet]
        [Authorize(Roles = RoleConstant.Admin)]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _service.GetUpdateDtoAsync(id);
            return PartialView("_UpdatePartial", result.Data);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstant.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UserUpdateDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(request, "Admin");

                if (result.Errors.Any())
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);

                if (result.IsSuccess)
                {
                    var successViewModel = new UserUpdateAjaxViewModel
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_UpdatePartial", request)
                    };
                    return Json(successViewModel);
                }
            }

            var errorViewModel = new UserUpdateAjaxViewModel
            {
                UpdateDto = request,
                Partial = await this.RenderViewToStringAsync("_UpdatePartial", request)
            };

            return Json(errorViewModel);
        }

        #endregion

        #region update profile

        [HttpGet]
        [AuthorizeRoles(RoleConstant.Admin, RoleConstant.Editor)]
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _service.GetUpdateDtoAsync(user.Id);

            return View(result.Data);
        }


        [HttpPost]
        [AuthorizeRoles(RoleConstant.Admin, RoleConstant.Editor)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UserUpdateDto request)
        {
            if (!ModelState.IsValid) return View(request);

            var result = await _service.UpdateAsync(request, "Admin");

            if (result.Errors.Any())
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error);

            if (!result.IsSuccess) return View(request);

            _toastNotification.AddSuccessToastMessage(result.Message);
            return View(request);
        }

        #endregion

        #region change password

        [HttpGet]
        [AuthorizeRoles(RoleConstant.Admin, RoleConstant.Editor)]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        [AuthorizeRoles(RoleConstant.Admin, RoleConstant.Editor)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserChangePasswordDto request)
        {
            if (!ModelState.IsValid) return View(request);
            var result = await _service.ChangePasswordAsync(request);

            if (result.Errors.Any())
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error);

            if (!result.IsSuccess) return View(request);

            _toastNotification.AddSuccessToastMessage(result.Message);
            return View(request);
        }

        #endregion

        #region delete

        [HttpPost]
        [Authorize(Roles = RoleConstant.Admin)]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id, "Admin");
            return Json(result);
        }

        #endregion

        #endregion
    }
}