using DeliveryService.API.Entities;
using System;

namespace DeliveryService.API.Models.AddressModels
{
    public class AddressDetails
    {
        /// <summary>
        /// Id of Address Details
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

        /// <summary>
        /// Body of City
        /// </summary>
        public City City { get; set; }
    }
}
