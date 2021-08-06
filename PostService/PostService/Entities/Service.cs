using System.ComponentModel.DataAnnotations;

namespace PostService.Entities
{
    public class Service : Post
    {
        [Required]
        public decimal Durotation { get; set; }
    }
}
