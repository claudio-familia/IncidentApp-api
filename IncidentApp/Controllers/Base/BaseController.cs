using IncidentApp.Controllers.Base.Contracts;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Get a list of current type.
        /// </summary>
        /// <returns>A list of current type</returns>
        /// <response code="200">Returns a list of current type</response>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]        
        public virtual IActionResult Get()
        {
            try
            {
                IEnumerable<T> response = baseService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }

        /// <summary>
        /// Get a instance of the current type.
        /// </summary>        
        /// <returns>A instance of the current type</returns>
        /// <response code="200">Returns a instance of the current type</response>
        /// <response code="404">If the item is not found</response>   
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Create a new instance of the current type.
        /// </summary>        
        /// <returns>A instance just created of the current type</returns>
        /// <response code="201">Returns the instance just created of the current type</response>        
        [HttpPost]
        [ProducesResponseType(201)]        
        public virtual IActionResult Post(Dto entity)
        {
            try
            {
                var response = baseService.Add(entity);
                return Created("", response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500, "Hubo un error inesperado");
            }
        }

        /// <summary>
        /// Update a instance of the current type.
        /// </summary>        
        /// <returns>A instance just updated of the current type</returns>
        /// <response code="200">Returns a instance just updated of the current type</response>
        /// <response code="404">If the item is not found</response>   
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Delete a instance of the current type and returned.
        /// </summary>        
        /// <returns>A instance of the current type</returns>
        /// <response code="200">Returns a instance just deleted of the current type</response>
        /// <response code="404">If the item is not found</response>   
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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
