using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.User;
using Blog.Services.Abstract;
using Blog.Shared.Enums;
using Blog.Shared.Helpers;
using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class UserManager : BaseServiceResult, IUserService
    {
        #region ctor

        public UserManager(UserManager<User> identityUserManager, IMapper mapper, IUnitOfWork unitOfWork,
            IFileHelper fileHelper,
            IHttpContextAccessor httpContextAccessor, SignInManager<User> signInManager)
        {
            _identityUserManager = identityUserManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileHelper = fileHelper;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
        }

        #endregion

        #region fields

        private readonly UserManager<User> _identityUserManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileHelper _fileHelper;
        private const string DefaultUserAvatarFileName = "Users/defaultUser.png";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<User> _signInManager;

        #endregion

        #region methods

        #region QUERY
        #region GetAsync

        public async Task<IResult<UserDto>> GetAsync(int id)
        {
            var entity = await _unitOfWork.Users.GetAsync(i => i.Id == id);
            if (entity is null)
                return NotFound<UserDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var outputDto = _mapper.Map<UserDto>(entity);
            return Ok(outputDto);
        }


        #endregion
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

        #region GetUpdateDtoAsync

        public async Task<IResult<UserUpdateDto>> GetUpdateDtoAsync(int id)
        {
            var entity = await _identityUserManager.FindByIdAsync(id.ToString());
            if (entity is null)
                return NotFound<UserUpdateDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var outputDto = _mapper.Map<UserUpdateDto>(entity);
            return Ok(outputDto);
        }

        #endregion

        #region CountAsync

        public async Task<IResult<int>> CountAsync(bool isDeleted = false)
        {
            int count = await _unitOfWork.Users.CountAsync();

            return count > -1 ? Ok(count) : NotFound<int>(BaseLocalization.NoDataAvailableOnRequest);
        }

        #endregion

        #endregion

        #region CRUD

        #region Add

        public async Task<IResult<UserDto>> AddAsync(UserAddDto dto, string createdByName)
        {
            var isAlreadyRegister = await _unitOfWork.Users.AnyAsync(i => i.NormalizedEmail == dto.Email.ToUpper()
                                                                          || i.PhoneNumber == dto.PhoneNumber
                                                                          || i.NormalizedUserName ==
                                                                          dto.UserName.ToUpper());
            if (isAlreadyRegister) return Error<UserDto>(BaseLocalization.AlreadyExistUser);

            var entity = _mapper.Map<User>(dto);

            if (dto.File is not null)
            {
                var uploadedResult =
                    await _fileHelper.UploadImageAsync(dto.File, ImageSubDirectoryEnum.User, otherName: dto.UserName);
                if (!uploadedResult.IsSuccess) return Error<UserDto>(uploadedResult.Errors.ToArray());

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

        #region Update

        public async Task<IResult<UserDto>> UpdateAsync(UserUpdateDto dto, string modifiedByName)
        {
            var foundedEntity = await _identityUserManager.FindByIdAsync(dto.Id.ToString());
            if (foundedEntity is null)
                return Error<UserDto>(BaseLocalization.NoDataAvailableOnRequest);
            // id 2         id 3 
            // admin
            // dto.admin    entity.y
            var isAlreadyExistUser = await _unitOfWork.Users.AnyAsync(i =>
                i.Id != foundedEntity.Id && i.NormalizedEmail == dto.Email.ToUpper()
                || i.Id != foundedEntity.Id && i.PhoneNumber == dto.PhoneNumber
                || i.Id != foundedEntity.Id && i.NormalizedUserName == dto.UserName.ToUpper());

            if (isAlreadyExistUser) return Error<UserDto>(BaseLocalization.AlreadyExistUser);

            var oldFileName = foundedEntity.Avatar;
            var isNewFileUploaded = false;

            if (dto.File is not null)
            {
                var uploadedResult =
                    await _fileHelper.UploadImageAsync(dto.File, ImageSubDirectoryEnum.User, otherName: dto.UserName);

                if (!uploadedResult.IsSuccess) return Error<UserDto>(uploadedResult.Errors.ToArray());

                dto.Avatar = uploadedResult.Data.FullName;
                if (!string.Equals(oldFileName, DefaultUserAvatarFileName)) isNewFileUploaded = true;
            }

            var updatedEntity = _mapper.Map(dto, foundedEntity);
            var identityResult = await _identityUserManager.UpdateAsync(updatedEntity);

            if (!identityResult.Succeeded)
            {
                var identityErrors = identityResult.Errors.Select(i => i.Description).ToArray();
                return Error<UserDto>(identityErrors);
            }

            if (isNewFileUploaded) _fileHelper.DeleteImage(oldFileName);

            var outputDto = _mapper.Map<UserDto>(updatedEntity);
            return Updated(outputDto);
        }

        #endregion

        #region DeleteAsync

        public async Task<IResult<UserDto>> DeleteAsync(int id, string modifiedByName)
        {
            var entity = await _identityUserManager.FindByIdAsync(id.ToString());
            if (entity is null)
                return NotFound<UserDto>(BaseLocalization.NotFoundCodeGeneralMessage);

            var identityResult = await _identityUserManager.DeleteAsync(entity);
            if (!identityResult.Succeeded)
            {
                var identityErrors = identityResult.Errors.Select(i => i.Description).ToArray();
                return Error<UserDto>(identityErrors);
            }

            var outputDto = _mapper.Map<UserDto>(entity);
            return Deleted(outputDto);
        }

        #endregion

        #region ChangePasswordAsync

        public async Task<IResult<bool>> ChangePasswordAsync(UserChangePasswordDto dto)
        {
            var user = await _identityUserManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

            var isVerified = await _identityUserManager.CheckPasswordAsync(user, dto.CurrentPassword);

            if (!isVerified)
                return Error<bool>(BaseLocalization.ChangePasswordNotVerified);


            var identityResult =
                await _identityUserManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);

            if (!identityResult.Succeeded)
            {
                var identityErrors = identityResult.Errors.Select(i => i.Description).ToArray();
                return Error<bool>(identityErrors);
            }

            await _identityUserManager.UpdateSecurityStampAsync(user);
            await _signInManager.SignOutAsync();
            await _signInManager.PasswordSignInAsync(user, dto.NewPassword, true, false);
            return Updated(true, BaseLocalization.ChangePasswordSuccessfully);
        }

        #endregion

        #endregion

        #endregion
    }
}