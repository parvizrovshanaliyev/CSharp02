using Blog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Blog.Entities.Concrete
{
    public class Post : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; }
        public int ViewsCount { get; set; }
        public int CommentCount { get; set; }
        public string SeoAuthor { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }

        // relations
        public Category Category { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }

        // methods
        public void IncreaseViewCount()
        {
            this.ViewsCount += 1;
        }

        public void DecreaseViewCount()
        {
            this.ViewsCount -= 1;
        }

        public void IncreaseCommentCount()
        {
            this.CommentCount += 1;
        }

        public void DecreaseCommentCount()
        {
            this.CommentCount -= 1;
        }
    }
}