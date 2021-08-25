using System;

namespace DeliveryService.API.Models.WeightRangeModels
{
    /// <summary>
    /// Weight Range Confirmation model
    /// </summary>
    public class WeightRangeConfirmation
    {
        /// <summary>
        /// Weight range ID
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// Minimal Weight of products for price coefficient
        /// </summary>
        public float MinimalWeight { get; set; }


        /// <summary>
        /// Maximal Weight of products for price coefficient
        /// </summary>
        public float MaximalWeight { get; set; }
    }
}
