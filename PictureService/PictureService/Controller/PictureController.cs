using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PictureService.DTO.PictureDTOs;
using PictureService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Controller
{
    [ApiController]
    [Route("api/picture")]
   
    public class PictureController :ControllerBase
    {

        private readonly IPictureRepository _repository;

        public PictureController(IPictureRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Get all Pictures
        /// </summary>
        /// <returns>Pictures list</returns>
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
        /// Picture by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Picture</returns>
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



        /// Create Picture
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>New picture</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult Post([FromBody] PictureCreateDto dto)
        {
            var entity = _repository.Create(dto);

            return Ok(entity);
        }



        /// <summary>
        /// Update of Picture
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>New Picture</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, PictureCreateDto dto)
        {
            var entity = _repository.Update(id, dto);

            return Ok(entity);
        }



        /// <summary>
        /// Delete Picture
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
