﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ReactionService.Data;
using ReactionService.Data.LoggerMocks;
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
        private readonly IUserMockRepository userMockRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerMockRepository<ReactionTypeController> logger;

        public ReactionTypeController(IReactionTypeRepository reactionTypeRepository,IUserMockRepository userMockRepository,
                                        LinkGenerator linkGenerator, IMapper mapper, ILoggerMockRepository<ReactionTypeController> logger)
        {
            this.reactionTypeRepository = reactionTypeRepository;
            this.userMockRepository = userMockRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Vraća sve tipove reakcija.
        /// </summary>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="200">Uspešno izlistani svi tipovi reakcija</response>
        /// <response code="204">Tipovi reakcija ne postoje</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za izlistavanje svih tipova reakcija
        /// GET 'http://localhost:44200/api/reactionTypes/' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization'
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [HttpGet]
        public ActionResult<List<ReactionTypeDto>> GetReactionTypes([FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            var reactions = reactionTypeRepository.GetReactionTypes();
            if (reactions == null || reactions.Count == 0)
            {
                return NoContent();
            }
            logger.LogInformation("Successfully listed all reactions types");
            return Ok(mapper.Map<List<ReactionTypeDto>>(reactions));
        }

        /// <summary>
        /// Vraća jedan tip reakcije na osnovu ID-ja tipa reakcije.
        /// </summary>
        /// <param name="reactionTypeId">ID tipa reakcije</param>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="200">Uspešno izlistan tip reakcije sa datim ID-em</response>
        /// <response code="204">Tip reakcije ne postoji</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za izlistavanje tipa reakcije sa datim ID-em
        /// GET 'http://localhost:44200/api/reactionTypes/reactionTypeId' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization'
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json", "application/xml")]
        [HttpGet("{reactionTypeId}")]
        public ActionResult<ReactionTypeDto> GetReactionType([FromRoute] Guid reactionTypeId, [FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            var reactionType = reactionTypeRepository.GetReactionTypeById(reactionTypeId);
            if (reactionType == null)
            {
                return NoContent();
            }
            logger.LogInformation("Successfully listed reaction type with the exact ID");
            return Ok(mapper.Map<ReactionTypeDto>(reactionType));
        }

        /// <summary>
        /// Kreira nov tip reakcije.
        /// </summary>
        /// <param name="reactionType">Model tipa reakcije</param>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="201">Uspešno kreiran novi tip reakcije</response>
        /// <response code="400">Pogrešno uneti podaci</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za kreiranje novog tipa reakcije \
        /// POST 'http://localhost:44200/api/reactionTypes/' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization'
        /// {   \
        ///     "reactionTypeName": "New reaction", \
        ///     "reactionTypeImage": "newReaction.img" \
        /// }
        /// </remarks>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json", "application/xml")]
        [HttpPost]
        public ActionResult<ReactionTypeDto> CreateReactionType([FromBody] ReactionTypeCreateDto reactionType, [FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            try
            {
                var reactionTypeEntity = mapper.Map<ReactionType>(reactionType);

                var reaction = reactionTypeRepository.CreateReactionType(reactionTypeEntity);
                string location = linkGenerator.GetPathByAction("GetReactionType", "ReactionType", new { reactionTypeId = reaction.ReactionTypeID });
                logger.LogInformation("Successfully created reaction type");
                return Created(location, mapper.Map<ReactionTypeDto>(reaction));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when creating reaction type " + ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Create error, not acceptable value");
            }
            
        }

        /// <summary>
        /// Vrši brisanje jednog tipa reakcije na osnovu ID-ja.
        /// </summary>
        /// <param name="reactionTypeId">ID tipa reakcije</param>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="404">Tip reakcije sa datim ID-em ne postoji</response>
        /// <response code="204">Uspešno obrisan tip reakcije</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za brisanje tipa reakcije sa datim ID-em
        /// DELETE 'http://localhost:44200/api/reactionTypes/reactionTypeId' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization'
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{reactionTypeId}")]
        public ActionResult DeleteReactionType(Guid reactionTypeId, [FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            try
            {
                var reaction = reactionTypeRepository.GetReactionTypeById(reactionTypeId);
                if (reaction == null)
                {
                    return NotFound();
                }
                reactionTypeRepository.DeleteReactionType(reactionTypeId);
                logger.LogInformation("Successfully deleted reaction type with the exact ID");
                return NoContent();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error when deleting reaction type " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Ažurira jedan tip reakcije.
        /// </summary>
        /// <param name="reactionType">Model tipa reakcije koji se ažurira</param>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="404">Tip reakcije sa datim ID-em ne postoji</response>
        /// <response code="200">Uspešno ažuriran tip reakcije</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za ažuriranje tipa reakcije \
        /// PUT 'http://localhost:44200/api/reactionTypes/' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization'
        /// {   \
        ///     "reactionTypeID": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///     "reactionTypeName": "New reaction", \
        ///     "reactionTypeImage": "newReaction.img" \
        /// }
        /// </remarks>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json", "application/xml")]
        [HttpPut]
        public ActionResult<ReactionTypeDto> UpdateReactionType ([FromBody] ReactionTypeUpdateDto reactionType, [FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            try
            {
                if(reactionTypeRepository.GetReactionTypeById(reactionType.ReactionTypeID) == null)
                {
                    return NotFound();
                }
                var reactionTypeEntity = mapper.Map<ReactionType>(reactionType);

                var reaction = reactionTypeRepository.UpdateReactionType(reactionTypeEntity);
                logger.LogInformation("Successfully updated reaction type");
                return Ok(mapper.Map<ReactionTypeDto>(reaction));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when updating reaction type " + ex.Message);
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
