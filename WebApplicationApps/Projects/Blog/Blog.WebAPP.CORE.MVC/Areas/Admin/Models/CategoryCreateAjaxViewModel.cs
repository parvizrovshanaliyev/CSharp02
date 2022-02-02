using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Models
{
    public class CategoryCreateAjaxViewModel
    {
        /// <summary>
        /// Create Action : true
        /// Update Action : false
        /// </summary>
        public bool Action { get; private set; } = true;
        public CategoryAddDto AddDto { get; set; }
        public string Partial { get; set; }
        public IResult<CategoryDto> Result { get; set; }
    }

    public class CategoryUpdateAjaxViewModel
    {
        /// <summary>
        /// Create Action : true
        /// Update Action : false
        /// </summary>
        public bool Action { get; private set; } = false;
        public CategoryUpdateDto UpdateDto { get; set; }
        public string Partial { get; set; }
        public IResult<CategoryDto> Result { get; set; }
    }
}
