using System;

namespace ChatService.DTOs.ChatUser
{
    public class ChatUserCreateDto
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
