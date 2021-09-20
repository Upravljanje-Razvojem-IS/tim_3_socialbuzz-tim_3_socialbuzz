using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentService.DTOs.CommentDTOs
{
    public class CommentReadDto
    {
        /// <summary>
        /// Comment Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Comment content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Date and time when comment is created
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Id of user who created comment
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Id of commented post
        /// </summary>
        public Guid PosId { get; set; }
    }
}
