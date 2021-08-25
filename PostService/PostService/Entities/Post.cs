using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostService.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        [ForeignKey("PostPicture")]
        public Guid? PostPictureId { get; set; }
        public PostPicture PostPicture { get; set; }

        [Required]
        public int OwnerId { get; set; }
        [Required]
        public int PriceId { get; set; }
    }
}
