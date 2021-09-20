using AutoMapper;
using WatchingService.DTOs;
using WatchingService.Entities;

namespace WatchingService.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<User, UserConfirmationDto>();
        }
    }
}
