using AutoMapper;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.Comment;

namespace Blog.Services.AutoMapper.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentAddDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentUpdateDto>();
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.PostTitle,
                    opt => opt.MapFrom(src => src.Post.Title));
        }
    }
}
