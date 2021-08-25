using ChatService.DTOs.MessageTypeDTOs;
using System;
using System.Collections.Generic;

namespace ChatService.Interfaces
{
    public interface IMessageTypeService
    {
        List<MessageTypeReadDto> Get();
        MessageTypeReadDto Get(Guid id);
        MessageTypeConfirmationDto Create(MessageTypeCreateDto dto);
        MessageTypeConfirmationDto Update(Guid id, MessageTypeCreateDto dto);
        void Delete(Guid id);
    }
}
