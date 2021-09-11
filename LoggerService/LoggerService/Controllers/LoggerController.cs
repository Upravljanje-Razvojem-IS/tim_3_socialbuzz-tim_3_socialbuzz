using LoggerService.Contracts;
using LoggerService.Dtos;
using LoggerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LoggerService.Controllers
{
    [Route("api/logs")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILogService _logService;

        public LoggerController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetLogs([FromQuery] LogParamsDto logParams)
        {
            try
            {
                return Ok(new SuccessResponse<IList<LogDto>>
                {
                    Data = _logService.GetLogs(logParams),
                    Status = 200,
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Message = "Something went wrong. please try again later.",
                        Status = 500,
                        Timestamp = DateTime.Now
                    });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveLog([FromBody] SaveLogDto logDto)
        {
            try
            {
                var res = _logService.SaveLog(logDto);

                return Created($"api/logs/{res.Id}", new SuccessResponse<LogDto>
                {
                    Data = res,
                    Status = 201,
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception e)
            {
                var res = e.Message.Equals($"User with id {logDto.UserId} doesn't exist") ?
                 NotFound(new ErrorResponse
                 {
                     Message = e.Message,
                     Timestamp = DateTime.Now,
                     Status = 404
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
