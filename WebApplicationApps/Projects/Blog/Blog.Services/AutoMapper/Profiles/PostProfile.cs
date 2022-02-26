using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.Post;

namespace Blog.Services.AutoMapper.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dest=>dest.Category,
                    opt=>opt.MapFrom(src=>src.Category.Name));
        }
    }
}
