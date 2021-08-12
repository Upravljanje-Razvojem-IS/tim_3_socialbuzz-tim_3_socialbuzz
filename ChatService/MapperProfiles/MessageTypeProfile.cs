using AutoMapper;
using ChatService.DTOs.MessageTypeDTOs;
using ChatService.Entities;

namespace ChatService.MapperProfiles
{
    public class MessageTypeProfile : Profile
    {
        public MessageTypeProfile()
        {
            CreateMap<MessageType, MessageTypeReadDto>();
            CreateMap<MessageType, MessageTypeConfirmationDto>();
        }
    }
}
