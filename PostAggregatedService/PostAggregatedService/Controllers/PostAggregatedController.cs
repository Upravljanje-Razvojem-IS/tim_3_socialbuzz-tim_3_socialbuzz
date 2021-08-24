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
using PostAggregatedService.Data.UserMocks;
using PostAggregatedService.Data.PostMocks;

namespace PostAggregatedService.Controllers
{
    [ApiController]
    [Route("api/postAggregatedDetails")]
    public class PostAggregatedController : ControllerBase
    {
        private readonly IPostAggregatedRepository postAggregatedRepository;
        private readonly IUserMockRepository userMockRepository;
        private readonly IPostMockRepository postMockRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public PostAggregatedController(IPostAggregatedRepository postAggregatedRepository, IUserMockRepository userMockRepository,
                                            IPostMockRepository postMockRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.postAggregatedRepository = postAggregatedRepository;
            this.userMockRepository = userMockRepository;
            this.postMockRepository = postMockRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća sve agregirane podatke.
        /// </summary>
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <returns>Lista agregiranih podataka</returns>
        /// <response code="200">Uspešno izlistani svi agregirani podaci</response>
        /// <response code="204">Agregirani podaci ne postoje</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <response code="404">Oglas ne postoji</response>
        /// <remarks>
        /// Primer zahteva za izlistavanje svih agregiranih podataka \
        /// GET 'http://localhost:44100/api/postAggregatedDetails/' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization'
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpGet]
        public ActionResult<List<PostAggregatedDto>> GetPostAggregatedDetails([FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            if (postMockRepository.GetPostById() == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Post does not exists.");
            }
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
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="200">Uspešno izlistani agregirani podaci</response>
        /// <response code="204">Agregirani podaci sa datim ID-em ne postoje</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <response code="404">Oglas ne postoji</response>
        /// <remarks>
        /// Primer zahteva za izlistavanje agregiranih podataka sa datim ID-em \
        /// GET 'http://localhost:44100/api/postAggregatedDetails/postAggregatedId' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization'
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json", "application/xml")]
        [HttpGet("{postAggregatedId}")]
        public ActionResult<PostAggregatedDto> GetPostAggregated(Guid postAggregatedId, [FromHeader] string UserKey)
        {
            if (!userMockRepository.AuthorizeUser(UserKey))
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
            }
            if (postMockRepository.GetPostById() == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Post does not exists.");
            }
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
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <returns>Kreiranu reakciju iz liste.</returns>
        /// <response code="406">Vrednost određenih atributa nije dozvoljen.</response>
        /// <response code="201">Uspešno kreirani agregirani podaci</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <response code="404">Oglas ne postoji</response>
        /// <remarks>
        /// Primer zahteva za kreiranje agregiranih podataka \
        /// POST 'http://localhost:44100/api/postAggregatedDetails/' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization' \
        /// { \
        /// "postId": "71a1d81c-7fea-4e9a-bb29-541e165fc198" \
        /// }
        /// </remarks>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json", "application/xml")]
        [HttpPost]
        public ActionResult<PostAggregatedDto> CreatePostAggregated([FromBody] PostAggregatedCreateDto PostAggregated, [FromHeader] string UserKey)
        {
            try
            {
                if (!userMockRepository.AuthorizeUser(UserKey))
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
                }

                if (postMockRepository.GetPostById() == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Post does not exists.");
                }

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
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <response code="404">Nisu pronađeni agregirani podaci sa tim ID-em</response>
        /// <response code="204">Uspešno obrisani agregirani podaci</response>
        /// <response code="500">Greška pri brisanju agregiranih podataka</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za brisanje agregiranih podataka \
        /// DELETE 'http://localhost:44100/api/postAggregatedDetails/postAggregatedId' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization'
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{postAggregatedId}")]
        public ActionResult DeletePostAggregated(Guid postAggregatedId, [FromHeader] string UserKey)
        {
            try
            {
                if (!userMockRepository.AuthorizeUser(UserKey))
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
                }

                if (postMockRepository.GetPostById() == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Post does not exists.");
                }

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
        /// <param name="UserKey">Bearer token za autorizaciju</param>
        /// <returns>Ažurirane agregirane podatke iz liste.</returns>
        /// <response code="200">Uspešno ažurirani agregirani podaci</response>
        /// <response code="404">Agregirani podaci sa datim ID-em ne postoje</response>
        /// <response code="500">Greška pri ažuriranju agegiranih podataka</response>
        /// <response code="401">Autorizacija je neuspešna</response>
        /// <remarks>
        /// Primer zahteva za ažuriranje novih agregiranih podataka \
        /// PUT 'http://localhost:44100/api/postAggregatedDetails/' \
        ///     --header 'Authorization: VerySecretUserKeyForAuthorization' \
        /// {   \
        ///     "postAggregatedId": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///     "postId": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///      "numberOfVisits": 10, \
        ///      "numberOfComments": 5, \
        ///      "numberOfLikes": 4, \
        ///      "numberOfDislikes": 100, \
        ///      "numberOfSmileys": 7, \
        ///      "numberOfHearts": 6 \
        /// }
        /// </remarks>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json", "application/xml")]
        [HttpPut]
        public ActionResult<PostAggregatedDto> UpdatePostAggregated(PostAggregatedUpdateDto PostAggregated, [FromHeader] string UserKey)
        {
            try
            {
                if (!userMockRepository.AuthorizeUser(UserKey))
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "User is not authorized for this action.");
                }
                if (postMockRepository.GetPostById() == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Post does not exists.");
                }
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
