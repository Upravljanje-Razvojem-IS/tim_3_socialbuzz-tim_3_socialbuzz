using AutoMapper;
using ChatService.DTOs.ChatUser;
using ChatService.Entities;

namespace ChatService.MapperProfiles
{
    public class ChatUserProfile : Profile
    {
        public ChatUserProfile()
        {
            CreateMap<ChatUser, ChatUserReadDTO>();
            CreateMap<ChatUser, ChatUserConfirmationDTO>();
        }
    }
}
