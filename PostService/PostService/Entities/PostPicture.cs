using System;
using System.ComponentModel.DataAnnotations;

namespace PostService.Entities
{
    public class PostPicture
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Url { get; set; }

        public Post Post;
    }
}
