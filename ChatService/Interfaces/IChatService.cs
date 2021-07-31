using ChatService.DTOs.ChatDTOs;
using System;
using System.Collections.Generic;

namespace ChatService.Interfaces
{
    public interface IChatService
    {
        List<ChatReadDTO> Get();
        ChatReadDTO Get(Guid id);
        ChatConfirmationDTO Create(ChatCreateDTO dto);
        ChatConfirmationDTO Update(Guid id, ChatCreateDTO dto);
        void Delete(Guid id);
    }
}
