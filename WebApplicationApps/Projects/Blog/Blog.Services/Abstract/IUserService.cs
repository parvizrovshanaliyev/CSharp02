using Blog.Entities.Dtos.User;
using Blog.Shared.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Abstract
{
    public interface IUserService
    {
        Task<IResult<IList<UserDto>>> GetAllAsync();
        Task<IResult<UserUpdateDto>> GetUpdateDtoAsync(int id);
        Task<IResult<UserDto>> AddAsync(UserAddDto dto, string createdByName);
        Task<IResult<UserDto>> UpdateAsync(UserUpdateDto dto, string modifiedByName);
        Task<IResult<bool>> ChangePasswordAsync(UserChangePasswordDto dto);
        Task<IResult<UserDto>> DeleteAsync(int id, string modifiedByName);
        Task<IResult<int>> CountAsync(bool isDeleted = false);
    }
}