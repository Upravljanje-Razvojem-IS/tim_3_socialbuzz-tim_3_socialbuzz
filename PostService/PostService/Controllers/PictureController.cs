using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.DTOs.PictureDTO;
using PostService.Interface;
using System;

namespace PostService.Controllers
{
    [Route("api/picture")]
    [ApiController]
    [Authorize]
    public class PictureController : ControllerBase
    {
        private readonly IPostPictureRepository _repo;

        public PictureController(IPostPictureRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        /// Get all post pictures
        /// </summary>
        /// <returns>List of all post pictures</returns>
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
        /// Get post picture by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Post picture</returns>
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
        /// Create new postPicture
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Confirmation of new picture</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult PostPicture([FromBody] PictureCreateDto dto)
        {
            var confirmation = _repo.Create(dto);

            return Ok(confirmation);
        }

        /// <summary>
        /// Update existing postPicture
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>Confirmation of updated picture</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult PutPicture(Guid id, [FromBody] PictureCreateDto dto)
        {
            var confirmation = _repo.Update(id, dto);

            return Ok(confirmation);
        }

        /// <summary>
        /// Delete PostPicture by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public ActionResult DeletePicture(Guid id)
        {
            _repo.Delete(id);

            return Ok();
        }
    }
}
