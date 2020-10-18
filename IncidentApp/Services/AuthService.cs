using IncidentApp.Models;
using IncidentApp.Repository.Base.Contracts;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IncidentApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepository<User> baseRepository;
        private readonly IConfiguration configuration;
        public AuthService(IBaseRepository<User> _baseRepository, IConfiguration _configuration)
        {
            baseRepository = _baseRepository;
            configuration = _configuration;
        }

        public IActionResult Login(string username, string password)
        {
            throw new NotImplementedException();
        }


        private SecurityToken GenerateTokenForUser(int UserId)
        {            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }
    }
}
