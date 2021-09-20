using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentService.Entities
{
    public class Comment
    {
        /// <summary>
        /// Comment Id
        /// </summary>
        [Key]
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
        [ForeignKey("Owner")]
        public Guid UserId { get; set; }
        /// <summary>
        /// Owner
        /// </summary>
        public Owner Owner{ get; set; }
        /// <summary>
        /// Id of commented post
        /// </summary>
        [ForeignKey("Post")]
        public Guid PosId { get; set; }
        /// <summary>
        /// Post
        /// </summary>
        public Post Post { get; set; }
    }
}
