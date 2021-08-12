using AutoMapper;
using PostService.DTOs.ServiceDTOs;
using PostService.Entities;

namespace PostService.Mapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceReadDTO>();
            CreateMap<Service, ServiceConfirmationDTO>();
        }
    }
}
