using Blog.Entities.Dtos;
using Blog.Entities.Dtos.Post;
using Blog.Entities.Dtos.User;
using System.Collections.Generic;

namespace Blog.WebAPP.CORE.MVC.Models
{
    public class RightSideBarViewModel
    {
        public IList<CategoryDto> Categories { get; set; }
        public IList<PostDto> Posts { get; set; }
    }


    public class PostDetailRightSideBarViewModel
    {
        public string Header { get; set; }
        public UserDto Author { get; set; }
        public IList<CategoryDto> Categories { get; set; }
        public IList<PostDto> RelatedPosts { get; set; }
    }
}
