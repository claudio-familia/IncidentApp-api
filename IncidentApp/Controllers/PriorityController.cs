using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : BaseController<Priority>
    {
        public PriorityController(IBaseService<Priority> _baseService) : base(_baseService)
        {
        }
    }
}
