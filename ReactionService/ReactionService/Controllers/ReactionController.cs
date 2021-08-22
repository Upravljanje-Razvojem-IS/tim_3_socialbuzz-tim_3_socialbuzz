using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using ReactionService.Data;
using ReactionService.Data.BlockingMocks;
using ReactionService.Data.PostMocks;
using ReactionService.Entities;
using ReactionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Controllers
{
    [ApiController]
    [Route("api/reactions")]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionRepository reactionRepository;
        private readonly IPostMockRepository postMockRepository;
        private readonly IBlockingMockRepository blockingMockRepository;
        private readonly IUserMockRepository userMockRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public ReactionController(IReactionRepository reactionRepository, IPostMockRepository postMockRepository, IUserMockRepository userMockRepository,
                                    IBlockingMockRepository blockingMockRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.reactionRepository = reactionRepository;
            this.postMockRepository = postMockRepository;
            this.blockingMockRepository = blockingMockRepository;
            this.userMockRepository = userMockRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve reakcije.
        /// </summary>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="200">Uspešno izlistane sve reakcije</response>
        /// <response code="204">Reakcije ne postoje</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za izlistavanje svih reakcija
        /// GET 'http://localhost:44200/api/reactions/' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization'
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [HttpGet]
        public ActionResult<List<ReactionDto>> GetReactions([FromHeader] string UserKey)
        {
            if ( !userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            var reactions = reactionRepository.GetReactions();
            if (reactions == null || reactions.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<ReactionDto>>(reactions));
        }

        /// <summary>
        /// Vraća jednu reakciju na osnovu ID-ja reakcije.
        /// </summary>
        /// <param name="reactionId">ID reakcije</param>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="200">Uspešno izlistana reakcija sa datim ID-em</response>
        /// <response code="204">Reakcija sa datim ID-em ne postoji</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za izlistavanje jedne reakcije sa datm ID-em
        /// GET 'http://localhost:44200/api/reactions/reactionId' \
        ///     --header 'Authorization: Bearer VerySecretUserKeyForAuthorization'
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json", "application/xml")]
        [HttpGet("{reactionId}")]
        public ActionResult<ReactionDto> GetReaction(Guid reactionId, [FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            var reaction = reactionRepository.GetReactionById(reactionId);
            if (reaction == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<ReactionDto>(reaction));
        }

        /// <summary>
        /// Kreira novu reakciju.
        /// </summary>
        /// <param name="reaction">Model reakcije</param>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="201">Uspešno kreirana reakcija</response>
        /// <response code="422">Pogrešno uneti podaci</response>
        /// <response code = "401" > Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za kreiranje jedne reakcije
        /// POST 'http://localhost:44200/api/reactions/' \
        ///     --header 'Authorization: Bearer VerySecretUserKeyForAuthorization' \
        ///     { \
        ///         "reactionTypeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///         "day": 10, \
        ///         "month": 5, \
        ///         "year": 2010, \
        ///         "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6" \
        ///     }
        /// </remarks>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json", "application/xml")]
        [HttpPost]
        public ActionResult<ReactionDto> CreateReaction([FromBody] ReactionCreateDto reaction, [FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            try
            {
                var reactionEntity = mapper.Map<Reaction>(reaction);

                var r = reactionRepository.CreateReaction(reactionEntity);
                string location = linkGenerator.GetPathByAction("GetReaction", "Reaction", new { reactionId = r.ReactionId });
                return Created(location, mapper.Map<ReactionDto>(r));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Create error, not acceptable value");
            }
        }

        /// <summary>
        /// Vrši brisanje jedne reakcije na osnovu ID-ja.
        /// </summary>
        /// <param name="reactionId">ID reakcije</param>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="404">Reakcija sa datim ID-em ne postoji</response>
        /// <response code="204">Uspešno obrisana reakcija</response>
        /// <response code="500">Greška pri brisanju reakcije</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za brisanje jedne reakcije sa datim ID-em
        /// DELETE 'http://localhost:44200/api/reactions/reactionId' \
        ///     --header 'Authorization: Bearer VerySecretUserKeyForAuthorization'
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{reactionId}")]
        public ActionResult DeleteReaction(Guid reactionId, [FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            try
            {
                var reaction = reactionRepository.GetReactionById(reactionId);
                if (reaction == null)
                {
                    return NotFound();
                }
                reactionRepository.DeleteReaction(reactionId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Ažurira jednu reakciju.
        /// </summary>
        /// <param name="reaction">Model reakcije koja se ažurira</param>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="404">Reakcija sa datim ID-em ne postoji</response>
        /// <response code="200">Uspešno ažurirana reakcija</response>
        /// <response code="500">Greška pri ažuriranju reakcije</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za ažuriranje jedne reakcije sa datim ID-em
        /// PUT 'http://localhost:44200/api/reactions/' \
        ///     --header 'Authorization: Bearer VerySecretUserKeyForAuthorization' \
        /// { \
        /// "reactionId": "d06e3c0a-0291-4dfd-b99f-07d0f6aa4501", \
        /// "reactionTypeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        /// "day": 10, \
        /// "month": 10, \
        /// "year": 2010 \
        /// }
        /// </remarks>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json", "application/xml")]
        [HttpPut]
        public ActionResult<ReactionDto> UpdateReaction(ReactionUpdateDto reaction, [FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            try
            {
                if (reactionRepository.GetReactionById(reaction.ReactionId) == null)
                {
                    return NotFound();
                }
                Reaction reactionEntity = mapper.Map<Reaction>(reaction);

                Reaction r = reactionRepository.UpdateReaction(reactionEntity);
                return Ok(mapper.Map<ReactionDto>(r));
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
