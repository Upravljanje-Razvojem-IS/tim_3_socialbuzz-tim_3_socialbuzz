using DeliveryService.API.Interfaces;
using DeliveryService.API.Models.SaleModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeliveryService.API.Controllers
{
    [ApiController]
    [Route("api/sale")]
    [Authorize]
    [Produces("application/json", "application/xml")]

    public class SaleController : ControllerBase
    {
        private readonly ISaleService _sale;

        public SaleController(ISaleService sale)
        {
            _sale = sale;
        }

        //PREGLED SVIH

        /// <summary>
        /// Get all Sales
        /// </summary>
        /// <returns>List of all sales</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet]
        public async Task<ActionResult<SaleOverview>> GetSales()
        {
            var sales = await _sale.BrowseAsync();

            if (sales.Count == 0)
            {
                return NoContent();
            }

            return Ok(sales);
        }

        //PRETRAGA PO ID-ju

        /// <summary>
        /// Get Sale by specific ID
        /// </summary>
        /// <param name="saleId">ID of specific Sale</param>
        /// <returns>Sale with specific saleId</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("{saleId}")]
        public async Task<ActionResult<SaleDetails>> GetSaleById(Guid saleId)
        {
            var sale = await _sale.FindAsync(saleId);

            return Ok(sale);
        }

        //KREIRANJE

        /// <summary>
        /// Create new Sale
        /// </summary>
        /// <param name="sale">Body of new Sale</param>
        /// <returns>Created new Sale with 201 status code</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        public async Task<ActionResult<SaleConfirmation>> PostSale(SalePostBody sale)
        {
            var newSale = await _sale.CreateAsync(sale);

            return CreatedAtAction(nameof(GetSaleById), new { saleId = newSale.Id }, newSale);
            
        }

        //IZMENA 

        /// <summary>
        /// Update specific Sale
        /// </summary>
        /// <param name="saleId">ID of updated Sale</param>
        /// <param name="sale">New body of Sale</param>
        /// <returns>Updated Sale</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPut("{saleId}")]
        public async Task<ActionResult<SaleConfirmation>> PutSale(Guid saleId, SalePutBody sale)
        {
            var updatedSale = await _sale.UpdateAsync(saleId, sale);

            return Ok(updatedSale);
        }

        //BRISANJE

        /// <summary>
        /// Delete Sale
        /// </summary>
        /// <param name="saleId">ID of deleted Sale</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpDelete("{saleId}")]
        public async Task<IActionResult> DeleteSale(Guid saleId)
        {
            await _sale.RemoveAsync(saleId);

            return NoContent();
        }
    }
}
