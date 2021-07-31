using ChatService.DTOs.MessageTypeDTOs;
using ChatService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChatService.Controllers
{
    [ApiController]
    [Route("api/message-type")]
    [Authorize]
    public class MessageTypeController : ControllerBase
    {
        private readonly IMessageTypeService _service;

        public MessageTypeController(IMessageTypeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all message types
        /// </summary>
        /// <returns>list of types</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public ActionResult<MessageTypeReadDTO> GetAll()
        {
            var messageTypes = _service.Get();

            if (messageTypes.Count == 0)
                return NoContent();

            return Ok(messageTypes);
        }

        /// <summary>
        /// Get type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>messsage type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public ActionResult<MessageTypeReadDTO> GetById(Guid id)
        {
            var messageType = _service.Get(id);

            if (messageType == null)
                return NotFound();

            return Ok(messageType);
        }

        /// <summary>
        /// Create new message type
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>new type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public ActionResult PostMessageType([FromBody]MessageTypeCreateDTO dto)
        {
            var entity = _service.Create(dto);

            return Ok(entity);
        }

        /// <summary>
        /// Update message type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>updated type</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public ActionResult UpdateMessageType(Guid id, [FromBody]MessageTypeCreateDTO dto)
        {
            var messageType = _service.Update(id, dto);

            return Ok(messageType);
        }

        /// <summary>
        /// Delete message type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete]
        public ActionResult DeleteMessageType(Guid id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
