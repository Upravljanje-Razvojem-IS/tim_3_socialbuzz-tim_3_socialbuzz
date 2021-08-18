using System.ComponentModel.DataAnnotations;

namespace DeliveryService.API.Models.CityModels
{
    /// <summary>
    /// City put model
    /// </summary>
    public class CityPutBody
    {
        /// <summary>
        /// City Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// City Postal Code
        /// </summary>
        [Required]
        public string PostalCode { get; set; }

        //Geografska sirina grada

        /// <summary>
        /// City Latitude
        /// </summary>
        [Required]
        public double Latitude { get; set; }

        //Geografska duzina grada

        /// <summary>
        /// City Longitude
        /// </summary>
        [Required]
        public double Longitude { get; set; }
    }
}
