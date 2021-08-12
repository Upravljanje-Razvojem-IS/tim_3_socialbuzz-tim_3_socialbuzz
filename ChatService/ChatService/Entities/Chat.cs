using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatService.Entities
{
    public class Chat
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Chats name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Chats desctiption
        /// </summary>
        [Required]
        public string  Description { get; set; }

        /// <summary>
        /// Users in chat
        /// </summary>
        public List<ChatUser> ChatUsers { get; set; }

        /// <summary>
        /// Messages in chat
        /// </summary>
        public List<Message> Messages { get; set; }
    }
}
