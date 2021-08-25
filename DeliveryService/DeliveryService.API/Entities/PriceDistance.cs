using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.API.Entities
{
    /// <summary>
    /// Represent DistancePrice
    /// </summary>
    public class PriceDistance
    {
        /// <summary>
        /// ID of PriceDistance
        /// </summary>
        [Key]
        public Guid Id { get; set; }


        /// <summary>
        /// MinimalDistance for some price
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Oops, Minimal Distance for some price must be greater then 0!")]
        public int MinimalDistance { get; set; }


        /// <summary>
        /// MaximalDistance for some price
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Oops, Maximal Distance fot some price must be greater then 1!")]
        public int MaximalDistance { get; set; }


        /// <summary>
        /// Price for distance
        /// </summary>
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Oops, Price must be greater then 0!")]
        public double Price { get; set; }
    }
}
