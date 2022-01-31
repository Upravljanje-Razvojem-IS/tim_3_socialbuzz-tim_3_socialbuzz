using BlockService.DTOs;
using BlockService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Controllers
{
    [ApiController]
    [Route("api/UserBlock")]
    public class UserBlockController : ControllerBase
    {
        private readonly IUserBlockRepository _repository;

        public UserBlockController(IUserBlockRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Get all UserBlocks
        /// </summary>
        /// <returns>List of UserWatchs</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult GetAll()
        {
            var entities = _repository.Get();

            if (entities.Count == 0)
                return NoContent();

            return Ok(entities);
        }

        /// <summary>
        /// UserBlock by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserBlock</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var entity = _repository.Get(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }



        /// <summary>
        /// Create UserBlock
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>new UserBlock</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost]
        public ActionResult Post([FromBody] UserBlockCreateDto dto)
        {
            var entity = _repository.Create(dto);

            return Ok(entity);
        }


        /// <summary>
        /// Update UserBlock
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>new UserBlock</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, UserBlockCreateDto dto)
        {
            var entity = _repository.Update(id, dto);

            return Ok(entity);
        }

        /// <summary>
        /// Delete UserBlock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _repository.Delete(id);

            return NoContent();
        }

    }
}
