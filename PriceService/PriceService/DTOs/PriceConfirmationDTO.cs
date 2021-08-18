using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceService.DTOs
{
    public class PriceConfirmationDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public Guid PostId { get; set; }
    }
}
