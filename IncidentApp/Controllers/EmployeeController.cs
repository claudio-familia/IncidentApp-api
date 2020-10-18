using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, EmployeeDto>
    {
        public EmployeeController(IBaseService<Employee, EmployeeDto> _baseService) : base(_baseService)
        {
        }
    }
}
