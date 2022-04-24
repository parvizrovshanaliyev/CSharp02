using Blog.Entities.ComplexTypes;
using System;

namespace Blog.Entities.Dtos.Post
{
    public class PostFilterDto : BaseFilterDto
    {
        public PostFilterDto()
        {
            this.CurrentPage = 1;
            this.PageSize = 6;
        }

        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? MaxViewCount { get; set; }
        public int? MinViewCount { get; set; }
        public int? MaxCommentCount { get; set; }
        public int? MinCommentCount { get; set; }
        public OrderBy? OrderBy { get; set; }
    }
}
