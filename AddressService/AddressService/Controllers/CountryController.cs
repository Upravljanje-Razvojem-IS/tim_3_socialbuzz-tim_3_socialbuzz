using AddressService.Contracts;
using AddressService.Dtos.Country;
using AddressService.Exceptions;
using AddressService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AddressService.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCountries()
        {
            return Ok(new SuccessResponse<IList<CountryDto>>
            {
                Data = _countryService.GetCountries(),
                Status = 200,
                Timestamp = DateTime.Now
            });
        }

        [HttpGet]
        [Route("api/countries/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCountry([FromRoute] Guid id)
        {
            try
            {
                return Ok(new SuccessResponse<CountryDto>
                {
                    Data = _countryService.GetById(id),
                    Status = 200,
                    Timestamp = DateTime.Now
                });
            }
            catch (CountryNotFoundException e)
            {
                return NotFound(new ErrorResponse
                {
                    Message = e.Message,
                    Status = 404,
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Message = "Something went wrong, please try again later.",
                        Status = 500,
                        Timestamp = DateTime.Now
                    }
                );
            }
        }

    }
}
