using AutoMapper;
using LoggerService.Dtos;
using LoggerService.Model;

namespace LoggerService.Profiles
{
    public class LogProfiles : Profile
    {
        public LogProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<SaveUserDto, User>();
            CreateMap<HttpRequest, HttpRequestDto>();
            CreateMap<HttpRequestDto, HttpRequest>();
            CreateMap<HttpResponse, HttpResponseDto>();
            CreateMap<HttpResponseDto, HttpResponse>();
            CreateMap<RequestError, RequestErrorDto>();
            CreateMap<RequestErrorDto, RequestError>();
            CreateMap<Log, LogDto>();
            CreateMap<SaveLogDto, Log>();
        }
    }
}
