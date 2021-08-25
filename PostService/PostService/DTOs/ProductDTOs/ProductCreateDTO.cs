using System;

namespace PostService.DTOs.ProductDTOs
{
    public class ProductCreateDto
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public Guid? PostPictureId { get; set; }
        public int OwnerId { get; set; }
        public int PriceId { get; set; }
        public decimal Weight { get; set; }
        public int Quantity { get; set; }
        public bool Fragile { get; set; }
        public bool Dangerious { get; set; }
    }
}
