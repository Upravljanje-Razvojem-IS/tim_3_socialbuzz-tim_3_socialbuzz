using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceService.DTOs;
using PriceService.Intefaces;
using System;

namespace PriceService.Controllers
{
    [ApiController]
    [Route("api/price-history")]
    public class PriceHistoryController : ControllerBase
    {
        private readonly IPriceHistoryRepository _repo;

        public PriceHistoryController(IPriceHistoryRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get all price histories
        /// </summary>
        /// <returns>List of price histories</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult GetAll()
        {
            var histories = _repo.Get();

            if (histories.Count == 0)
                return NoContent();

            return Ok(histories);
        }

        /// <summary>
        /// Get price history by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Price history</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var history = _repo.Get(id);

            if (history == null)
                return NotFound();

            return Ok(history);
        }

        /// <summary>
        /// Create new price history
        /// </summary>
        /// <param name="newPirceHistory"></param>
        /// <returns>price history confirmation</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult PostNew([FromBody] PriceHistoryCreateDto newPirceHistory)
        {
            var createPriceH = _repo.Create(newPirceHistory);

            return Ok(createPriceH);
        }

        /// <summary>
        /// Update price history
        /// </summary>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns>Update confirmation</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult UpdatePrice(Guid id, [FromBody] PriceHistoryCreateDto update)
        {
            var updatedPriceHistory = _repo.Update(id, update);

            if (updatedPriceHistory == null)
                return NotFound();

            return Ok(updatedPriceHistory);
        }

        /// <summary>
        /// Delete price history
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
