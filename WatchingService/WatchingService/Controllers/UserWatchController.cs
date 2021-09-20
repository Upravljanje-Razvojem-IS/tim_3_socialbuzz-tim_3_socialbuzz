using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WatchingService.DTOs;
using WatchingService.Interfaces;

namespace WatchingService.Controllers
{
    [ApiController]
    [Route("api/UserWatch")]
    [Authorize]
    public class UserWatchController : ControllerBase
    {
        private readonly IUserWatchRepository _repository;

        public UserWatchController(IUserWatchRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all UserWatchs
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
        /// UserWatch by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserWatch</returns>
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
        /// Create UserWatch
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>new UserWatch</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult Post([FromBody] UserWatchCreateDto dto)
        {
            var entity = _repository.Create(dto);

            return Ok(entity);
        }

        /// <summary>
        /// Update UserWatch
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>new UserWatch</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, UserWatchCreateDto dto)
        {
            var entity = _repository.Update(id, dto);

            return Ok(entity);
        }

        /// <summary>
        /// Delete UserWatch
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
