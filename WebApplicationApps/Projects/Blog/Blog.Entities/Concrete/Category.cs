using System.Collections.Generic;
using Blog.Shared.Entities.Abstract;

namespace Blog.Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // relations
        public ICollection<Post> Posts { get; set; }
    }
}