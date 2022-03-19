using Blog.Entities.Concrete;
using Blog.Entities.Dtos.Auth;
using Blog.Services.Abstract;
using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class AuthManager : BaseServiceResult, IAuthService
    {
        #region fields

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthManager(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        #endregion

        #region ctor

        #endregion

        #region methods

        #region login

        public async Task<IResult<bool>> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null)
                return Error<bool>(BaseLocalization.NoDataAvailableOnRequest);

            var signInResult = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, false);

            if (!signInResult.Succeeded)
                return Error<bool>(BaseLocalization.LoginFailed);

            return Ok(true);
        }

        #endregion

        #endregion
    }
}