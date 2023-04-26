using System.Collections.Generic;
using Blog.Shared.Entities.Abstract;

namespace Blog.Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public Category()
        {
        }

        public Category(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        public Category(string name, string description, string note) : base(note)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        // relations
        public ICollection<Post> Posts { get; set; }
    }
}