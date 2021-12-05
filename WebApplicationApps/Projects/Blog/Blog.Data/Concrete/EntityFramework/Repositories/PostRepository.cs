using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Concrete.EntityFramework.Repositories
{
    public class PostRepository : EfRepositoryBase<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {
        }
    }
}