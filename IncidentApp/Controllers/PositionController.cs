using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : BaseController<Position, PositionDto>
    {
        public PositionController(IBaseService<Position, PositionDto> _baseService) : base(_baseService)
        {
        }
    }
}
