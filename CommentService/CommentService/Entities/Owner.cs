using System;

namespace CommentService.Entities
{
    public class Owner
    {
        /// <summary>
        /// owner id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
    }
}
