using AutoMapper;
using ChatService.DTOs.MessageDTOs;
using ChatService.Entities;

namespace ChatService.MapperProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageReadDto>();
            CreateMap<Message, MessageConfirmationDto>();
        }
    }
}
