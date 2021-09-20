using AutoMapper;
using CommentService.DTOs.OwnerDTOs;
using CommentService.Entities;

namespace CommentService.Mapper
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerReadDto>();
            CreateMap<Owner, OwnerConfirmationDto>();
        }
    }
}
