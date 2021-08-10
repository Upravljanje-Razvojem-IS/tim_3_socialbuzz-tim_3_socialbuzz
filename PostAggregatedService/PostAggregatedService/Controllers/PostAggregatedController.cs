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
        /// <returns></returns>
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
        [HttpPost]
        public ActionResult<PostAggregatedDto> CreatePostAggregated([FromBody] PostAggregatedCreateDto PostAggregated)
        {
            var PostAggregatedEntity = mapper.Map<PostAggregated>(PostAggregated);

            var p = postAggregatedRepository.CreatePostAggregated(PostAggregatedEntity);
            string location = linkGenerator.GetPathByAction("GetPostAggregated", "PostAggregated", new { postAggregatedId = p.PostAggregatedId });
            return Created(location, mapper.Map<PostAggregatedDto>(p));
        }

        /// <summary>
        /// Vrši brisanje agregiranih podataka na osnovu ID-ja.
        /// </summary>
        /// <param name="postAggregatedId">ID agregiranih podataka</param>
        /// <returns>Status 204 (NoContent)</returns>
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
        [HttpPut]
        public ActionResult<PostAggregatedDto> UpdatePostAggregated(PostAggregatedUpdateDto PostAggregated)
        {
            try
            {
                if (GetPostAggregated(PostAggregated.PostAggregatedId) == null)
                {
                    return NotFound();
                }
                var PostAggregatedEntity = mapper.Map<PostAggregated>(PostAggregated);

                var p = postAggregatedRepository.UpdatePostAggregated(PostAggregatedEntity);
                return Ok(mapper.Map<PostAggregatedDto>(p));
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
