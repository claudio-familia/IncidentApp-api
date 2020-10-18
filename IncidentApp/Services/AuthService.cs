using IncidentApp.Models;
using IncidentApp.Repository.Base.Contracts;
using IncidentApp.Services.Contracts;
using IncidentApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
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

                    if (user != null)
                    {
                        return new OkObjectResult(new { user.Username, token = GenerateJWT(user) });
                    }

                    return new UnauthorizedObjectResult("Invalid Password");
                }

                return new NotFoundObjectResult("Invalid User");
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        private string GenerateJWT(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.Username.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddMinutes(60);

            var token = new JwtSecurityToken(
                issuer: configuration["Authentication:Issuer"],
                audience: configuration["Authentication:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
