using System;

namespace DeliveryService.API.Models.SaleModels
{
    /// <summary>
    /// Sale overview model
    /// </summary>
    public class SaleOverview
    {
        public Guid Id { get; set; }

        /// <summary>
        /// ID of overview product
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
        /// ID of sale FROM address
        /// </summary>
        public Guid FromAddressId { get; set; }

        /// <summary>
        /// ID of sale TO address
        /// </summary>
        public Guid ToAddressId { get; set; }
    }
}
