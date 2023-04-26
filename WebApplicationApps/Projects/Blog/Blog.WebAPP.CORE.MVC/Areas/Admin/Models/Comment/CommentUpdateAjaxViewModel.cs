using Blog.Entities.Dtos.Comment;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Models
{


    public class CommentUpdateAjaxViewModel
    {
        /// <summary>
        /// Create Action : true
        /// Update Action : false
        /// </summary>
        public bool Action { get; private set; } = false;
        public CommentUpdateDto UpdateDto { get; set; }
        public string Partial { get; set; }
        public IResult<CommentDto> Result { get; set; }
    }
}
