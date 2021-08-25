using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.API.Models.PriceDistanceModels
{
    /// <summary>
    /// Price Distance put model
    /// </summary>
    public class PriceDistancePutBody
    {
        /// <summary>
        /// Minimal Distance for some price
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Oops, Minimal Distance must be greater then 0!")]
        public int MinimalDistance { get; set; }

        /// <summary>
        /// Maximal Distance for some price
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Oops, Maximal Distance must be greater then 0!")]
        public int MaximalDistance { get; set; }

        /// <summary>
        /// Price for some distance
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Oops, Price must be greater then 0!")]
        public double Price { get; set; }
    }
}
