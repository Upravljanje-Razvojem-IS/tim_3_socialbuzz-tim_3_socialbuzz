using ChatService.DTOs.ChatUser;
using System;
using System.Collections.Generic;

namespace ChatService.Interfaces
{
    public interface IChatUserService
    {
        List<ChatUserReadDto> Get();
        ChatUserReadDto Get(Guid id);
        ChatUserConfirmationDto Create(ChatUserCreateDto dto);
        ChatUserConfirmationDto Update(Guid id, ChatUserCreateDto dto);
        void Delete(Guid id);
    }
}
