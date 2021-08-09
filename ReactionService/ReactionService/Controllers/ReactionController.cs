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
    [Route("api/reactions")]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionRepository reactionRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public ReactionController(IReactionRepository reactionRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.reactionRepository = reactionRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve reakcije.
        /// </summary>
        /// <returns>Lista reackija</returns>
        [HttpGet]
        public ActionResult<List<ReactionDto>> GetReactions()
        {
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
        /// <returns></returns>
        [HttpGet("{reactionId}")]
        public ActionResult<ReactionDto> GetReaction(Guid reactionId)
        {
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
        /// <returns>Kreiranu reakciju iz liste.</returns>
        [HttpPost]
        public ActionResult<ReactionDto> CreateReaction([FromBody] ReactionCreateDto reaction)
        {
            var reactionEntity = mapper.Map<Reaction>(reaction);

            var r = reactionRepository.CreateReaction(reactionEntity);
            string location = linkGenerator.GetPathByAction("GetReaction", "Reaction", new { reactionId = r.ReactionId });
            return Created(location, mapper.Map<ReactionDto>(r));
        }

        /// <summary>
        /// Vrši brisanje jedne reakcije na osnovu ID-ja.
        /// </summary>
        /// <param name="reactionId">ID reakcije</param>
        /// <returns>Status 204 (NoContent)</returns>
        [HttpDelete("{reactionId}")]
        public ActionResult DeleteReaction(Guid reactionId)
        {
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
        /// <returns>Ažuriranu reakciju iz liste.</returns>
        [HttpPut]
        public ActionResult<ReactionDto> UpdateReaction(ReactionUpdateDto reaction)
        {
            try
            {
                if (GetReaction(reaction.ReactionId) == null)
                {
                    return NotFound();
                }
                var reactionEntity = mapper.Map<Reaction>(reaction);

                var r = reactionRepository.UpdateReaction(reactionEntity);
                return Ok(mapper.Map<ReactionDto>(r));
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
