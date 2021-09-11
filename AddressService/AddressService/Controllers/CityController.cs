﻿using AddressService.Contracts;
using AddressService.Dtos.City;
using AddressService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AddressService.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCities()
        {
            return Ok(new SuccessResponse<IList<CityDto>>
            {
                Data = _cityService.GetCities(),
                Status = 200,
                Timestamp = DateTime.Now
            });
        }

        [HttpGet]
        [Route("/api/cities/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCity([FromRoute] Guid id)
        {
            try
            {
                return Ok(new SuccessResponse<CityDto>
                {
                    Data = _cityService.GetById(id),
                    Status = 200,
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception e)
            {
                var res = e.Message.Equals($"City with id: {id} doesnt't exist") ?
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
                        Message = "Something went wrong, please try again later.",
                        Status = 500,
                        Timestamp = DateTime.Now
                    }
                );

                return res;
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveCity(SaveCityDto cityDto)
        {
            try
            {
                var res = _cityService.SaveCity(cityDto);
                return Created($"api/cities/{res.Id}", new SuccessResponse<CityDto>
                {
                    Data = res,
                    Status = 201,
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception e)
            {
                var res = e.Message.Equals($"Country with id: {cityDto.CountryId} doesn't exist") ?
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
                        Message = "Something went wrong, please try again later.",
                        Status = 500,
                        Timestamp = DateTime.Now
                    }
                );

                return res;
            }
        }

        [HttpPut]
        [Route("api/cities/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCity([FromRoute] Guid id, UpdateCityDto cityDto)
        {
            try
            {
                return Ok(new SuccessResponse<CityDto>
                {
                    Data = _cityService.UpdateCity(id, cityDto),
                    Status = 200,
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                var res = e.Message.Equals($"Country with id: {cityDto.CountryId} doesn't exist") ||
                    e.Message.Equals($"City with id: {id} doenst't exist") ?
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
                        Message = "Something went wrong, please try again later.",
                        Status = 500,
                        Timestamp = DateTime.Now
                    }
                );

                return res;
            }
        }

        [HttpDelete]
        [Route("api/cities/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCity([FromRoute] Guid id)
        {
            try
            {
                _cityService.DeleteCity(id);
                return NoContent();
            }
            catch (Exception e)
            {
                var res = e.Message.Equals($"City with id: {id} doesnt't exist") ?
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
                        Message = "Something went wrong, please try again later.",
                        Status = 500,
                        Timestamp = DateTime.Now
                    }
                );

                return res;
            }
        }

    }
}
