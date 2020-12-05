using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncidentController : BaseController<Incident, IncidentDto>
    {
        IBaseService<Incident, IncidentDto> _baseService;
        public IncidentController(IBaseService<Incident, IncidentDto> baseService) : base(baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public override IActionResult Get()
        {
            var incidents = _baseService.GetAll();
            var response = new List<IncidentResponseDto>();

            foreach (var item in incidents)
            {
                bool isInProcess = item.AssignedUser != null;
                bool isClosed = item.ClosedDate != null;

                response.Add(new IncidentResponseDto()
                {
                    Id = item.Id,
                    AssignTo = isInProcess ? $"{item.AssignedUser.Employee.Name} {item.AssignedUser.Employee.LastName}" : "No Asignado",
                    IsQueueDone = true,
                    IsProcessDone = isInProcess,
                    Priority = item.Priority.Name,
                    Title = item.Title,
                    IsClosed = isClosed,
                    Description = item.Description
                });
            }

            return Ok(response);
        }
    }
}
