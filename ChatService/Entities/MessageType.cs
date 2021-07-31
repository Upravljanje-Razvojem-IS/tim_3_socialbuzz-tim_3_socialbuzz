using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatService.Entities
{
    public class MessageType
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Type name
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Messages with type
        /// </summary>
        public List<Message> Messages { get; set; }
    }
}
