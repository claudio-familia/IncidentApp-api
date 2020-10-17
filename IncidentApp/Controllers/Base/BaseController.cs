using IncidentApp.Controllers.Base.Contracts;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IncidentApp.Controllers.Base
{
    public class BaseController<T> : ControllerBase, IBaseController<T> where T : class
    {
        private readonly IBaseService<T> baseService;
        public BaseController(IBaseService<T> _baseService)
        {
            baseService = _baseService;
        }        

        [HttpGet]
        public IActionResult Get()
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
        public IActionResult Get(int id)
        {
            try
            {
                var response = baseService.Get(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }

        [HttpPost]
        public IActionResult Post(T entity)
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
        public IActionResult Put(T entity)
        {
            try
            {
                var response = baseService.Update(entity);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var response = baseService.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }
    }
}
