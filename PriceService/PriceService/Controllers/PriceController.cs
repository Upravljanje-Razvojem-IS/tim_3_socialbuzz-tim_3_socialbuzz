using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceService.DTOs;
using PriceService.Intefaces;
using System;

namespace PriceService.Controllers
{
    [ApiController]
    [Route("api/prices")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceRepository _repo;

        public PriceController(IPriceRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get all prices
        /// </summary>
        /// <returns>list of prices</returns>
        /// [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult GetAll()
        {
            var prices = _repo.Get();

            if (prices.Count == 0)
                return NoContent();

            return Ok(prices);
        }

        /// <summary>
        /// Get price by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Price</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var price = _repo.Get(id);

            if (price == null)
                return NotFound();

            return Ok(price);
        }

        /// <summary>
        /// Create new price
        /// </summary>
        /// <param name="newPrice"></param>
        /// <returns>Create confirmation</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult PostNew([FromBody] PriceCreateDTO newPrice)
        {
            var createPrice = _repo.Create(newPrice);

            return Ok(createPrice);
        }

        /// <summary>
        /// Update price by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns>Update confirmation</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult UpdatePrice(Guid id, [FromBody] PriceCreateDTO update)
        {
            var updatedPrice = _repo.Update(id, update);

            if (updatedPrice == null)
                return NotFound();

            return Ok(updatedPrice);
        }

        /// <summary>
        /// Delete price by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult DeletePrice(Guid id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
