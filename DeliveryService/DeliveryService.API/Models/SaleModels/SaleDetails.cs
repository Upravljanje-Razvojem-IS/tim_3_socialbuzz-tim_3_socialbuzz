using System;

namespace DeliveryService.API.Models.SaleModels
{
    /// <summary>
    /// Sale details model
    /// </summary>
    public class SaleDetails
    {
        public Guid Id { get; set; }

        /// <summary>
        /// ID of details product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// ID of sale Weight Range
        /// </summary>
        public Guid WeightRangeId { get; set; }

        /// <summary>
        /// ID of sale Price Distance
        /// </summary>
        public Guid PriceDistanceId { get; set; }

        /// <summary>
        /// ID of purchase FROM address
        /// </summary>
        public Guid FromAddressId { get; set; }

        /// <summary>
        /// ID of sale TO address
        /// </summary>
        public Guid ToAddressId { get; set; }

        /// <summary>
        /// Number of item pieces
        /// </summary>
        public int Pieces { get; set; }

        /// <summary>
        /// Sale total weight
        /// </summary>
        public double TotalWeight { get; set; }

        /// <summary>
        /// Total price for sale
        /// </summary>
        public double TotalPriceWithWeightAndDistance { get; set; }
    }
}
