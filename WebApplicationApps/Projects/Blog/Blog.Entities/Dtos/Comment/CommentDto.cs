namespace Blog.Entities.Dtos.Comment

{
    public class CommentDto : BaseDto
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string Content { get; set; }
    }
}