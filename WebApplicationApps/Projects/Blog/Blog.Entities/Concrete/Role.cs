using System.Collections.Generic;
using Blog.Shared.Entities.Abstract;

namespace Blog.Entities.Concrete
{
    public class Role : EntityBase, IEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }

        // relations
        public ICollection<User> Users { get; set; }
    }
}