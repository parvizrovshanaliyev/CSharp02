﻿using AutoMapper;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;

namespace Blog.Services.AutoMapper.Profiles
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            //.ReverseMap();
            CreateMap<Category, CategoryAddDto>();
            //.ForMember(dest=>dest.Description,opt=>opt.MapFrom(src=>src.Description2));
        }
    }
}