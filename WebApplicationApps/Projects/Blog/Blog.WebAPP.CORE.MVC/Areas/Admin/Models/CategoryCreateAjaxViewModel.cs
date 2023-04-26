using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Models
{
    public class CategoryCreateAjaxViewModel
    {
        /// <summary>
        ///     Action : true
        ///     Create
        /// </summary>
        public bool Action { get; } = true;

        public CategoryAddDto AddDto { get; set; }
        public string Partial { get; set; }
        public IResult<CategoryDto> Result { get; set; }
    }

    public class CategoryUpdateAjaxViewModel
    {
        /// <summary>
        ///     Action : false
        ///     Update
        /// </summary>
        public bool Action { get; } = false;

        public CategoryUpdateDto UpdateDto { get; set; }
        public string Partial { get; set; }
        public IResult<CategoryDto> Result { get; set; }
    }
}