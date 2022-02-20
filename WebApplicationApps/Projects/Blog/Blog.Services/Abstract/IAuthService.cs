using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities.Dtos.Auth;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.Services.Abstract
{
    public interface IAuthService
    {
        Task<IResult<bool>> LoginAsync(LoginDto dto);
    }
}
