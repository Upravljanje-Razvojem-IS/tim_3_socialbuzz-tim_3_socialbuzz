using System;

namespace DeliveryService.API.Models.CityModels
{
    /// <summary>
    /// City Confirmation model
    /// </summary>
    public class CityConfirmation
    {
        /// <summary>
        /// City confirmation Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// City Postal Code
        /// </summary>
        public string PostalCode { get; set; }

        //Geografska sirina grada

        /// <summary>
        /// City Latitude
        /// </summary>
        public double Latitude { get; set; }

        //Geografska duzina grada

        /// <summary>
        /// City Longitude
        /// </summary>
        public double Longitude { get; set; }
    }
}
