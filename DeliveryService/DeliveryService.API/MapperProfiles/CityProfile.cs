using AutoMapper;
using DeliveryService.API.Models.CityModels;
using DeliveryService.API.Entities;

namespace DeliveryService.API.MapperProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityOverview>();
            CreateMap<City, CityDetails>();
            CreateMap<City, CityConfirmation>();
        }
    }
}
