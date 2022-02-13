using Blog.Entities.Dtos.User;
using Blog.Shared.Utilities.Results.Abstract;

namespace Blog.WebAPP.CORE.MVC.Areas.Admin.Models
{
    public class UserCreateAjaxViewModel
    {
        /// <summary>
        /// Action : true
        /// Create
        /// </summary>
        public bool Action { get; private set; } = true;
        public UserAddDto AddDto { get; set; }
        public string Partial { get; set; }
        public IResult<UserDto> Result { get; set; }
    }


    public class UserUpdateAjaxViewModel
    {
        /// <summary>
        /// Action : false
        /// Update
        /// </summary>
        public bool Action { get; private set; } = false;
        public UserUpdateDto UpdateDto { get; set; }
        public string Partial { get; set; }
        public IResult<UserDto> Result { get; set; }
    }
}