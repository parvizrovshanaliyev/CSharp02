using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Entities.Dtos.Post;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.Services.Abstract
{
    public interface IPostService
    {
        Task<IResult<IList<PostDto>>> GetAllByNonDeletedAsync();
    }
}
