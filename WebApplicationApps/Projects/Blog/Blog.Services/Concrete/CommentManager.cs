using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.Comment;
using Blog.Services.Abstract;
using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class CommentManager : BaseServiceResult, ICommentService
    {
        #region fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User CurrentUser => _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User).Result;
        #endregion

        #region ctor

        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region methods
        #region QUERY
        #region GetAsync
        public async Task<IResult<CommentDto>> GetAsync(int id)
        {
            var entity = await _unitOfWork.Comments.GetAsync(i => i.Id == id);
            if (entity is null)
                return NotFound<CommentDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var outputDto = _mapper.Map<CommentDto>(entity);
            return Ok(outputDto);
        }
        #endregion
        #region GetUpdateDtoAsync
        public async Task<IResult<CommentUpdateDto>> GetUpdateDtoAsync(int id)
        {
            var entity = await _unitOfWork.Comments.GetAsync(i => i.Id == id);
            if (entity is null)
                return NotFound<CommentUpdateDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var outputDto = _mapper.Map<CommentUpdateDto>(entity);
            return Ok(outputDto);
        }
        #endregion
        #region GetAllAsync
        public async Task<IResult<IList<CommentDto>>> GetAllAsync()
        {
            var entities = await _unitOfWork.Comments.GetAllAsync();

            if (entities == null)
                return NotFound<IList<CommentDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<CommentDto>>(entities);
            return Ok(outputDto);
        }
        #endregion
        #region  GetAllByNonDeletedAsync
        public async Task<IResult<IList<CommentDto>>> GetAllByNonDeletedAsync()
        {
            var entities = await _unitOfWork.Comments.GetAllAsync(c => !c.IsDeleted, c => c.Post);

            if (entities == null)
                return NotFound<IList<CommentDto>>(BaseLocalization.NoDataAvailableOnRequest);

            var outputDto = _mapper.Map<IList<CommentDto>>(entities);

            return Ok(outputDto);
        }

        #endregion
        #region  GetAllByDeletedAsync
        public async Task<IResult<IList<CommentDto>>> GetAllByDeletedAsync()
        {
            var entities = await _unitOfWork.Comments.GetAllAsync(c => c.IsDeleted, c => c.Post);

            if (entities == null)
                return NotFound<IList<CommentDto>>(BaseLocalization.NoDataAvailableOnRequest);

            var outputDto = _mapper.Map<IList<CommentDto>>(entities);

            return Ok(outputDto);
        }
        #endregion
        #region     GetAllByNonDeletedAndActiveAsync
        public async Task<IResult<IList<CommentDto>>> GetAllByNonDeletedAndActiveAsync()
        {
            var entities = await _unitOfWork.Comments.GetAllAsync(c => !c.IsDeleted && c.IsActive);
            if (entities == null)
                return NotFound<IList<CommentDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<CommentDto>>(entities);
            return Ok(outputDto);

        }
        #endregion
        #region   GetAllByPostAsync
        public Task<IResult<IList<CommentDto>>> GetAllByPostAsync(int postId)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region GetAllByCommentAsync
        public async Task<IResult<IList<CommentDto>>> GetAllByCommentAsync(int postId)
        {
            // get all comments by post id
            var entities = await _unitOfWork.Comments.GetAllAsync(c =>
                !c.IsDeleted && c.Post.Id == postId,
            includeProperties: c => c.Post);
            if (entities == null)
                return NotFound<IList<CommentDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<CommentDto>>(entities);
            return Ok(outputDto);
        }
        #endregion
        #region CountAsync
        public async Task<IResult<int>> CountAsync(bool isDeleted = false)
        {
            int count = await _unitOfWork.Comments.CountAsync(c => c.IsDeleted == isDeleted);

            return count > -1 ? Ok(count) : NotFound<int>(BaseLocalization.NoDataAvailableOnRequest);
        }
        #endregion
        #endregion
        #region CRUD
        #region AddAsync

        public async Task<IResult<CommentDto>> AddAsync(CommentAddDto dto)
        {


            var post = await _unitOfWork.Posts.GetAsync(i => i.Id == dto.PostId);

            if (post is null)
                return NotFound<CommentDto>(BaseLocalization.NotFoundCodeGeneralMessage);

            var entity = _mapper.Map<Comment>(dto);

            if (CurrentUser is not null)
            {
                entity.SetCreatedByName(CurrentUser.UserName);
                entity.UserId = CurrentUser.Id;
            }
            else if (!string.IsNullOrEmpty(dto.CreatedBy))
            {
                entity.SetCreatedByName(dto.CreatedBy);
            }

            var createdEntity = await _unitOfWork.Comments.AddAsync(entity);

            post.IncreaseCommentCount();
            await _unitOfWork.Posts.UpdateAsync(post);

            await _unitOfWork.SaveChangesAsync();
            var outputDto = _mapper.Map<CommentDto>(createdEntity);
            return Created(outputDto);
        }

        #endregion
        #region UpdateAsync

        public async Task<IResult<CommentDto>> UpdateAsync(CommentUpdateDto dto)
        {
            if (CurrentUser is null) return Unauthorized<CommentDto>();
            var foundedEntity = await _unitOfWork.Comments.GetAsync(i => i.Id == dto.Id, includeProperties: i => i.Post);
            if (foundedEntity is null)
                return NotFound<CommentDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var entity = _mapper.Map(dto, foundedEntity);
            entity.SetModifiedByName(CurrentUser.UserName);
            var updatedEntity = await _unitOfWork.Comments.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var outputDto = _mapper.Map<CommentDto>(updatedEntity);
            return Updated(outputDto);
        }

        #endregion
        #region DeleteAsync
        public async Task<IResult<CommentDto>> DeleteAsync(int id)
        {
            if (CurrentUser is null) return Unauthorized<CommentDto>();
            var entity = await _unitOfWork.Comments.GetAsync(c => c.Id == id, includeProperties: c => c.Post);
            if (entity is null)
                return NotFound<CommentDto>(BaseLocalization.NoDataAvailableOnRequest);
            var post = entity.Post;
            entity.SetIsDeleted(true);
            entity.SetModifiedByName(CurrentUser.UserName);
            var deletedEntity = await _unitOfWork.Comments.UpdateAsync(entity);
            post.IncreaseCommentCount();
            await _unitOfWork.SaveChangesAsync();
            var outputDto = _mapper.Map<CommentDto>(deletedEntity);
            return Deleted(outputDto);
        }
        public async Task<IResult<CommentDto>> UndoDeleteAsync(int id)
        {
            if (CurrentUser is null) return Unauthorized<CommentDto>();
            var entity = await _unitOfWork.Comments.GetAsync(c => c.Id == id, c => c.Post);

            if (entity is null)
                return NotFound<CommentDto>(BaseLocalization.NoDataAvailableOnRequest);
            var post = entity.Post;
            entity.SetIsDeleted(false);
            entity.SetModifiedByName(CurrentUser.UserName);
            var deletedEntity = await _unitOfWork.Comments.UpdateAsync(entity);
            post.IncreaseCommentCount();
            await _unitOfWork.Posts.UpdateAsync(post);
            await _unitOfWork.SaveChangesAsync();
            var outputDto = _mapper.Map<CommentDto>(deletedEntity);
            return UndoDeleted(outputDto);
        }

        public async Task<IResult<bool>> HardDeleteAsync(int id)
        {
            var entity = await _unitOfWork.Comments.GetAsync(c => c.Id == id, includeProperties: c => c.Post);

            if (entity == null)
                return NotFound<bool>(BaseLocalization.NoDataAvailableOnRequest);
            var post = entity.Post;
            post.CommentCount = await _unitOfWork.Comments.CountAsync(c => c.PostId == post.Id && !c.IsDeleted && c.IsActive);
            await _unitOfWork.Posts.UpdateAsync(post);
            await _unitOfWork.Comments.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Deleted(true);
        }
        #endregion
        #endregion
        #endregion
    }
}
