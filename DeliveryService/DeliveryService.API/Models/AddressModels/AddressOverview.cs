using System;


namespace DeliveryService.API.Models.AddressModels
{
    /// <summary>
    /// Address overview model
    /// </summary>
    public class AddressOverview
    {
        /// <summary>
        /// Id of Address Overview
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

        /// <summary>
        /// ID of City
        /// </summary>
        public Guid CityId { get; set; }
    }
}
