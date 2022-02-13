using System.Collections.Generic;
using Blog.Shared.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Blog.Entities.Concrete
{
    public class Role : IdentityRole<int>, IEntity
    {
    }
}