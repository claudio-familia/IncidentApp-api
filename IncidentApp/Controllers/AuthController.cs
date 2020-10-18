using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserDto user)
        {
            return authService.Login(user.Username, user.Password);
        }
    }
}
