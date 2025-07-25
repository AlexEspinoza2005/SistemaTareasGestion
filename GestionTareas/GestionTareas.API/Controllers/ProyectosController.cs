using System.Data.Common;
using Dapper;
using GestionTareas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GestionTareas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private DbConnection connection;
        public ProyectosController(IConfiguration conf)
        {
            var connString = conf.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
            connection.Open();
        }
        // GET: api/<ProyectosController>
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var proyectos = connection.Query<dynamic>("SELECT * FROM Proyectos").ToList();
            return proyectos;
        }

        // GET api/<ProyectosController>/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var proyectos = connection
                .QuerySingle<dynamic>("SELECT * FROM Proyectos WHERE id = @id", new { id });
            return proyectos;
        }

        // POST api/<ProyectosController>
        [HttpPost]
        public IActionResult Post([FromBody] Proyecto proyectos)
        {
            connection.Execute(
                @"INSERT INTO Proyectos (Id, Nombre, Descripcion)" +
                " VALUES (@Id, @Nombre, @Descripcion)",
                new
                {
                    Id = proyectos.Id,
                    Nombre = proyectos.Nombre,
                    Descripcion = proyectos.Descripcion
                   
                });

            return Ok(proyectos);
        }

        // PUT api/<ProyectosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Proyecto proyectos)
        {
            connection.Execute(
                "UPDATE Proyectos SET Nombre = @Nombre, Descripcion = @Descripcion WHERE id = @id",
                new { proyectos.Nombre, proyectos.Descripcion, id });
        }

        // DELETE api/<ProyectosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("DELETE FROM Proyectos WHERE id = @id", new { id });
        }
    }
}
