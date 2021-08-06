using ChatService.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;

namespace ChatService.Interfaces
{
    public interface IMessageService
    {
        List<MessageReadDTO> Get();
        MessageReadDTO Get(Guid id);
        MessageConfirmationDTO Create(MessageCreateDTO dto);
        MessageConfirmationDTO Update(Guid id, MessageCreateDTO dto);
        void Delete(Guid id);
    }
}
