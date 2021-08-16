using AutoMapper;
using DeliveryService.API.Models.AddressModels;
using DeliveryService.API.Entities;

namespace DeliveryService.API.MapperProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressOverview>();
            CreateMap<Address, AddressDetails>();
            CreateMap<Address, AddressConfirmation>();
        }
    }
}
