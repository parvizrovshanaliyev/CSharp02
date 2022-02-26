using System.Linq;
using System.Threading.Tasks;
using Blog.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Blog.Entities.Dtos.Auth;
using Blog.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        #region fields
        private readonly IAuthService _authService;
        private readonly SignInManager<User> _signInManager;
        #endregion


        #region ctor
        public AuthController(IAuthService authService, SignInManager<User> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
        }
        #endregion


        #region login logout
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto request, string ReturnUrl)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _authService.LoginAsync(request);

            if (result.IsSuccess)
                return RedirectToAction("Index", "Home");

            if (result.Errors.Any())
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error);
                }
            }

            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Auth");
        }

        #endregion

        #region access denied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion


    }
}
