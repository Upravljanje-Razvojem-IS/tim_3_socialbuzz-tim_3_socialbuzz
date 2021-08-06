using PostService.Entities;
using System;

namespace PostService.DTOs.ServiceDTOs
{
    public class ServiceConfirmationDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public Guid? PostPictureId { get; set; }
        public PostPicture? PostPicture{ get; set; }
        public int OwnerId { get; set; }
        public int PriceId { get; set; }
        public decimal Durotation { get; set; }
    }
}
