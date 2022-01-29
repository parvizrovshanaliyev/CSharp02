using AutoMapper;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;

namespace Blog.Services.AutoMapper.Profiles
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
            //.ReverseMap();
            CreateMap<Category, CategoryAddDto>();
            //.ForMember(dest=>dest.Description,opt=>opt.MapFrom(src=>src.Description2));
        }
    }
}
