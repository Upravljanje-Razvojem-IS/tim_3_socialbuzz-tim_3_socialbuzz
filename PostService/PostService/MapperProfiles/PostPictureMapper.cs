using AutoMapper;
using PostService.DTOs.PictureDTO;
using PostService.Entities;

namespace PostService.MapperProfiles
{
    public class PostPictureMapper : Profile
    {
        public PostPictureMapper()
        {
            CreateMap<PostPicture, PictureReadDTO>();
            CreateMap<PostPicture, PictureConfirmationDTO>();
        }
    }
}
