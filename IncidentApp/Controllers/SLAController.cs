using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SLAController : BaseController<SLA>
    {
        public SLAController(IBaseService<SLA> _baseService) : base(_baseService)
        {
        }
    }
}
