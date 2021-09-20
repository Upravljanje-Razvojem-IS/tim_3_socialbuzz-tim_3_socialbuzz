using System;

namespace CommentService.DTOs.PostDTOs
{
    public class PostReadDto
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
