using Blog.Entities.Dtos;
using Blog.Entities.Dtos.Post;
using System.Collections.Generic;

namespace Blog.WebAPP.CORE.MVC.Models
{
    public class RightSideBarViewModel
    {
        public IList<CategoryDto> Categories { get; set; }
        public IList<PostDto> Posts { get; set; }
    }
}
