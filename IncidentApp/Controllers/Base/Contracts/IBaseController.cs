using Microsoft.AspNetCore.Mvc;

namespace IncidentApp.Controllers.Base.Contracts
{
    public interface IBaseController<T, Dto>
    {
        public IActionResult Get();

        public IActionResult Get(int id);

        public IActionResult Post(Dto entity);

        public IActionResult Put(Dto entity);

        public IActionResult Delete(int id);
    }
}
