using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.API.Models.WeightRangeModels
{
    /// <summary>
    /// Weight Range put model
    /// </summary>
    public class WeightRangePutBody
    {
        /// <summary>
        /// Minimal Weight of products for price coefficient
        /// </summary>
        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Oops, Minimal Weight of products must be greater then 0!")]
        public float MinimalWeight { get; set; }


        /// <summary>
        /// Maximal Weight of products for price coefficient
        /// </summary>
        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Oops, Maximal Weight of products must be greater then 0!")]
        public float MaximalWeight { get; set; }


        /// <summary>
        /// Coefficient for calculating price
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Oops, Price Coefficient must be greater then 0!")]
        public double PriceCoefficient { get; set; }
    }
}
