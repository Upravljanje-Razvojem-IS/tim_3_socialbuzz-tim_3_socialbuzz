using System;

namespace CommentService.DTOs.CommentDTOs
{
    public class CommentConfirmationDto
    {
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
        public int UserId { get; set; }
        /// <summary>
        /// Id of commented post
        /// </summary>
        public int PosId { get; set; }
    }
}
