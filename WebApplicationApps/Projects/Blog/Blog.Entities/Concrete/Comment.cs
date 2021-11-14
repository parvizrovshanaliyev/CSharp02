using Blog.Shared.Entities.Abstract;

namespace Blog.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public int PostId { get; set; }
        public string Text { get; set; }

        // relations
        public Post Post { get; set; }
    }
}