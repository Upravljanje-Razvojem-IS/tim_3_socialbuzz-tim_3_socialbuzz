using AutoMapper;
using CommentService.DTOs.PostDTOs;
using CommentService.Entities;

namespace CommentService.Mapper
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<Post, PostReadDto>();
            CreateMap<Post, PostConfirmationDto>();
        }
    }
}
