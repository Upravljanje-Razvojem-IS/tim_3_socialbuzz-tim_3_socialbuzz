﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PriceService.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] 
    public class ErrorController : ControllerBase
    {
        [Route("/error-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            string stackTrace = context.Error.StackTrace;
            string message = context.Error.Message;

            return Problem(
                detail: stackTrace,
                title: message);

        }

        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = context.Error;

            return Problem(
                title: context.Error.Message,
                statusCode: 500);
        }
    }
}
