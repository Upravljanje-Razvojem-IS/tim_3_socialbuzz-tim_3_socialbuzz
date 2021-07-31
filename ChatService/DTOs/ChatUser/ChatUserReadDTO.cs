using System;

namespace ChatService.DTOs.ChatUser
{
    public class ChatUserReadDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
