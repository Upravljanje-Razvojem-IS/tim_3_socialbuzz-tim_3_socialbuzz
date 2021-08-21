using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PostAggregatedService.Data;
using PostAggregatedService.Models;
using PostAggregatedService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PostAggregatedService.Controllers
{
    [ApiController]
    [Route("api/postAggregatedDetails")]
    public class PostAggregatedController : ControllerBase
    {
        private readonly IPostAggregatedRepository postAggregatedRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public PostAggregatedController(IPostAggregatedRepository postAggregatedRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.postAggregatedRepository = postAggregatedRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve agregirane podatke.
        /// </summary>
        /// <returns>Lista agregiranih podataka</returns>
        /// <response code="200">Uspešno izlistani svi agregirani podaci</response>
        /// <response code="204">Agregirani podaci ne postoje</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        [HttpGet]
        public ActionResult<List<PostAggregatedDto>> GetPostAggregatedDetails()
        {
            var PostAggregated = postAggregatedRepository.GetPostAggregatedDetails();
            if (PostAggregated == null || PostAggregated.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<PostAggregatedDto>>(PostAggregated));
        }

        /// <summary>
        /// Vraća agregirane podatke na osnovu ID-ja.
        /// </summary>
        /// <param name="postAggregatedId">ID agregiranih podataka</param>
        /// <response code="200">Uspešno izlistani agregirani podaci</response>
        /// <response code="204">Agregirani podaci sa datim ID-em ne postoje</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json", "application/xml")]
        [HttpGet("{postAggregatedId}")]
        public ActionResult<PostAggregatedDto> GetPostAggregated(Guid postAggregatedId)
        {
            var PostAggregated = postAggregatedRepository.GetPostAggregatedById(postAggregatedId);
            if (PostAggregated == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<PostAggregatedDto>(PostAggregated));
        }

        /// <summary>
        /// Kreira nove agregirane podatke.
        /// </summary>
        /// <param name="PostAggregated">Model agregiranih podataka</param>
        /// <returns>Kreiranu reakciju iz liste.</returns>
        /// <response code="406">Vrednost određenih atributa nije dozvoljen.</response>
        /// <response code="201">Uspešno kreirani agregirani podaci</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [Produces("application/json", "application/xml")]
        [HttpPost]
        public ActionResult<PostAggregatedDto> CreatePostAggregated([FromBody] PostAggregatedCreateDto PostAggregated)
        {
            try
            {
                var PostAggregatedEntity = mapper.Map<PostAggregated>(PostAggregated);

                var p = postAggregatedRepository.CreatePostAggregated(PostAggregatedEntity);
                string location = linkGenerator.GetPathByAction("GetPostAggregated", "PostAggregated", new { postAggregatedId = p.PostAggregatedId });
                return Created(location, mapper.Map<PostAggregatedDto>(p));
            }
            catch (NullReferenceException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error, internal error.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Create error, not acceptable value.");
            }

        }

        /// <summary>
        /// Vrši brisanje agregiranih podataka na osnovu ID-ja.
        /// </summary>
        /// <param name="postAggregatedId">ID agregiranih podataka</param>
        /// <response code="404">Nisu pronađeni agregirani podaci sa tim ID-em</response>
        /// <response code="204">Uspešno obrisani agregirani podaci</response>
        /// <response code="500">Greška pri brisanju agregiranih podataka</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{postAggregatedId}")]
        public ActionResult DeletePostAggregated(Guid postAggregatedId)
        {
            try
            {
                var PostAggregated = postAggregatedRepository.GetPostAggregatedById(postAggregatedId);
                if (PostAggregated == null)
                {
                    return NotFound();
                }
                postAggregatedRepository.DeletePostAggregated(postAggregatedId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Ažurira agregirane podatke.
        /// </summary>
        /// <param name="PostAggregated">Model agregiranih podataka koji se ažuriraju</param>
        /// <returns>Ažurirane agregirane podatke iz liste.</returns>
        /// <response code="200">Uspešno ažurirani agregirani podaci</response>
        /// <response code="404">Agregirani podaci sa datim ID-em ne postoje</response>
        /// <response code="500">Greška pri ažuriranju agegiranih podataka</response>
        /// <remarks>
        /// Primer zahteva za kreiranje novih agregiranih podataka \
        /// PUT /api/PostAggregatedDetails \
        /// {   \
        ///     "postAggregatedId": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///     "postId": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///      "numberOfVisits": 10, \
        ///      "numberOfComments": 5, \
        ///      "numberOfLikes": 4, \
        ///      "numberOfDislikes": 100, \
        ///      "numberOfSmileys": 7, \
        ///      "numberOfHearts": 6 \
        ///      }
        /// </remarks>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", "application/xml")]
        [HttpPut]
        public ActionResult<PostAggregatedDto> UpdatePostAggregated(PostAggregatedUpdateDto PostAggregated)
        {
            try
            {
                if (postAggregatedRepository.GetPostAggregatedById(PostAggregated.PostAggregatedId) == null)
                {
                    return NotFound();
                }
                var PostAggregatedEntity = mapper.Map<PostAggregated>(PostAggregated);

                var p = postAggregatedRepository.UpdatePostAggregated(PostAggregatedEntity);
                return Ok(mapper.Map<PostAggregatedDto>(p));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error, internal error.");
            }
        }

#pragma warning disable CS1591
        [HttpOptions]
        public IActionResult GetReactionOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
#pragma warning restore CS1591
}
