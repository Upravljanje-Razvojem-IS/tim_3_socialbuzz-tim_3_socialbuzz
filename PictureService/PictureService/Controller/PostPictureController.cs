using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PictureService.DTOs.PostPictureDTOs;
using PictureService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Controller
{

    [ApiController]
    [Route("api/postPicture")]
    public class PostPictureController:ControllerBase
    {
        private readonly IPostPictureRepository _repository;

        public PostPictureController(IPostPictureRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Get all PostPictures
        /// </summary>
        /// <returns>PostPictures list</returns>
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
        /// PostPicture by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PostPicture</returns>
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
        /// Create PostPicture
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>New PostPicture</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult Post ([FromBody] PostPictureCreateDto dto)
        {
            var entity = _repository.Create(dto);
            return Ok(entity);
        }




        /// <summary>
        /// Update of PostPicture
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>New PostPicture</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult Put(Guid id,PostPictureCreateDto dto)
        {
            var entity = _repository.Update(id, dto);
            return Ok(entity);
        }

        /// <summary>
        /// Delete PostPicture
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
