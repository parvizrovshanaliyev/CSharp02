using Blog.Entities.Dtos.Post;
using System.Collections.Generic;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; } = 0;
        public int PostsCount { get; set; } = 0;
        public int CommentsCount { get; set; } = 0;
        public int UsersCount { get; set; } = 0;
        public IList<PostDto> LastPublishedPosts { get; set; } = new List<PostDto>();

    }
}
