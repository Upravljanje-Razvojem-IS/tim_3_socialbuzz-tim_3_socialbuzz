using AddressService.Dtos.City;
using AddressService.Models;
using AutoMapper;

namespace AddressService.Profiles
{
    public class CityProfiles: Profile
    {
        public CityProfiles()
        {
            CreateMap<City, CityDto>();
            CreateMap<SaveCityDto, City>();
            CreateMap<UpdateCityDto, City>();
        }
    }
}
