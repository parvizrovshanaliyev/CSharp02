using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.Role;
using Blog.Services.Abstract;
using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class RoleManager : BaseServiceResult, IRoleService
    {
        #region fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        #endregion

        #region ctor

        public RoleManager(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            RoleManager<Role> roleManager,
            UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        #endregion

        #region methods

        #region QUERY

        #region GetUserRolesAsync

        public async Task<IResult<UserRoleAssignDto>> GetUserRolesAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
                return NotFound<UserRoleAssignDto>(BaseLocalization.NotFoundCodeGeneralMessage);

            var dto = new UserRoleAssignDto
            {
                UserId = userId,
                UserName = user.UserName,
            };

            var roles = await _roleManager.Roles.ToListAsync();

            if (!roles.Any())
                return Ok(dto);

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                dto.Roles.Add(new()
                {
                    Id = role.Id,
                    Name = role.Name,
                    IsAssigned = userRoles.Any() && userRoles.Contains(role.Name)
                });
            }

            return Ok(dto);
        }

        #endregion

        #region GetAllAsync

        public async Task<IResult<IList<RoleDto>>> GetAllAsync()
        {
            var entities = await _roleManager.Roles.ToListAsync();
            if (entities == null)
                return NotFound<IList<RoleDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<RoleDto>>(entities);
            return Ok(outputDto);
        }

        #endregion

        #endregion

        #region CRUD

        #region AssignRolesAsync

        public async Task<IResult<bool>> AssignRolesAsync(UserRoleAssignDto dto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId.ToString());

                if (user is null)
                    return NotFound<bool>(BaseLocalization.NotFoundCodeGeneralMessage);

                var userRoles = await _userManager.GetRolesAsync(user);

                if (userRoles.Any())
                {
                    var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles);

                    if (!removeResult.Succeeded)
                    {
                        var errors = removeResult.Errors.Select(i => i.Description).ToArray();

                        return Error<bool>(errors);
                    }
                }
                var assignedRoles = dto.Roles.Where(i => i.IsAssigned).Select(i => i.Name).ToArray();

                if (!assignedRoles.Any())
                    return Ok(true);

                var addResult = await _userManager.AddToRolesAsync(user, assignedRoles);

                if (!addResult.Succeeded)
                {
                    var errors = addResult.Errors.Select(i => i.Description).ToArray();

                    return Error<bool>(errors);
                }

                await _userManager.UpdateSecurityStampAsync(user);
                return Updated(true);
            }
            catch (Exception e)
            {
                return Error<bool>(e.Message);
            }
        }

        #endregion

        #endregion

        #endregion

    }
}
