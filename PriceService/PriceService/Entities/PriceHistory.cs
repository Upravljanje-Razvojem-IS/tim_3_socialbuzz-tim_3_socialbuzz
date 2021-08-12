using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceService.Entities
{
    public class PriceHistory
    {
        /// <summary>
        /// Price history id
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
        /// DateFrom
        /// </summary>
        [Required]
        public DateTime DateFrom { get; set; }
        /// <summary>
        /// DateTo
        /// </summary>
        [Required]
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Price Id
        /// </summary>
        [ForeignKey("Price")]
        public Guid PriceId { get; set; }
        /// <summary>
        /// Price objet
        /// </summary>
        public Price Price { get; set; }
    }
}
