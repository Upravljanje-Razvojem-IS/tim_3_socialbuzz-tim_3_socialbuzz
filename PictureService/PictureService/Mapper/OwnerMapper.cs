using PictureService.DTOs.OwnerDTOs;
using PictureService.Entities;
using AutoMapper;


namespace PictureService.Mapper
{
    public class OwnerMapper : Profile
    {
        public OwnerMapper()
        {
            CreateMap<Owner, OwnerReadDto>();
            CreateMap<Owner, OwnerConfirmationDto>();
        }
    }
}
