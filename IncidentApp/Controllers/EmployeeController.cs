using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        public EmployeeController(IBaseService<Employee> _baseService) : base(_baseService)
        {
        }
    }
}
