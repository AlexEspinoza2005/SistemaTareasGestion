using Microsoft.AspNetCore.Mvc;


namespace GestionTareas.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        // GET: api/<ProyectosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProyectosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProyectosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProyectosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProyectosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
