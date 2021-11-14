using System.Collections;
using System.Collections.Generic;
using Blog.Shared.Entities.Abstract;
using Blog.Shared.Extensions;

namespace Blog.Entities.Concrete
{
    public class User:EntityBase,IEntity
    {
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{this.FirstName} {this.LastName}";
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }


        // relations 
        public Role Role { get; set; }
        public ICollection<Post> Posts { get; set; }

        // methods
        public void SetEmailConfirmed(bool control)
        {
            this.IsEmailConfirmed = control;
        }

        public void SetPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                this.PasswordHash = password.HashPassword();
            }
        }
    }
}
