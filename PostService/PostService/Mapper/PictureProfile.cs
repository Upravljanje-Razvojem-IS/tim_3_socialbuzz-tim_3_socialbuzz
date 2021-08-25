using AutoMapper;
using PostService.DTOs.PictureDTO;
using PostService.Entities;

namespace PostService.Mapper
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap<PostPicture, PictureReadDto>();
            CreateMap<PostPicture, PictureConfirmationDto>();
        }
    }
}
