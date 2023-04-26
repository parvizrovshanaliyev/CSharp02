using AutoMapper;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.User;

namespace Blog.Services.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserAddDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}