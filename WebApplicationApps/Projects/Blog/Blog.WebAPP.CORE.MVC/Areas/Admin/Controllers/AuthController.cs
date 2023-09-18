using Blog.Entities.Concrete;
using Blog.Entities.Dtos.Auth;
using Blog.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    public class AuthController : BaseController
    {
        #region ctor

        public AuthController(IAuthService authService, SignInManager<User> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
        }

        #endregion
        #region fields

        private readonly IAuthService _authService;
        private readonly SignInManager<User> _signInManager;

        #endregion
        #region login logout

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto request, string ReturnUrl)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _authService.LoginAsync(request);

            if (result.IsSuccess)
                return RedirectToAction("Index", "Home");

            if (result.Errors.Any())
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error);

            return View(request);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Auth");
        }

        #endregion
        #region access denied

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion
    }
}