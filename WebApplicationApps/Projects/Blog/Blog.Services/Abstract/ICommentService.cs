using Blog.Entities.Dtos.Comment;
using Blog.Shared.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Abstract
{
    public interface ICommentService
    {
        Task<IResult<CommentDto>> GetAsync(int id);
        Task<IResult<CommentUpdateDto>> GetUpdateDtoAsync(int id);
        Task<IResult<IList<CommentDto>>> GetAllAsync();
        Task<IResult<IList<CommentDto>>> GetAllByNonDeletedAsync();
        Task<IResult<IList<CommentDto>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult<IList<CommentDto>>> GetAllByPostAsync(int postId);
        Task<IResult<CommentDto>> AddAsync(CommentAddDto dto);
        Task<IResult<CommentDto>> UpdateAsync(CommentUpdateDto dto);
        Task<IResult<CommentDto>> DeleteAsync(int id);
        Task<IResult<int>> CountAsync(bool isDeleted = false);
    }
}
