using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncidentHistoryController : BaseController<IncidentHistory, IncidentHistoryDto>
    {
        IBaseService<IncidentHistory, IncidentHistoryDto> baseService;
        public IncidentHistoryController(IBaseService<IncidentHistory, IncidentHistoryDto> _baseService) : base(_baseService)
        {
            baseService = _baseService;
        }

        [HttpGet]
        [Route("{id}")]
        public override IActionResult Get(int id)
        {
            IEnumerable<IncidentHistory> incidents = baseService.GetAll().Where(i => i.IncidentId == id).ToList();

            if (incidents.Any())
            {
                IncidentDetailDto response = new IncidentDetailDto();
                response.Histories = new List<IncidentHistoryDetailDto>();

                response.Title = incidents.First().Incident.Title;
                response.Description = incidents.First().Incident.Description;
                response.Priority = incidents.First().Incident.Priority.Name;
                response.CreatedAt = incidents.First().Incident.CreatedAt;
                response.IsClosed = incidents.First().Incident.ClosedDate != null;
                //response.CreatedBy = $"{incidents.First().Incident.Creator.Username}";


                foreach (IncidentHistory item in incidents)
                {
                    response.Histories.Add(new IncidentHistoryDetailDto()
                    {
                        Comment = item.Comment,
                        CreatedAt = item.CreatedAt
                    });
                }

                return Ok(response);
            }

            return NotFound();
        }
    }
}
