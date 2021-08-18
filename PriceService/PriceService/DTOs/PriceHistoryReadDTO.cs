using System;

namespace PriceService.DTOs
{
    public class PriceHistoryReadDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public Guid PriceId { get; set; }
    }
}
