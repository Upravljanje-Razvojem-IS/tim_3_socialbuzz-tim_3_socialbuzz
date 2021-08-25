using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.API.Models.SaleModels
{
    /// <summary>
    /// Sale POST model
    /// </summary>
    public class SalePostBody
    {
        /// <summary>
        /// ID of sale product
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Number of product pieces
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Oops, Product pieces value must be greater then 0!")]
        public int Pieces { get; set; }

        /// <summary>
        /// ID of sale FROM address
        /// </summary>
        [Required]
        public Guid FromAddressId { get; set; }

        /// <summary>
        /// ID of sale TO address
        /// </summary>
        [Required]
        public Guid ToAddressId { get; set; }
    }
}
