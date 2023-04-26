using System.ComponentModel.DataAnnotations;
using Blog.Shared.Localizations;

namespace Blog.Entities.Dtos.Auth
{
    public class LoginDto
    {
        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Email))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(100, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(10, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Password))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(6, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.RememberMe))]
        public bool RememberMe { get; set; }
    }
}