using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : BaseController<Priority, PriorityDto>
    {
        public PriorityController(IBaseService<Priority, PriorityDto> _baseService) : base(_baseService)
        {
        }
    }
}
