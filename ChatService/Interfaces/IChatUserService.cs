using ChatService.DTOs.ChatUser;
using System;
using System.Collections.Generic;

namespace ChatService.Interfaces
{
    public interface IChatUserService
    {
        List<ChatUserReadDTO> Get();
        ChatUserReadDTO Get(Guid id);
        ChatUserConfirmationDTO Create(ChatUserCreateDTO dto);
        ChatUserConfirmationDTO Update(Guid id, ChatUserCreateDTO dto);
        void Delete(Guid id);
    }
}
