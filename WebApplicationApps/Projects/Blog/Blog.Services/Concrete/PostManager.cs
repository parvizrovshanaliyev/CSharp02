using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Data.Abstract;
using Blog.Entities.ComplexTypes;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.Post;
using Blog.Services.Abstract;
using Blog.Shared.Enums;
using Blog.Shared.Extensions;
using Blog.Shared.Helpers;
using Blog.Shared.Localizations;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.Concrete;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class PostManager : BaseServiceResult, IPostService
    {
        #region ctor

        public PostManager(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetService<IUnitOfWork>();
            _mapper = serviceProvider.GetService<IMapper>();
            _fileHelper = serviceProvider.GetService<IFileHelper>();
            _userManager = serviceProvider.GetService<UserManager<User>>();
            _httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
        }

        #endregion

        #region fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User CurrentUser => _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User).Result;

        #endregion

        #region methods

        #region QUERY

        public async Task<IResult<PostDto>> GetAsync(int id)
        {
            var entity = await _unitOfWork.Posts.GetAsync(i => i.Id == id);
            if (entity is null)
                return NotFound<PostDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var outputDto = _mapper.Map<PostDto>(entity);
            return Ok(outputDto);
        }

        public async Task<IResult<PostDto>> GetAsync(Expression<Func<Post, bool>> predicate, params Expression<Func<Post, object>>[] includeProperties)
        {
            var entity = await _unitOfWork.Posts.GetAsync(predicate, includeProperties);
            if (entity is null)
                return NotFound<PostDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var outputDto = _mapper.Map<PostDto>(entity);
            return Ok(outputDto);
        }

        public async Task<IResult<PostUpdateDto>> GetUpdateDtoAsync(int id)
        {
            var entity = await _unitOfWork.Posts.GetAsync(i => i.Id == id);
            if (entity is null)
                return NotFound<PostUpdateDto>(BaseLocalization.NotFoundCodeGeneralMessage);
            var outputDto = _mapper.Map<PostUpdateDto>(entity);
            return Ok(outputDto);
        }

        public async Task<IResult<IList<PostDto>>> GetAllAsync()
        {
            var entities = await _unitOfWork.Posts.GetAllAsync(null, i => i.Category);

            if (entities == null)
                return NotFound<IList<PostDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<PostDto>>(entities);
            return Ok(outputDto);
        }

        public async Task<IResult<PagedResult<PostDto>>> GetAllByPagingAsync(PostFilterDto filter)
        {
            var predicate = ExpressionStarter(filter);

            var query = _unitOfWork.Posts.Query(predicate,
                null,
                false,
                i => i.Category,
                i => i.User).ProjectTo<PostDto>(_mapper.ConfigurationProvider);

            query = OrderByQuery(filter, query);

            var pagedResult = filter.CurrentPage.HasValue && filter.PageSize.HasValue
                ? await query.GetManyAndPaginate(filter.CurrentPage.Value, filter.PageSize.Value > 18 ? 18 : filter.PageSize.Value)
                : await query.GetManyAndPaginate();

            if (pagedResult == null)
                return NotFound<PagedResult<PostDto>>(BaseLocalization.NoDataAvailableOnRequest);

            return Ok(pagedResult);
        }

        private static IQueryable<PostDto> OrderByQuery(PostFilterDto filter, IQueryable<PostDto> query)
        {
            // check filter.OrderBy.has value
            if (filter.OrderBy.HasValue)
            {

                query = filter.OrderBy.Value switch
                {
                    OrderBy.Date => filter.IsAsc
                        ? query.OrderBy(i => i.Date)
                        : query.OrderByDescending(i => i.Date),
                    OrderBy.ViewCount => filter.IsAsc
                        ? query.OrderBy(i => i.ViewsCount)
                        : query.OrderByDescending(i => i.ViewsCount),
                    OrderBy.CommentCount => filter.IsAsc
                        ? query.OrderBy(i => i.CommentsCount)
                        : query.OrderByDescending(i => i.CommentsCount),
                    _ => filter.IsAsc
                        ? query.OrderBy(i => i.Date)
                        : query.OrderByDescending(i => i.Date)
                };
            }
            return query;
        }

        private static ExpressionStarter<Post> ExpressionStarter(PostFilterDto filter)
        {
            var predicate = PredicateBuilder.New<Post>(true);

            predicate = predicate.And(i => i.IsDeleted == false && i.IsActive == true);

            if (filter.CategoryId.HasValue)
                predicate = predicate.And(i => i.CategoryId == filter.CategoryId.Value);
            if (filter.UserId.HasValue)
                predicate = predicate.And(i => i.UserId == filter.UserId.Value);
            if (filter.FromDate.HasValue)
                predicate = predicate.And(i => i.CreatedDate >= filter.FromDate.Value);
            if (filter.ToDate.HasValue)
                predicate = predicate.And(i => i.CreatedDate <= filter.ToDate.Value);
            if (filter.MinViewCount.HasValue)
                predicate = predicate.And(i => i.ViewsCount >= filter.MinCommentCount.Value);
            if (filter.MaxViewCount.HasValue)
                predicate = predicate.And(i => i.ViewsCount <= filter.MaxViewCount.Value);
            if (filter.MinCommentCount.HasValue)
                predicate = predicate.And(i => i.CommentCount >= filter.MinCommentCount.Value);
            if (filter.MaxCommentCount.HasValue)
                predicate = predicate.And(i => i.CommentCount <= filter.MaxCommentCount.Value);

            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                var keyword = filter.Keyword.ToLower();

                predicate = predicate.And(i => i.Title.ToLower().Contains(keyword)
                                               || i.Content.ToLower().Contains(keyword)
                                               || i.Category.Name.ToLower().Contains(keyword)
                                               || i.SeoDescription.ToLower().Contains(keyword)
                                               || i.SeoTags.ToLower().Contains(keyword)
                                               || i.SeoAuthor.ToLower().Contains(keyword));
            }

            return predicate;
        }

        #region GetAllByNonDeletedAsync

        public async Task<IResult<IList<PostDto>>> GetAllByNonDeletedAsync()
        {
            var entities = await _unitOfWork.Posts.GetAllAsync(c => !c.IsDeleted, i => i.Category);

            if (entities == null)
                return NotFound<IList<PostDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<PostDto>>(entities);
            return Ok(outputDto);
        }

        #endregion

        public async Task<IResult<IList<PostDto>>> GetAllByDeletedAsync()
        {
            var entities = await _unitOfWork.Posts.GetAllAsync(c => c.IsDeleted,
                i => i.Category);

            if (entities == null)
                return NotFound<IList<PostDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<PostDto>>(entities);
            return Ok(outputDto);
        }

        public async Task<IResult<IList<PostDto>>> GetAllByNonDeletedAndActiveAsync()
        {
            var entities = await _unitOfWork.Posts.GetAllAsync(c => !c.IsDeleted && c.IsActive,
                i => i.Category);

            if (entities == null)
                return NotFound<IList<PostDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<PostDto>>(entities);
            return Ok(outputDto);
        }

        public async Task<IResult<IList<PostDto>>> GetAllByCategoryAsync(int categoryId)
        {
            var entities = await _unitOfWork.Posts.GetAllAsync(c =>
                    !c.IsDeleted && c.IsActive && c.CategoryId == categoryId,
                i => i.Category);

            if (entities == null)
                return NotFound<IList<PostDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<PostDto>>(entities);
            return Ok(outputDto);
        }

        public async Task<IResult<IList<PostDto>>> GetAllByViewCountAsync(bool isAscending, int? take)
        {
            var query = _unitOfWork.Posts.Query(i => !i.IsDeleted && i.IsActive,
                i => isAscending ? i.OrderBy(c => c.ViewsCount) : i.OrderByDescending(c => c.ViewsCount),
                false,
                i => i.Category,
                i => i.User);

            if (take.HasValue)
                query = query.Take(take.Value);

            var entities = await query.ToListAsync();
            if (entities == null)
                return NotFound<IList<PostDto>>(BaseLocalization.NoDataAvailableOnRequest);
            var outputDto = _mapper.Map<IList<PostDto>>(entities);
            return Ok(outputDto);
        }

        #region CountAsync

        public async Task<IResult<int>> CountAsync(bool isDeleted = false)
        {
            var count = await _unitOfWork.Posts.CountAsync(c => c.IsDeleted == isDeleted);
            return count > -1 ? Ok(count) : NotFound<int>(BaseLocalization.NoDataAvailableOnRequest);
        }

        public async Task<IResult<int>> IncreaseViewCountAsync(int id)
        {
            var entity = await _unitOfWork.Posts.GetAsync(i => i.Id == id);
            if (entity is null)
                return NotFound<int>(BaseLocalization.NotFoundCodeGeneralMessage);
            entity.IncreaseViewCount();
            await _unitOfWork.Posts.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Updated(entity.ViewsCount);
        }

        #endregion

        #endregion

        #region CRUD

        #region AddAsync

        public async Task<IResult<PostDto>> AddAsync(PostAddDto dto)
        {
            if (CurrentUser is null) return Unauthorized<PostDto>();

            var entity = _mapper.Map<Post>(dto);

            var uploadedResult =
                await _fileHelper.UploadImageAsync(dto.ThumbnailFile, ImageSubDirectoryEnum.Post, otherName: dto.Title);
            if (!uploadedResult.IsSuccess) return Error<PostDto>(uploadedResult.Errors.ToArray());

            entity.Thumbnail = uploadedResult.Data.FullName;
            entity.UserId = CurrentUser.Id;
            entity.SetCreatedByName(CurrentUser.UserName);

            var createdEntity = await _unitOfWork.Posts.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var outputDto = _mapper.Map<PostDto>(createdEntity);
            return Created(outputDto);
        }

        #endregion

        #region UpdateAsync

        public async Task<IResult<PostDto>> UpdateAsync(PostUpdateDto dto)
        {
            var isNewFileUploaded = false;
            if (CurrentUser is null) return Unauthorized<PostDto>();

            var foundedEntity = await _unitOfWork.Posts.GetAsync(i => i.Id == dto.Id);
            if (foundedEntity is null)
                return NotFound<PostDto>(BaseLocalization.NotFoundCodeGeneralMessage);

            var oldFileName = foundedEntity.Thumbnail;

            if (dto.ThumbnailFile is not null)
            {
                var uploadedResult = await _fileHelper.UploadImageAsync(dto.ThumbnailFile, ImageSubDirectoryEnum.Post,
                    otherName: dto.Title);
                if (!uploadedResult.IsSuccess)
                    return Error<PostDto>(uploadedResult.Errors.ToArray());
                isNewFileUploaded = true;
                dto.Thumbnail = uploadedResult.Data.FullName;
            }

            var entity = _mapper.Map(dto, foundedEntity);
            entity.SetModifiedByName(CurrentUser.UserName);
            var updatedEntity = await _unitOfWork.Posts.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            if (isNewFileUploaded) _fileHelper.DeleteImage(oldFileName);

            var outputDto = _mapper.Map<PostDto>(updatedEntity);
            return Updated(outputDto);
        }

        #endregion

        #region DeleteAsync

        public async Task<IResult<PostDto>> DeleteAsync(int id)
        {
            if (CurrentUser is null) return Unauthorized<PostDto>();

            var entity = await _unitOfWork.Posts.GetAsync(c => c.Id == id);
            if (entity is null)
                return NotFound<PostDto>(BaseLocalization.NoDataAvailableOnRequest);

            entity.SetIsDeleted(true);
            entity.SetModifiedByName(CurrentUser.UserName);

            var deletedEntity = await _unitOfWork.Posts.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            var outputDto = _mapper.Map<PostDto>(deletedEntity);
            return Deleted(outputDto);
        }

        public async Task<IResult<bool>> HardDeleteAsync(int id)
        {
            var entity = await _unitOfWork.Posts.GetAsync(c => c.Id == id);
            if (entity == null)
                return NotFound<bool>(BaseLocalization.NoDataAvailableOnRequest);
            await _unitOfWork.Posts.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Deleted(true);
        }

        public async Task<IResult<PostDto>> UndoDeleteAsync(int id)
        {
            if (CurrentUser is null)
                return Unauthorized<PostDto>();
            var entity = await _unitOfWork.Posts.GetAsync(c => c.Id == id);
            if (entity == null)
                return NotFound<PostDto>(BaseLocalization.NoDataAvailableOnRequest);
            entity.SetIsDeleted(false);
            entity.SetModifiedByName(CurrentUser.UserName);
            var deletedEntity = await _unitOfWork.Posts.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var outputDto = _mapper.Map<PostDto>(deletedEntity);
            return UndoDeleted(outputDto);
        }

        #endregion

        #endregion

        #endregion
    }
}