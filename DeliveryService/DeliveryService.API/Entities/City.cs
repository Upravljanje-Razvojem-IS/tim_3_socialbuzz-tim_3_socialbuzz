using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.API.Entities
{
    /// <summary>
    /// Represent City
    /// </summary>
    public class City
    {
        /// <summary>
        /// ID of city
        /// </summary>
        [Key]
        public Guid Id { get; set; }


        /// <summary>
        /// City name
        /// </summary>
        [Required]
        public string Name { get; set; }


        /// <summary>
        /// City Postal Code
        /// </summary>dd
        [Required]
        public string PostalCode { get; set; }

        //Geografska sirina grada

        /// <summary>
        /// Latitude of city
        /// </summary>
        [Required]
        public double Latitude { get; set; }

        //Geografska duzina grada

        /// <summary>
        /// Longitude of city
        /// </summary>
        [Required]
        public double Longitude { get; set; }
    }
}
