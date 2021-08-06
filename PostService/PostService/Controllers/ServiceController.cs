using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.DTOs.ServiceDTOs;
using PostService.Interface;
using System;

namespace PostService.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _repo;

        public ServiceController(IServiceRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get all Services
        /// </summary>
        /// <returns>List of services</returns>
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
        /// Get service by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Service</returns>
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
        /// Create new service
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Confirmation of new Service</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult PostService([FromBody] ServiceCreateDTO dto)
        {
            var confirmation = _repo.Create(dto);

            return Ok(confirmation);
        }

        /// <summary>
        /// Update existing service
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>confirmation of updated service</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult PutService(Guid id, [FromBody] ServiceCreateDTO dto)
        {
            var confirmation = _repo.Update(id, dto);

            return Ok(confirmation);
        }

        /// <summary>
        /// Delete service by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult DeleteService(Guid id)
        {
            _repo.Delete(id);

            return Ok();
        }
    }
}
