using Blog.Shared.Entities.Abstract;
using Blog.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities.Concrete
{
    public class User : IdentityUser<int>, IEntity
    {
        public string Avatar { get; set; }
        public string AboutMe { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public string YoutubeLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
        public string GitHubLink { get; set; }
        public string WebsiteLink { get; set; }

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