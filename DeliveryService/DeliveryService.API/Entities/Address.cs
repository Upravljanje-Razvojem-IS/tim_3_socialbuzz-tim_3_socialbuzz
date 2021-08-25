using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.API.Entities
{
    /// <summary>
    /// Represent addess
    /// </summary>
    public class Address
    {
        /// <summary>
        /// ID of address
        /// </summary>
        [Key]
        public Guid Id { get; set; }


        /// <summary>
        /// Name of address street
        /// </summary>
        [Required]
        public string Street { get; set; }


        /// <summary>
        /// Address number
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Oops, Number of street must be greater then 0!")]
        public int Number { get; set; }


        /// <summary>
        /// City ID for address
        /// </summary>
        [Required]
        [ForeignKey("City")]
        public Guid CityId { get; set; }


        /// <summary>
        /// City object for address
        /// </summary>
        public City City { get; set; }
    }
}
