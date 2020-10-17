using IncidentApp.Controllers.Base;
using IncidentApp.Models;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IncidentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeparmentController : BaseController<Department>
    {        
        public DeparmentController(IBaseService<Department> _baseService) : base(_baseService)
        {
        }        
    }
}
