using Blog.Shared.Localizations;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities.Dtos.Comment
{
    public class CommentAddDto
    {
        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Comment))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(2, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string Content { get; set; }

        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        public int PostId { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.IsActive))]
        public bool IsActive { get; set; } = true;
    }
}


