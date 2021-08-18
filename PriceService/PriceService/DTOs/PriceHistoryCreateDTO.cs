﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceService.DTOs
{
    public class PriceHistoryCreateDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public Guid PriceId { get; set; }
    }
}
