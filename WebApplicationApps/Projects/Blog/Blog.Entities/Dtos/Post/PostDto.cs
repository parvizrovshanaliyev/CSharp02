using Blog.Entities.Dtos.Comment;
using Blog.Entities.Dtos.User;
using System;
using System.Collections.Generic;

namespace Blog.Entities.Dtos.Post
{
    public class PostDto : BaseDto
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; }
        public int ViewsCount { get; set; }
        public int CommentsCount { get; set; }
        public string SeoAuthor { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
        public IList<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public UserDto User { get; set; }
    }
}