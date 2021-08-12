using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.DTOs.ProductDTOs;
using PostService.Interface;
using System;

namespace PostService.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>list of products</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult GetAll()
        {
            var entities = _repo.Get();

            if (entities.Count == 0)
                return NoContent();

            return Ok(entities);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var entity = _repo.Get(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Confirmation of new product</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult PostProduct([FromBody] ProductCreateDTO dto)
        {
            var confirmation = _repo.Create(dto);

            return Ok(confirmation);
        }

        /// <summary>
        /// Update existing product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>Confirmation of updated product</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult PutProduct(Guid id, [FromBody] ProductCreateDTO dto)
        {
            var confirmation = _repo.Update(id, dto);

            return Ok(confirmation);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            _repo.Delete(id);

            return Ok();
        }
    }
}
