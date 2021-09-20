using System;

namespace CommentService.Entities
{
    public class Post
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
