namespace Blog.Entities.Dtos.Post
{
    public class PostFilterDto : BaseFilterDto
    {
        public int? CategoryId { get; set; }

        public PostFilterDto()
        {
            this.CurrentPage = 1;
            this.PageSize = 6;
        }
    }
}
