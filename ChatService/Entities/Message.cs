using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatService.Entities
{
    public class Message
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Message body
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// Flag is message deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Mocked user id
        /// </summary>
        [Required]
        public Guid OwnerId { get; set; }


        /// <summary>
        /// Type Id
        /// </summary>
        [Required]
        [ForeignKey("MessageType")]
        public Guid MessageTypeId { get; set; }

        /// <summary>
        /// Type obj
        /// </summary>
        public MessageType MessageType { get; set; }


        /// <summary>
        /// Chat Id
        /// </summary>
        [Required]
        [ForeignKey("Chat")]
        public Guid ChatId { get; set; }
        /// <summary>
        /// Chat obj
        /// </summary>
        public Chat Chat { get; set; }
    }
}
