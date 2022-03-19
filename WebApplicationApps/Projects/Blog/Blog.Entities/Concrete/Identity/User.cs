using Blog.Shared.Entities.Abstract;
using Blog.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Blog.Entities.Concrete
{
    public class User : IdentityUser<int>, IEntity
    {
        public string Avatar { get; set; }

        // relations 
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }

        // methods
        public void SetPassword(string password)
        {
            if (!string.IsNullOrEmpty(password)) PasswordHash = password.HashPassword();
        }
    }
}