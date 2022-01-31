using BlockService.Entities;
using BlockService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="principal"></param>
        /// <returns>token</returns>
        [HttpPost]
        public ActionResult Login([FromBody] Principal principal)
        {
            string token = _authService.Login(principal);

            return Ok(new { Token = token });
        }

    }
}
