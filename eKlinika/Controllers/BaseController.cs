using eKlinika.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.Controllers
{
    [Route("[controller]")]
    //[Authorize]
    public class BaseController<T, TSearch, TInsert, TUpdate> : ControllerBase where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        private readonly BaseInterface<T, TSearch, TInsert, TUpdate> _service;
        private readonly ILogger<BaseController<T, TSearch, TInsert, TUpdate>> _logger;

        public BaseController(ILogger<BaseController<T, TSearch, TInsert, TUpdate>> logger, BaseInterface<T, TSearch, TInsert, TUpdate> service)
        {
            _logger = logger;
            _service = service;
        }

     

        [HttpGet()]
        public async Task<IEnumerable<T>> Get([FromQuery] TSearch? search = null)
        {
            return await _service.Get(search);
        }


        [HttpGet("{id}")]
        public async Task<T> GetById(int id)
        {
            return await _service.GetById(id);
        }
        [HttpPost()]
        public async Task<T> Insert(TInsert insert)
        {
            return await _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public async Task<T> Update(int id, TUpdate update)
        {

            return await _service.Update(id, update);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteById(id);
            if (success)
            {
                return Ok(); 
            }
            else
            {
                return NotFound(); 
            }
        }


    }
}
