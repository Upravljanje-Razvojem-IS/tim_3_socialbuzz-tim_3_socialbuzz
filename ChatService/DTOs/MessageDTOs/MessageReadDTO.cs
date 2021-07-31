using System;

namespace ChatService.DTOs.MessageDTOs
{
    public class MessageReadDTO
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public bool IsDeleted { get; set; }
        public Guid OwnerId { get; set; }
        public Guid MessageTypeId { get; set; }
        public Guid ChatId { get; set; }
    }
}
