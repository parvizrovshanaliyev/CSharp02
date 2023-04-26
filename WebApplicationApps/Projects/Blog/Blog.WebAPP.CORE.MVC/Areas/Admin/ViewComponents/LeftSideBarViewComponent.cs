using System.Threading.Tasks;
using Blog.Entities.Concrete;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.ViewComponents
{
    public class LeftSideBarViewComponent : ViewComponent
    {
        #region fields

        private readonly UserManager<User> _userManager;

        #endregion

        #region ctor

        public LeftSideBarViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var roles = await _userManager.GetRolesAsync(user);

            var viewModel = new UserWithRolesViewModel
            {
                User = user,
                Roles = roles
            };
            return View(viewModel);
        }
    }
}