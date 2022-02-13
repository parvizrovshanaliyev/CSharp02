using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.User;
using Blog.Services.Abstract;
using Blog.Shared.Helpers;
using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services.Concrete
{
    public class UserManager : BaseServiceResult, IUserService
    {
        #region fields
        private readonly UserManager<User> _identityUserManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileHelper _fileHelper;
        private const string DefaultUserAvatarFileName = "Users/defaultUser.png";

        #endregion

        #region ctor

        public UserManager(UserManager<User> identityUserManager, IMapper mapper, IUnitOfWork unitOfWork, IFileHelper fileHelper)
        {
            _identityUserManager = identityUserManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileHelper = fileHelper;
        }

        #endregion


        #region Implementation of IUserService

        #region QUERY
        #region GetAllAsync
        public async Task<IResult<IList<UserDto>>> GetAllAsync()
        {
            var entities = await _identityUserManager.Users.ToListAsync();
            if (entities is null)
                return NotFound<IList<UserDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<UserDto>>(entities);
            return Ok(outputDto);
        }

        #endregion
        #endregion
        #region CRUD

        #region Add
        public async Task<IResult<UserDto>> AddAsync(UserAddDto dto, string createdByName)
        {
            bool isAlreadyRegister = await _unitOfWork.Users.AnyAsync(i => i.NormalizedEmail == dto.Email.ToUpper()
                                                                               || i.PhoneNumber == dto.PhoneNumber
                                                                               || i.NormalizedUserName == dto.UserName.ToUpper());
            if (isAlreadyRegister)
            {
                return Error<UserDto>(BaseLocalization.AlreadyExistUser);
            }

            var entity = _mapper.Map<User>(dto);

            if (dto.File is not null)
            {
                var uploadedResult = await _fileHelper.UploadImageAsync(dto.File, "Users", dto.UserName);
                if (!uploadedResult.IsSuccess)
                {
                    return Error<UserDto>(uploadedResult.Errors.ToArray());
                }

                entity.Avatar = uploadedResult.Data.FullName;
            }
            else
            {
                entity.Avatar = DefaultUserAvatarFileName;
            }


            var identityResult = await _identityUserManager.CreateAsync(entity, dto.Password);

            if (!identityResult.Succeeded)
            {
                _fileHelper.DeleteImage(entity.Avatar);
                var identityErrors = identityResult.Errors.Select(i => i.Description).ToArray();
                return Error<UserDto>(identityErrors);
            }

            var outputDto = _mapper.Map<UserDto>(entity);
            return Created(outputDto);
        }


        #endregion
        #endregion
        #endregion
    }
}
