using IncidentApp.Controllers.Base.Contracts;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace IncidentApp.Controllers.Base
{    
    public class BaseController<T, Dto> : ControllerBase, IBaseController<T, Dto> where T : class where Dto : class
    {
        private readonly IBaseService<T, Dto> baseService;
        public BaseController(IBaseService<T, Dto> _baseService)
        {
            baseService = _baseService;
        }

        private int _CurrentUserId;
        protected int CurrentUserId
        {
            get
            {
                if (_CurrentUserId == 0)
                {
                    var context = (IHttpContextAccessor)this.HttpContext.RequestServices.GetService(typeof(IHttpContextAccessor));

                    _CurrentUserId = int.Parse(context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                }

                return _CurrentUserId;
            }
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            try
            {
                var response = baseService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public virtual IActionResult Get(int id)
        {
            try
            {
                var response = baseService.Get(id);

                if (response == null) return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }

        [HttpPost]
        public virtual IActionResult Post(Dto entity)
        {
            try
            {
                var response = baseService.Add(entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }

        [HttpPut]
        public virtual IActionResult Put(Dto entity)
        {
            try
            {
                var response = baseService.Update(entity);

                if (response == null) return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual IActionResult Delete(int id)
        {
            try
            {
                var response = baseService.Delete(id);

                if (response == null) return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }
    }
}
