using DeliveryService.API.Interfaces;
using DeliveryService.API.Models.WeightRangeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeliveryService.API.Controllers
{
    [ApiController]
    [Route("api/weightRange")]
    [Produces("application/json", "application/xml")]

    public class WeightRangeController : ControllerBase
    {
        private readonly IWeightRangeService _weight;

        public WeightRangeController(IWeightRangeService weight)
        {
            _weight = weight;
        }

        //PREGLED SVIH

        /// <summary>
        /// Get all Weight Ranges
        /// </summary>
        /// <returns>List of all Weight Ranges</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<ActionResult<WeightRangeOverview>> GetWeightRange()
        {
            var weight = await _weight.BrowseAsync();

            if (weight.Count == 0)
            {
                return NoContent();
            }

            return Ok(weight);
        }

        //PRETRAGA PO ID-ju

        /// <summary>
        /// Get Weight Range by specific ID
        /// </summary>
        /// <param name="weightId">ID of specific Weight Range</param>
        /// <returns>Weight Range with specific weightId</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{weightId}")]
        public async Task<ActionResult<WeightRangeDetails>> GetWeightRangeById(Guid weightId)
        {
            var weight = await _weight.FindAsync(weightId);

            return Ok(weight);
        }

        //KREIRANJE 

        /// <summary>
        /// Post new Weight Range
        /// </summary>
        /// <param name="weightRange">Body of new Weigh tRange</param>
        /// <returns>Created Weight Range with 201 status code</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<WeightRangeConfirmation>> PostWeightRange([FromBody] WeightRangePostBody weightRange)
        {
            var newWeight = await _weight.CreateAsync(weightRange);

            return CreatedAtAction(nameof(GetWeightRangeById), new { weightId = newWeight.Id }, newWeight);
        }

        //IZMENA

        /// <summary>
        /// Update specific Weight Range
        /// </summary>
        /// <param name="weightId">ID of updated Weight Range</param>
        /// <param name="weightRange">New body of Weight Range</param>
        /// <returns>New Weight Range</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin")]
        [HttpPut("{weightId}")]
        public async Task<ActionResult<WeightRangeConfirmation>> PutWeightRange(Guid weightId, [FromBody] WeightRangePutBody weightRange)
        {
            var updatedWeight = await _weight.UpdateAsync(weightId, weightRange);

            return Ok(updatedWeight);
        }

        //BRISANJE

        /// <summary>
        /// Delete speific Weight Range
        /// </summary>
        /// <param name="weightId">ID of deleted Weight Range</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin")]
        [HttpDelete("{weightId}")]
        public async Task<IActionResult> DeleteWeithRange(Guid weightId)
        {
            await _weight.DeleteAsync(weightId);

            return NoContent();
        }
    }
}
