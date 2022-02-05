using System.Collections;
using System.Collections.Generic;
using Blog.Shared.Entities.Abstract;
using Blog.Shared.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Blog.Entities.Concrete
{
    public class User:IdentityUser<int>,IEntity
    {
        public string Avatar { get; set; }
        
        // relations 
        public ICollection<Post> Posts { get; set; }

        // methods
        public void SetPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                this.PasswordHash = password.HashPassword();
            }
        }
    }


    public class UserClaim : IdentityUserClaim<int>
    {

    }

    public class UserLogin : IdentityUserLogin<int>
    {

    }

    public class UserRole : IdentityUserRole<int>
    {

    }

    public class UserToken : IdentityUserToken<int>
    {

    }
}
