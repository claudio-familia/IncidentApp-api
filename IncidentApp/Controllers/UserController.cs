using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto>
    {
        public UserController(IBaseService<User, UserDto> _baseService) : base(_baseService)
        {
        }
    }
}
