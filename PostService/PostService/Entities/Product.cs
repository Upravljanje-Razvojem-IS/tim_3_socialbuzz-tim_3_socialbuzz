using System.ComponentModel.DataAnnotations;

namespace PostService.Entities
{
    public class Product : Post
    {
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool Fragile { get; set; }
        [Required]
        public bool Dangerious { get; set; }
    }
}
