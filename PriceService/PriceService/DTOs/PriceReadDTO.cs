using System;

namespace PriceService.DTOs
{
    public class PriceReadDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public Guid PostId { get; set; }
    }
}
