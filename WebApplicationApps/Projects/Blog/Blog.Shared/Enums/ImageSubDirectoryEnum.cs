using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.Enums
{
    public enum ImageSubDirectoryEnum
    {
        [Display(Name = "Users")]
        User = 1,
        [Display(Name = "Posts")]
        Post = 2,
    }
}
