using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriceService.Entities
{
    public class Price
    {
        /// <summary>
        /// Price id
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Amount { get; set; }
        /// <summary>
        /// Currency
        /// </summary>
        [Required]
        public string Currency { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// Post id
        /// </summary>
        [Required]
        public Guid PostId { get; set; }
        /// <summary>
        /// List of price histories
        /// </summary>
        public List<PriceHistory> PriceHistories { get; set; }

    }
}
