using System;

namespace PriceService.DTOs
{
    public class PriceCreateDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public Guid PostId { get; set; }
    }
}
