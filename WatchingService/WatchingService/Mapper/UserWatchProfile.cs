using AutoMapper;
using WatchingService.DTOs;
using WatchingService.Entities;

namespace WatchingService.Mapper
{
    public class UserWatchProfile : Profile
    {
        public UserWatchProfile()
        {
            CreateMap<UserWatch, UserWatchReadDto>();
            CreateMap<UserWatch, UserWatchConfirmationDto>();
        }
    }
}
