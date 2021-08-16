using System;

namespace DeliveryService.API.MockedProduct
{
    /// <summary>
    /// Mock for product
    /// </summary>
    public class ProductMock
    {
        /// <summary>
        /// Prouct ID
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Weight of one product
        /// </summary>
        public float Weight { get; set; }


        /// <summary>
        /// Price of one product
        /// </summary>
        public double Price { get; set; }
    }
}
