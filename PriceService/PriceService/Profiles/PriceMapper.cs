using AutoMapper;
using PriceService.DTOs;
using PriceService.Entities;

namespace PriceService.Profiles
{
    public class PriceMapper : Profile
    {
        public PriceMapper()
        {
            CreateMap<Price, PriceReadDto>();
            CreateMap<Price, PriceConfirmationDto>();

        }
    }
}
