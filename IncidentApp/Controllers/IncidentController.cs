using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : BaseController<Incident>
    {
        public IncidentController(IBaseService<Incident> _baseService) : base(_baseService)
        {
        }
    }
}
