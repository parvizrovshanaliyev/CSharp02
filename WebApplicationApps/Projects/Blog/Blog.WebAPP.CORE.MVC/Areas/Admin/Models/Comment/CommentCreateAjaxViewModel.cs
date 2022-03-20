using Blog.Entities.Dtos.Comment;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Models
{
    public class CommentCreateAjaxViewModel
    {
        /// <summary>
        /// Create Action : true
        /// Update Action : false
        /// </summary>
        public bool Action { get; private set; } = true;
        public CommentAddDto AddDto { get; set; }
        public string Partial { get; set; }
        public IResult<CommentDto> Result { get; set; }
    }
}
