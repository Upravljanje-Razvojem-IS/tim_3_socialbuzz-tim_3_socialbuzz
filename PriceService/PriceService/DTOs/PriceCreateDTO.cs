using System;

namespace PriceService.DTOs
{
    public class PriceCreateDTO
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public Guid PostId { get; set; }
    }
}
