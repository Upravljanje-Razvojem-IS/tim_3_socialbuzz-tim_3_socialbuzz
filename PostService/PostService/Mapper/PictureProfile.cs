using AutoMapper;
using PostService.DTOs.PictureDTO;
using PostService.Entities;

namespace PostService.Mapper
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap<PostPicture, PictureReadDTO>();
            CreateMap<PostPicture, PictureConfirmationDTO>();
        }
    }
}
