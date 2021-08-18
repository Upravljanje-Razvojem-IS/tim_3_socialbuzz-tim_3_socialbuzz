using DeliveryService.API.Interfaces;
using DeliveryService.API.Models.AddressModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeliveryService.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/addresses")]
    [Authorize(Roles = "Admin,User")]
    [Produces("application/json", "application/xml")]

    public class AddressController : ControllerBase
    {
        private readonly IAddressService _address;

        public AddressController(IAddressService address)
        {
            _address = address;
        }

        //PREGLED SVIH

        /// <summary>
        /// Get all addresses with cityId parameter
        /// </summary>
        /// <param name="cityId">ID of city where address is</param>
        /// <returns>Return list of all addresses in city with specific cityId</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet]
        public async Task<ActionResult<AddressOverview>> GetAddresses(Guid cityId)
        {
            var addresses = await _address.BrowseAsync(cityId);

            if (addresses.Count == 0)
            {
                return NoContent();
            }

            return Ok(addresses);
        }

        //PRETRAGA PO ID-ju

        /// <summary>
        /// Get address with  specific cityId and addressId parameter
        /// </summary>
        /// <param name="cityId">ID of the city where address is</param>
        /// <param name="addressId">ID of the returned address</param>
        /// <returns>Address with specific addressId</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("{addressId}")]
        public async Task<ActionResult<AddressDetails>> GetAddressById(Guid cityId, Guid addressId)
        {
            var address = await _address.FindAsync(cityId, addressId);

            if (address == null)
            {
                return NotFound();
            }
            
            return Ok(address);
        }

        //KREIRANJE 

        /// <summary>
        /// Create a new Address in City with specific cityId
        /// </summary>
        /// <param name="cityId">ID of specific city</param>
        /// <param name="address">New Address body</param>
        /// <returns>Created new Address with 201 status code</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        public async Task<ActionResult<AddressConfirmation>> PostAddress(Guid cityId, [FromBody] AddressPostBody address)
        {
            var newAddress = await _address.CreateAsync(cityId, address);

            return CreatedAtAction(nameof(GetAddressById), new { cityId, addressId = newAddress.Id }, newAddress);
        }

        //IZMENA

        /// <summary>
        /// Update address with specific addressId
        /// </summary>
        /// <param name="cityId">ID of the city where address is</param>
        /// <param name="addressId">ID of the updated address</param>
        /// <param name="address">New body to address</param>
        /// <returns>Updated Address</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPut("{addressId}")]
        public async Task<ActionResult<AddressConfirmation>> PutAddress(Guid cityId, Guid addressId, [FromBody] AddressPutBody address)
        {
            var updatedAddress = await _address.UpdateAsync(cityId, addressId, address);

            if (updatedAddress == null)
            {
                return BadRequest("Sorry, address with that ID does not exist!");
            }

            return Ok(updatedAddress);
        }

        //BRISANJE

        /// <summary>
        /// Delete address with specific addressID 
        /// </summary>
        /// <param name="cityId">ID of city where address is</param>
        /// <param name="addressId">ID of deleted address</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddress(Guid cityId, Guid addressId)
        {
            await _address.DeleteAsync(cityId, addressId);
            return NoContent();
        }

    }
}
