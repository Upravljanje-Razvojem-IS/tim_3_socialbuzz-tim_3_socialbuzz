﻿using System;

namespace DeliveryService.API.Models.PriceDistanceModels
{
    /// <summary>
    /// Price Distance details model
    /// </summary>
    public class PriceDistanceDetails
    {
        /// <summary>
        /// Price Distance details model ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Minimal Distance for some price
        /// </summary>
        public int MinimalDistance { get; set; }

        /// <summary>
        /// Maximal Distance for some price
        /// </summary>
        public int MaximalDistance { get; set; }

        /// <summary>
        /// Distance price
        /// </summary>
        public double Price { get; set; }
    }
}
