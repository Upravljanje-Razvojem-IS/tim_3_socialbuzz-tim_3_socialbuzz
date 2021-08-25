using AutoMapper;
using DeliveryService.API.Models.PriceDistanceModels;
using DeliveryService.API.Entities;

namespace DeliveryService.API.MapperProfiles
{
    public class PriceDistanceProfile : Profile
    {
        public PriceDistanceProfile()
        {
            CreateMap<PriceDistance, PriceDistanceOverview>();
            CreateMap<PriceDistance, PriceDistanceDetails>();
            CreateMap<PriceDistance, PriceDistanceConfirmation>();
        }
    }
}
