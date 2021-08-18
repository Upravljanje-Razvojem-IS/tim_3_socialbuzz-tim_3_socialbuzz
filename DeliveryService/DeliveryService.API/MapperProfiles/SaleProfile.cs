using AutoMapper;
using DeliveryService.API.Models.SaleModels;
using DeliveryService.API.Entities;

namespace DeliveryService.API.MapperProfiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, SaleOverview>();
            CreateMap<Sale, SaleDetails>();
            CreateMap<Sale, SaleConfirmation>();
        }
    }
}
