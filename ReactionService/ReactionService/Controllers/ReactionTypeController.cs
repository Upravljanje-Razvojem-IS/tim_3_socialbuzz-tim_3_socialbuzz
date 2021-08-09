using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ReactionService.Data;
using ReactionService.Entities;
using ReactionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Controllers
{
    [ApiController]
    [Route("api/reactionTypes")]
    public class ReactionTypeController : ControllerBase
    {
        private readonly IReactionTypeRepository reactionTypeRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public ReactionTypeController(IReactionTypeRepository reactionTypeRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.reactionTypeRepository = reactionTypeRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve tipove reakcija.
        /// </summary>
        /// <param name="reactionName">Naziv tipa reakcije.</param>
        /// <returns>Lista tipova reackija</returns>
        [HttpGet]
        public ActionResult<List<ReactionTypeDto>> GetReactionTypes([FromQuery] string reactionName)
        {
            var reactions = reactionTypeRepository.GetReactionTypes(reactionName);
            if (reactions == null || reactions.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<ReactionTypeDto>>(reactions));
        }

        /// <summary>
        /// Vraća jedan tip reakcije na osnovu ID-ja tipa reakcije.
        /// </summary>
        /// <param name="reactionId">ID tipa reakcije</param>
        /// <returns></returns>
        [HttpGet("{reactionTypeId}")]
        public ActionResult<ReactionTypeDto> GetReactionType([FromRoute] Guid reactionTypeId)
        {
            var reactionType = reactionTypeRepository.GetReactionTypeById(reactionTypeId);
            if (reactionType == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<ReactionTypeDto>(reactionType));
        }

        /// <summary>
        /// Kreira nov tip reakcije.
        /// </summary>
        /// <param name="reactionType">Model tipa reakcije</param>
        /// <returns>Kreiran tip reakcije iz liste.</returns>
        [HttpPost]
        public ActionResult<ReactionTypeDto> CreateReactionType([FromBody] ReactionTypeCreateDto reactionType)
        {
            var reactionTypeEntity = mapper.Map<ReactionType>(reactionType);

            var reaction = reactionTypeRepository.CreateReactionType(reactionTypeEntity);
            string location = linkGenerator.GetPathByAction("GetReactionType", "ReactionType", new { reactionTypeId = reaction.ReactionTypeID });
            return Created(location, mapper.Map<ReactionTypeDto>(reaction));
        }

        /// <summary>
        /// Vrši brisanje jednog tipa reakcije na osnovu ID-ja.
        /// </summary>
        /// <param name="reactionTypeId">ID tipa reakcije</param>
        /// <returns>Status 204 (NoContent)</returns>
        [HttpDelete("{reactionTypeId}")]
        public ActionResult DeleteReactionType(Guid reactionTypeId)
        {
            try
            {
                var reaction = reactionTypeRepository.GetReactionTypeById(reactionTypeId);
                if (reaction == null)
                {
                    return NotFound();
                }
                reactionTypeRepository.DeleteReactionType(reactionTypeId);
                return NoContent();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Ažurira jedan tip reakcije.
        /// </summary>
        /// <param name="reactionType">Model tipa reakcije koji se ažurira</param>
        /// <returns>Ažuriran tip reakcije iz liste.</returns>
        [HttpPut]
        public ActionResult<ReactionTypeDto> UpdateReactionType ([FromBody] ReactionTypeUpdateDto reactionType)
        {
            try
            {
                if( GetReactionType(reactionType.ReactionTypeID) == null)
                {
                    return NotFound();
                }
                var reactionTypeEntity = mapper.Map<ReactionType>(reactionType);

                var reaction = reactionTypeRepository.UpdateReactionType(reactionTypeEntity);
                return Ok(mapper.Map<ReactionTypeDto>(reaction));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        [HttpOptions]
        public IActionResult GetReactionOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
