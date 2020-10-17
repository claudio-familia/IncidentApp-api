using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        public UserController(IBaseService<User> _baseService) : base(_baseService)
        {
        }
    }
}
