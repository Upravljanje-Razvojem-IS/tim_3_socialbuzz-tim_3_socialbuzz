using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.API.Models.AddressModels
{
    /// <summary>
    /// Address model for put
    /// </summary>
    public class AddressPutBody
    {
        /// <summary>
        /// Street in address is reqired
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public string Street { get; set; }

        //Sta uraditi sa adresama bez broja?

        /// <summary>
        /// Number in address is required
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Oops, Address Number must be greater then 0!")]
        public int Number { get; set; }
    }
}
