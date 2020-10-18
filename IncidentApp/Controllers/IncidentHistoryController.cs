using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentHistoryController : BaseController<IncidentHistory, IncidentHistoryDto>
    {
        public IncidentHistoryController(IBaseService<IncidentHistory, IncidentHistoryDto> _baseService) : base(_baseService)
        {
        }
    }
}
