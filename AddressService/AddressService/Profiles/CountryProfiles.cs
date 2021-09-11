using AddressService.Dtos.Country;
using AddressService.Models;
using AutoMapper;

namespace AddressService.Profiles
{
    public class CountryProfiles: Profile
    {
        public CountryProfiles()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
