using System.Data.Common;
using System.Threading;
using Dapper;
using GestionTareas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace GestionTareas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private DbConnection connection;


        public TareasController(IConfiguration conf)
        {
            var connString = conf.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
            connection.Open();
        }



        // GET: api/<TareasController>
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var tareas = connection.Query<dynamic>("SELECT * FROM Tareas").ToList();
            return tareas;
        }

        // GET api/<TareasController>/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var tareas = connection
                .QuerySingle<dynamic>("SELECT * FROM Tareas WHERE id = @id", new { id });
            return tareas;
        }

        // POST api/<TareasController>
        [HttpPost]
        public IActionResult Post([FromBody] Tarea tareas)
        {
            connection.Execute(
                @"INSERT INTO Tareas (Id, Titulo, Descripcion, Estado, Prioridad, ProyectoId, UsuarioId)" +
                " VALUES (@Id, @Titulo, @Descripcion, @Estado, @Prioridad, @ProyectoId, @UsuarioId)",
                new
                {
                    Id = tareas.Id,
                    Titulo = tareas.Titulo,
                    Descripcion = tareas.Descripcion,
                    Estado = tareas.Estado
                    ,
                    Prioridad = tareas.Prioridad,
                    ProyectoId = tareas.ProyectoId,
                    UsuarioId = tareas.UsuarioId
                });

            return Ok(tareas);
        }


        // PUT api/<TareasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tarea tareas)
        {
            connection.Execute(
                "UPDATE Tareas SET Titulo = @Titulo, Descripcion = @Descripcion, Estado = @Estado, Prioridad = @Prioridad, ProyectoId = @ProyectoId, UsuarioId=@UsuarioId WHERE id = @id",
                new { tareas.Titulo, tareas.Descripcion, tareas.Estado, tareas.Prioridad, tareas.ProyectoId, tareas.UsuarioId, id });
        }

        // DELETE api/<TareasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("DELETE FROM Tareas WHERE id = @id", new { id });
        }
    }
}
