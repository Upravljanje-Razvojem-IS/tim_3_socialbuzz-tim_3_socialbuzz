using AutoMapper;
using PriceService.DTOs;
using PriceService.Entities;

namespace PriceService.Profiles
{
    public class PriceHistoryMapper : Profile
    {
        public PriceHistoryMapper()
        {
            CreateMap<PriceHistory, PriceHistoryReadDTO>();
            CreateMap<PriceHistory, PriceHistoryConfirmationDTO>();
        }
    }
}
