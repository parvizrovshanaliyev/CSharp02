using Blog.Entities.Dtos;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Models
{
    public class CategoryCreateAjaxViewModel
    {
        public CategoryAddDto AddDto { get; set; }
        public string Partial { get; set; }
        public CategoryDto Dto { get; set; }
    }

    public class CategoryUpdateAjaxViewModel
    {
        public CategoryUpdateDto UpdateDto { get; set; }
        public string Partial { get; set; }
        public CategoryDto Dto { get; set; }
    }
}
