using System.Collections.Generic;
using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;

namespace Blog.Entities.Dtos
{
    public class CategoryDto:GetBaseDto
    {
        public Category Entity { get; set; } 
    }
    
    public class CategoryListDto:GetBaseDto
    {
        public IList<Category> Entities { get; set; }
    }
}