using AutoMapper;
using ChatService.DTOs.ChatDTOs;
using ChatService.Entities;

namespace ChatService.MapperProfiles
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<Chat, ChatReadDto>();
            CreateMap<Chat, ChatConfirmationDto>();
        }
    }
}
