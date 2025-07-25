using Microsoft.AspNetCore.Mvc;


namespace GestionTareas.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        // GET: api/<TareasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TareasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TareasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TareasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TareasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
