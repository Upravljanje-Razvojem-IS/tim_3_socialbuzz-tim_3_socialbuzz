using ChatService.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;

namespace ChatService.Interfaces
{
    public interface IMessageService
    {
        List<MessageReadDto> Get();
        MessageReadDto Get(Guid id);
        MessageConfirmationDto Create(MessageCreateDto dto);
        MessageConfirmationDto Update(Guid id, MessageCreateDto dto);
        void Delete(Guid id);
    }
}
