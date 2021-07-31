using System;

namespace ChatService.DTOs.ChatDTOs
{
    public class ChatReadDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
