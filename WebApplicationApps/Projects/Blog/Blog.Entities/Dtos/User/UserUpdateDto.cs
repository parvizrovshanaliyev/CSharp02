using Blog.Shared.Localizations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities.Dtos.User
{
    public class UserUpdateDto
    {
        [Required] public int Id { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.UserName))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(50, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(3, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Email))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(100, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(10, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        /// <summary>
        ///     +99455 666 66 66
        /// </summary>
        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.PhoneNumber))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(13, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(13, ErrorMessageResourceType = typeof(BaseLocalization),
            ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Upload)] public IFormFile File { get; set; }

        public string Avatar { get; set; }

        // new props 
        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.FirstName))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(2, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.LastName))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(30, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(2, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.AboutMe))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(5, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string AboutMe { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.TwitterLink))]
        [MaxLength(250, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(20, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string TwitterLink { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.FacebookLink))]
        [MaxLength(250, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(20, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string FacebookLink { get; set; }


        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.InstagramLink))]
        [MaxLength(250, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(20, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string InstagramLink { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.LinkedinLink))]
        [MaxLength(250, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(20, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string LinkedInLink { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.YoutubeLink))]
        [MaxLength(250, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(20, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string YoutubeLink { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.GithubLink))]
        [MaxLength(250, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(20, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string GitHubLink { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.WebsiteLink))]
        [MaxLength(250, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(20, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string WebsiteLink { get; set; }
    }
}