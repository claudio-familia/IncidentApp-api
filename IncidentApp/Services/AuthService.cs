using IncidentApp.Models;
using IncidentApp.Repository.Base.Contracts;
using IncidentApp.Services.Contracts;
using IncidentApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IncidentApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepository<User> baseRepository;
        private readonly IConfiguration configuration;
        private readonly CryptographyUtils cryptography;
        public AuthService(IBaseRepository<User> _baseRepository, IConfiguration _configuration)
        {
            baseRepository = _baseRepository;
            configuration = _configuration;
            cryptography = new CryptographyUtils();
        }

        public string Decrypt(string text)
        {
            return cryptography.Decrypt(text, configuration["Authentication:SecretKey"]);
        }

        public string Encrypt(string text)
        {
            return cryptography.Encrypt(text, configuration["Authentication:SecretKey"]);
        }

        public IActionResult Login(string username, string password)
        {
            try
            {
                if (baseRepository.Exists(user => user.Username == username))
                {
                    var passwordEncrypt = Encrypt(password);
                    var user = baseRepository.Find(user => user.Username == username && user.Password == passwordEncrypt).FirstOrDefault();

                    if(user != null)
                    {
                        return new OkObjectResult(new { user, token = GenerateTokenForUser(user.Id) });
                    }

                    return new UnauthorizedObjectResult("Invalid Password");
                }

                return new NotFoundObjectResult("Invalid User");
            }catch(Exception ex)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        private SecurityToken GenerateTokenForUser(int UserId)
        {            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Authentication:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = configuration["Authentication:Issuer"],
                Audience = configuration["Authentication:Audience"],                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }
    }
}
