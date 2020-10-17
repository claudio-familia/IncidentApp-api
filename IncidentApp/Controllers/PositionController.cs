using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : BaseController<Position>
    {
        public PositionController(IBaseService<Position> _baseService) : base(_baseService)
        {
        }
    }
}
