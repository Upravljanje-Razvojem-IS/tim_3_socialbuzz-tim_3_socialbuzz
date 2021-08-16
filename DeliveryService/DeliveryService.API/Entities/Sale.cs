using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.API.Entities
{
    /// <summary>
    /// Represent Sale
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Sale ID
        /// </summary>
        [Key]
        public Guid Id { get; set; }


        /// <summary>
        /// ID of product
        /// </summary>
        public Guid ProductId { get; set; }


        /// <summary>
        /// Product pieces
        /// </summary>
        [Range(0, 100)]
        [Required]
        public int Pieces { get; set; }


        /// <summary>
        /// Total weight of whole product
        /// </summary>
        [Range(0, 100, ErrorMessage = "Oops, Total weight of whole product must be greater than 0 and less than 100 kilograms!")]
        [Required]
        public double TotalWeight { get; set; }


        /// <summary>
        /// Total price 
        /// </summary>
        [Required]
        public double TotalPriceWithWeightAndDistance { get; set; }


        /// <summary>
        /// Distance for delivery
        /// </summary>
        [Required]
        public double Distance { get; set; }


        /// <summary>
        /// ID of WeightRange
        /// </summary>
        [Required]
        [ForeignKey("WeightRange")]
        public Guid WeightRangeId { get; set; }


        /// <summary>
        /// WeightRange object
        /// </summary>
        public WeightRange WeightRange { get; set; }

        /// <summary>
        /// ID of PriceDistance
        /// </summary>
        [Required]
        [ForeignKey("PriceDistance")]
        public Guid PriceDistanceId { get; set; }


        /// <summary>
        /// PriceDistance object
        /// </summary>
        public PriceDistance PriceDistance { get; set; }


        /// <summary>
        /// ID of FROM Address
        /// </summary>
        [Required]
        [ForeignKey("FromAddess")]
        public Guid FromAddressId { get; set; }


        /// <summary>
        /// FROM Address object
        /// </summary>
        public Address FromAddess { get; set; }


        /// <summary>
        /// ID of TO Address
        /// </summary>
        [Required]
        [ForeignKey("ToAddress")]
        public Guid ToAddressId { get; set; }


        /// <summary>
        /// TO Address object
        /// </summary>
        public Address ToAddress { get; set; }

    }
}
