using AutoMapper;
using DeliveryService.API.Models.WeightRangeModels;
using DeliveryService.API.Entities;


namespace DeliveryService.API.MapperProfiles
{
    public class WeightRangeProfile : Profile
    {
        public WeightRangeProfile()
        {
            CreateMap<WeightRange, WeightRangeOverview>();
            CreateMap<WeightRange, WeightRangeDetails>();
            CreateMap<WeightRange, WeightRangeConfirmation>();
        }
    }
}
