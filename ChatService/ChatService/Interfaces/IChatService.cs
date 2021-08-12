using ChatService.DTOs.ChatDTOs;
using System;
using System.Collections.Generic;

namespace ChatService.Interfaces
{
    public interface IChatService
    {
        List<ChatReadDto> Get();
        ChatReadDto Get(Guid id);
        ChatConfirmationDto Create(ChatCreateDto dto);
        ChatConfirmationDto Update(Guid id, ChatCreateDto dto);
        void Delete(Guid id);
    }
}
