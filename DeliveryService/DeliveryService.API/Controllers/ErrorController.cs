﻿using DeliveryService.API.CustomException;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.API.Controllers
{
    [ApiController]

    /*Ovo je potrebno nakon dodavanja UseExceptionHandler
    kako bi swagger radio kako treba.
    U suprotnom bi bacao gresku.*/
    [ApiExplorerSettings(IgnoreApi = true)] 
    public class ErrorController : ControllerBase
    {
        [Route("/error-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error as DeliveryException;

            string stackTrace = context.Error.StackTrace;
            string message = context.Error.Message;

            if(exception is DeliveryException)
            {
                return Problem(
                detail: stackTrace,
                statusCode: exception.StatusCode,
                title: message);
            }

            return Problem(
                detail: stackTrace,
                title: message);

        }

        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = context.Error as DeliveryException;

            if (exception is DeliveryException)
            {
                return Problem(
                statusCode: exception.StatusCode,
                title: exception.Message);
            }

            return Problem(
                title: context.Error.Message,
                statusCode: 500);
        }
    }

}
