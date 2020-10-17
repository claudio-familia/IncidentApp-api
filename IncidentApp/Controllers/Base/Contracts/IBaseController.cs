using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers.Base.Contracts
{
    public interface IBaseController<T>
    {
        public IActionResult Get();

        public IActionResult Get(int id);

        public IActionResult Post(T entity);

        public IActionResult Put(T entity);

        public IActionResult Delete(int id);
    }
}
