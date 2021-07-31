using System;

namespace ChatService.DTOs.ChatUser
{
    public class ChatUserCreateDTO
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
