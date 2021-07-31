using ChatService.DTOs.MessageTypeDTOs;
using System;
using System.Collections.Generic;

namespace ChatService.Interfaces
{
    public interface IMessageTypeService
    {
        List<MessageTypeReadDTO> Get();
        MessageTypeReadDTO Get(Guid id);
        MessageTypeConfirmationDTO Create(MessageTypeCreateDTO dto);
        MessageTypeConfirmationDTO Update(Guid id, MessageTypeCreateDTO dto);
        void Delete(Guid id);
    }
}
