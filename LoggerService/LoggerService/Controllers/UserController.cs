using LoggerService.Contracts;
using LoggerService.Dtos;
using LoggerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LoggerService.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveUser([FromBody] SaveUserDto userDto)
        {
            try
            {
                var user = _userService.SaveUser(userDto);
                return Created($"/api/users/{user.Id}", new SuccessResponse<UserDto>
                {
                    Data = user,
                    Status = 201,
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception e)
            {
                var res = e.Message.Equals($"User with id: {userDto.Id} already exists") ?
                BadRequest(new ErrorResponse
                {
                    Message = e.Message,
                    Status = 400,
                    Timestamp = DateTime.Now
                }) :
                StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Message = "Something went wrong. please try again later.",
                        Status = 500,
                        Timestamp = DateTime.Now
                    }
                );
                return res;
            }
        }

        [HttpPut]
        [Route("/api/users/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUser([FromRoute] Guid id, UpdateUserDto userDto)
        {
            try
            {
                return Ok(new SuccessResponse<UserDto>
                {
                    Data = _userService.UpdateUser(id, userDto),
                    Status = 200,
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception e)
            {
                var res = e.Message.Equals($"User with id: {id} doesn't exist") ?
                NotFound(new ErrorResponse
                {
                    Message = e.Message,
                    Status = 404,
                    Timestamp = DateTime.Now
                }) :
                StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Message = "Something went wrong. please try again later.",
                        Status = 500,
                        Timestamp = DateTime.Now
                    }
                );
                return res;
            }
        }
    }
}
