using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.API.Entities
{
    /// <summary>
    /// Represent WeightRange
    /// </summary>
    public class WeightRange
    {
        /// <summary>
        /// ID of WeightRange
        /// </summary>
        [Key]
        public Guid Id { get; set; }


        /// <summary>
        /// MinimalWeight of products for coefficient
        /// </summary>
        [Range(0, float.MaxValue, ErrorMessage = "Oops, Minimal Weight of products must be greater then 0!")]
        public float MinimalWeight { get; set; }


        /// <summary>
        /// MaximalWeight of products for coefficient
        /// </summary>
        [Range(0, float.MaxValue, ErrorMessage = "Oops, Maximal Weight of products must be greater then 0!")]
        public float MaximalWeight { get; set; }


        /// <summary>
        /// Coefficient for calculating price
        /// </summary>
        public double PriceCoefficient { get; set; }
    }
}
