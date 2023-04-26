using Blog.Entities.Dtos.Role;
using Blog.Shared.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Abstract
{
    public interface IRoleService
    {
        Task<IResult<bool>> AssignRolesAsync(UserRoleAssignDto dto);
        Task<IResult<UserRoleAssignDto>> GetUserRolesAsync(int userId);
        Task<IResult<IList<RoleDto>>> GetAllAsync();
    }
}
