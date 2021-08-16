using DeliveryService.API.Interfaces;
using DeliveryService.API.Models.PriceDistanceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeliveryService.API.Controllers
{
    [ApiController]
    [Route("api/priceDistance")]
    [Produces("application/json", "application/xml")]
    public class PriceDistanceController : ControllerBase
    {
        private readonly IPriceDistance _distance;

        public PriceDistanceController(IPriceDistance distance)
        {
            _distance = distance;
        }

        //PREGLED SVIH

        /// <summary>
        /// Get all Price Distances
        /// </summary>
        /// <returns>Returns list of all Price Distances</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<ActionResult<PriceDistanceOverview>> GetPriceDistance()
        {
            var distances = await _distance.BrowseAsync();

            if (distances.Count == 0)
            {
                return NoContent();
            }

            return Ok(distances);
        }

        //PRETRAGA PO ID-ju

        /// <summary>
        /// Get Price Distance by specific  ID
        /// </summary>
        /// <param name="distanceId">ID of Price Distance</param>
        /// <returns>Distance with specific distanceId</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{distanceId}")]
        public async Task<ActionResult<PriceDistanceDetails>> GetPriceDistanceById(Guid distanceId)
        {
            var distance = await _distance.FindAsync(distanceId);

            return Ok(distance);
        }

        //DODAVANJE

        /// <summary>
        /// Post new Price Distance
        /// </summary>
        /// <param name="priceDistance">New Price Distance body</param>
        /// <returns>Created new Price Distance with 201</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<PriceDistanceConfirmation>> PostPriceDistance([FromBody] PriceDistancePostBody priceDistance)
        {
            var newPriceDistance = await _distance.CreateAsync(priceDistance);

            return CreatedAtAction(nameof(GetPriceDistanceById), new { distanceId = newPriceDistance.Id }, newPriceDistance);
        }

        //IZMENA

        /// <summary>
        /// Update Price Distance
        /// </summary>
        /// <param name="distanceId">ID of updated Price Distance</param>
        /// <param name="priceDistance">New Price Distance body</param>
        /// <returns>Updated Price Distance</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin")]
        [HttpPut("{distanceId}")]
        public async Task<ActionResult<PriceDistanceConfirmation>> PutPriceDistance(Guid distanceId, [FromBody] PriceDistancePutBody priceDistance)
        {
            var updatedPriceDistance = await _distance.UpdateAsync(distanceId, priceDistance);

            return Ok(updatedPriceDistance);
        }

        //BRISANJE

        /// <summary>
        /// Delete Price Distance with specific distanceID
        /// </summary>
        /// <param name="distanceId">ID of deleted Price Distance</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin")]
        [HttpDelete("{distanceId}")]
        public async Task<IActionResult> DeletePriceDistance(Guid distanceId)
        {
            await _distance.DeleteAsync(distanceId);

            return NoContent();
        }
    }
}
