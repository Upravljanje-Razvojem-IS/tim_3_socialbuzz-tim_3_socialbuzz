using System;

namespace CommentService.DTOs.PostDTOs
{
    public class PostConfirmationDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title post
        /// </summary>
        public string Title { get; set; }
    }
}
