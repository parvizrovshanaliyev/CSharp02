using Blog.Entities.Dtos.Role;
using Blog.Services.Abstract;
using Blog.Shared.Extensions;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        #region fields

        private readonly IRoleService _roleService;

        #endregion
        #region ctor

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #endregion



        #region methods

        #region loadData

        [HttpGet]
        // [AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.Role_Read)]
        public async Task<IActionResult> Index()
        {
            var result = await _roleService.GetAllAsync();
            return View(result);
        }

        #endregion

        #region assignPermission

        [HttpGet]
        //[AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.User_Update)]
        public async Task<IActionResult> Assign([FromRoute] int id)
        {
            var result = await _roleService.GetUserRolesAsync(id);
            return PartialView("_RoleAssignPartial", result.Data);
        }

        [HttpPost]
        //[AuthorizeRoles(RoleConstant.SuperAdmin, RoleConstant.User_Update)]
        public async Task<IActionResult> Assign(UserRoleAssignDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.AssignRolesAsync(request);
                if (result.Errors.Any())
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (result.IsSuccess)
                {
                    var successViewModel = new UserRoleAssignAjaxViewModel()
                    {
                        Result = result,
                        Partial = await this.RenderViewToStringAsync("_RoleAssignPartial", request)
                    };
                    return Json(successViewModel);
                }
            }
            var errorViewModel = new UserRoleAssignAjaxViewModel()
            {
                UserRoleAssignDto = request,
                Partial = await this.RenderViewToStringAsync("_RoleAssignPartial", request)
            };

            return Json(errorViewModel);
        }

        #endregion

        #endregion
    }
}
