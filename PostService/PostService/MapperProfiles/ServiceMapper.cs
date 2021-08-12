using AutoMapper;
using PostService.DTOs.ServiceDTOs;
using PostService.Entities;

namespace PostService.MapperProfiles
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<Service, ServiceReadDTO>();
            CreateMap<Service, ServiceConfirmationDTO>();
        }
    }
}
