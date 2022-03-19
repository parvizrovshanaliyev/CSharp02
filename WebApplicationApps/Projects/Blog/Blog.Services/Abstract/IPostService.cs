using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Entities.Dtos.Post;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.Services.Abstract
{
    public interface IPostService
    {
        Task<IResult<PostDto>> GetAsync(int id);
        Task<IResult<PostUpdateDto>> GetUpdateDtoAsync(int id);
        Task<IResult<IList<PostDto>>> GetAllAsync();
        Task<IResult<IList<PostDto>>> GetAllByNonDeletedAsync();
        Task<IResult<IList<PostDto>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult<IList<PostDto>>> GetAllByCategoryAsync(int categoryId);
        Task<IResult<PostDto>> AddAsync(PostAddDto dto);
        Task<IResult<PostDto>> UpdateAsync(PostUpdateDto dto);
        Task<IResult<PostDto>> DeleteAsync(int id);
        Task<IResult<bool>> HardDeleteAsync(int id);
        Task<IResult<int>> CountAsync(bool isDeleted = false);
    }
}