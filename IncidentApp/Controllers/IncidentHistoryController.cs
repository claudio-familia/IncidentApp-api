using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentHistoryController : BaseController<IncidentHistory>
    {
        public IncidentHistoryController(IBaseService<IncidentHistory> _baseService) : base(_baseService)
        {
        }
    }
}
