using Blog.Entities.Concrete;
using Blog.Entities.Dtos.Post;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Services.Abstract
{
    public interface IPostService
    {
        Task<IResult<PostDto>> GetAsync(int id);
        Task<IResult<PostDto>> GetAsync(Expression<Func<Post, bool>> predicate, params Expression<Func<Post, object>>[] includeProperties);

        Task<IResult<PostUpdateDto>> GetUpdateDtoAsync(int id);
        Task<IResult<IList<PostDto>>> GetAllAsync();
        Task<IResult<PagedResult<PostDto>>> GetAllByPagingAsync(int? categoryId, int? currentPage, int? pageSize, bool isAscending = false);
        Task<IResult<IList<PostDto>>> GetAllByNonDeletedAsync();
        Task<IResult<IList<PostDto>>> GetAllByDeletedAsync();
        Task<IResult<IList<PostDto>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult<IList<PostDto>>> GetAllByCategoryAsync(int categoryId);
        Task<IResult<IList<PostDto>>> GetAllByViewCountAsync(bool isAscending, int? take);
        Task<IResult<PostDto>> AddAsync(PostAddDto dto);
        Task<IResult<PostDto>> UpdateAsync(PostUpdateDto dto);
        Task<IResult<PostDto>> DeleteAsync(int id);
        Task<IResult<PostDto>> UndoDeleteAsync(int id);
        Task<IResult<bool>> HardDeleteAsync(int id);
        Task<IResult<int>> CountAsync(bool isDeleted = false);
    }
}