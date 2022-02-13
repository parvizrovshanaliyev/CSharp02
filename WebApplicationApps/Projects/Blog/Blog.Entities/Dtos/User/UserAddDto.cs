using System.ComponentModel.DataAnnotations;
using Blog.Shared.Localizations;
using Microsoft.AspNetCore.Http;

namespace Blog.Entities.Dtos.User
{
    public class UserAddDto
    {
        [Display(ResourceType = typeof(BaseLocalization),Name = nameof(BaseLocalization.UserName))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(50, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(3, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Email))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(100, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(10, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Password))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(6, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// +99455 666 66 66
        /// </summary>
        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.PhoneNumber))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(13, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(13, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
