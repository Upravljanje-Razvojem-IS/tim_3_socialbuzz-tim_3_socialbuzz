using AutoMapper;
using ChatService.DTOs.ChatUser;
using ChatService.Entities;

namespace ChatService.MapperProfiles
{
    public class ChatUserProfile : Profile
    {
        public ChatUserProfile()
        {
            CreateMap<ChatUser, ChatUserReadDto>();
            CreateMap<ChatUser, ChatUserConfirmationDto>();
        }
    }
}
