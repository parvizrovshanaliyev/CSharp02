using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Models
{
    public class CategoryCreateAjaxViewModel
    {
        public CategoryAddDto AddDto { get; set; }
        public string Partial { get; set; }
        public IResult<CategoryDto> Result { get; set; }
    }

    public class CategoryUpdateAjaxViewModel
    {
        public CategoryUpdateDto UpdateDto { get; set; }
        public string Partial { get; set; }
        public IResult<CategoryDto> Result { get; set; }
    }
}
