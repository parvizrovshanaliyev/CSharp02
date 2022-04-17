using Blog.Shared.Entities.Abstract;

namespace Blog.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public int PostId { get; set; }
        public int? UserId { get; set; }

        public string Content { get; set; }

        // relations
        public Post Post { get; set; }
        public User User { get; set; }
    }
}