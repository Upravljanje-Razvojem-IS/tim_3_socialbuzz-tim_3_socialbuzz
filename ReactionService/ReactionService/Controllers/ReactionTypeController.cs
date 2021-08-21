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
        /// <response code="200">Uspešno izlistani svi tipovi reakcija</response>
        /// <response code="204">Tipovi reakcija ne postoje</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        [HttpGet]
        public ActionResult<List<ReactionTypeDto>> GetReactionTypes()
        {
            var reactions = reactionTypeRepository.GetReactionTypes();
            if (reactions == null || reactions.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<ReactionTypeDto>>(reactions));
        }

        /// <summary>
        /// Vraća jedan tip reakcije na osnovu ID-ja tipa reakcije.
        /// </summary>
        /// <param name="reactionTypeId">ID tipa reakcije</param>
        /// <response code="200">Uspešno izlistan tip reakcije sa datim ID-em</response>
        /// <response code="204">Tip reakcije ne postoji</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json", "application/xml")]
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
        /// <response code="201">Uspešno kreiran novi tip reakcije</response>
        /// <response code="400">Pogrešno uneti podaci</response>
        /// <remarks>
        /// Primer zahteva za kreiranje novog tipa reakcije \
        /// POST /api/reactionTypes \
        /// {   \
        ///     "reactionTypeName": "New reaction", \
        ///     "reactionTypeImage": "newReaction.img" \
        /// }
        /// </remarks>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json", "application/xml")]
        [HttpPost]
        public ActionResult<ReactionTypeDto> CreateReactionType([FromBody] ReactionTypeCreateDto reactionType)
        {
            try
            {
                var reactionTypeEntity = mapper.Map<ReactionType>(reactionType);

                var reaction = reactionTypeRepository.CreateReactionType(reactionTypeEntity);
                string location = linkGenerator.GetPathByAction("GetReactionType", "ReactionType", new { reactionTypeId = reaction.ReactionTypeID });
                return Created(location, mapper.Map<ReactionTypeDto>(reaction));
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Create error, not acceptable value");
            }
            
        }

        /// <summary>
        /// Vrši brisanje jednog tipa reakcije na osnovu ID-ja.
        /// </summary>
        /// <param name="reactionTypeId">ID tipa reakcije</param>
        /// <response code="404">Tip reakcije sa datim ID-em ne postoji</response>
        /// <response code="204">Uspešno obrisan tip reakcije</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
        /// <response code="404">Tip reakcije sa datim ID-em ne postoji</response>
        /// <response code="200">Uspešno ažuriran tip reakcije</response>
        /// <remarks>
        /// Primer zahteva za ažuriranje tipa reakcije \
        /// PUT /api/reactionTypes \
        /// {   \
        ///     "reactionTypeID": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///     "reactionTypeName": "New reaction", \
        ///     "reactionTypeImage": "newReaction.img" \
        /// }
        /// </remarks>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json", "application/xml")]
        [HttpPut]
        public ActionResult<ReactionTypeDto> UpdateReactionType ([FromBody] ReactionTypeUpdateDto reactionType)
        {
            try
            {
                if(reactionTypeRepository.GetReactionTypeById(reactionType.ReactionTypeID) == null)
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
#pragma warning disable CS1591
        [HttpOptions]
        public IActionResult GetReactionOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
#pragma warning restore CS1591
    }
}
