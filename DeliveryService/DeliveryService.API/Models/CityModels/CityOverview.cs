using System;

namespace DeliveryService.API.Models.CityModels
{
    /// <summary>
    /// City overview model
    /// </summary>
    public class CityOverview
    {
        /// <summary>
        /// City overview Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// City PostalCode
        /// </summary>
        public string PostalCode { get; set; }

        //Geodrafska sirina grada

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
