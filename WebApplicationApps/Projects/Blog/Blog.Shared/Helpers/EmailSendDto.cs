using Blog.Shared.Localizations;
using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.Helpers
{
    public class EmailSendDto
    {
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(2, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string FullName { get; set; }


        [Required(ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(10, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(2, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string Subject { get; set; }

        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(250, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(2, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string Message { get; set; }
    }
}
