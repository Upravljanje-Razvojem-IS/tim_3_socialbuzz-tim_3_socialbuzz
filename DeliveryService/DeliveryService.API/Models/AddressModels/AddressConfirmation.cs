using System;

namespace DeliveryService.API.Models.AddressModels
{
    /// <summary>
    /// Address confirmation model
    /// </summary>
    public class AddressConfirmation
    {
        /// <summary>
        /// ID of Address Confirmation
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Street in address
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Address number
        /// </summary>
        public int Number { get; set; }
    }
}
