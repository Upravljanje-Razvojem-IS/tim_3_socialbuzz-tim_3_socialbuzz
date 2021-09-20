using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using UserWatchingService.Entities;
using UserWatchingService.Interfaces;
using WatchingService.CustomException;
using WatchingService.Data;

namespace UserWatchingService.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config, DatabaseContext context)
        {
            _config = config;
            _context = context;
        }

        public string Login(Principal principal)
        {
            var user = _context.Users.FirstOrDefault(e => e.Username == principal.Username && e.Password == principal.Password);

            if (user == null)
                throw new BusinessException("User does not exist");

            return this.GenerateJwt("user");
        }

        public string GenerateJwt(string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                             _config["Jwt:Issuer"],
                                             new[] { new Claim("role", role) },
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
