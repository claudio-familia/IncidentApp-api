using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Get a instance of the current type.
        /// </summary>        
        /// <returns>A instance of the current type</returns>
        /// <response code="200">Returns a instance of the current type</response>
        /// <response code="404">If the item is not found</response>
        [HttpGet]
        public override IActionResult Get()
        {
            IEnumerable<Incident> incidents = _baseService.GetAll();

            List<IncidentResponseDto> response = new List<IncidentResponseDto>();

            foreach (Incident item in incidents)
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

        [HttpGet]
        [Route("history")]
        public IActionResult GetHistory()
        {
            IEnumerable<Incident> incidentHistories = _baseService.GetAll().Where(x => x.ClosedDate != null);

            List<IncidentHistoryResponseDto> response = new List<IncidentHistoryResponseDto>();

            foreach (Incident item in incidentHistories)
            {
                TimeSpan timeToClose = item.ClosedDate.Value.Subtract(item.CreatedAt);

                string timeToCloseToShow = timeToClose.Days > 0 ? $"{timeToClose.Days} dias " : "";
                timeToCloseToShow += timeToClose.Hours > 0 ? $"{timeToClose.Hours} horas " : "";
                timeToCloseToShow += timeToClose.Minutes > 0 ? $"{timeToClose.Minutes} minutos " : "";
                timeToCloseToShow += timeToClose.Seconds > 0 ? $"{timeToClose.Seconds} segundos " : "";

                response.Add(new IncidentHistoryResponseDto()
                {
                    Id = item.Id,
                    Incident = $"{item.Title}",
                    Priority = $"{item.Priority.Name}",
                    CreatedAt = item.CreatedAt,
                    ClosedAt = item.ClosedDate.Value,
                    Responsable = $"{item.AssignedUser.Employee.Name} {item.AssignedUser.Employee.LastName}",
                    TimeToClose = timeToCloseToShow
                });
            }

            return Ok(response);
        }
    }
}
