using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatService.Entities
{
    public class ChatUser
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Mocked user id
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Chat id
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
