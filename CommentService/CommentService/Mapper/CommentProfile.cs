using AutoMapper;
using CommentService.DTOs.CommentDTOs;
using CommentService.Entities;

namespace CommentService.Mapper
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentReadDto>();
            CreateMap<Comment, CommentConfirmationDto>();
        }
    }
}
