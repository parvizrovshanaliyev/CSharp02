using System.ComponentModel.DataAnnotations;
using Blog.Shared.Localizations;

namespace Blog.Entities.Dtos.User
{
    public class UserChangePasswordDto
    {
        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.CurrentPassword))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(6, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.NewPassword))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(6, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.ConfirmPassword))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(6, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.ConfirmPasswordValidation))]
        public string ConfirmPassword { get; set; }
    }
}