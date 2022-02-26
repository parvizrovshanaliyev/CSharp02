using System.Threading.Tasks;
using Blog.Entities.Concrete;
using Blog.WebAPP.CORE.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.ViewComponents
{
    public class DashboardUserTopBarViewComponent : ViewComponent
    {
        #region fields
        private readonly UserManager<User> _userManager;
        #endregion
        #region ctor

        public DashboardUserTopBarViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var viewModel = new UserViewModel()
            {
                User = user
            };
            return View(viewModel);
        }
    }
}
