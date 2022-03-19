﻿using System;

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
        public int CommentCount { get; set; }
        public string SeoAuthor { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
    }
}