using Blog.Shared.Localizations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities.Dtos.Post
{

    public class PostAddViewModel
    {

        public PostAddViewModel()
        {
            Categories = new List<CategoryDto>();
        }
        public PostAddDto AddDto { get; set; }

        public IList<CategoryDto> Categories { get; set; }
    }
    public class PostAddDto
    {
        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Category))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        public int CategoryId { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Title))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(100, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(5, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string Title { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Content))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MinLength(20, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string Content { get; set; }

        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Thumbnail))]
        public IFormFile ThumbnailFile { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.Date))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.SeoAuthor))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(50, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(0, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string SeoAuthor { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.SeoDescription))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(150, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(0, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string SeoDescription { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.SeoTags))]
        [Required(ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.RequiredErrorMessage))]
        [MaxLength(70, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MaxLengthErrorMessage))]
        [MinLength(0, ErrorMessageResourceType = typeof(BaseLocalization), ErrorMessageResourceName = nameof(BaseLocalization.MinLengthErrorMessage))]
        public string SeoTags { get; set; }

        [Display(ResourceType = typeof(BaseLocalization), Name = nameof(BaseLocalization.IsActive))]
        public bool IsActive { get; set; } = true;
    }
}