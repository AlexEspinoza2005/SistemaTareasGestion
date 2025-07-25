using System.Data.Common;
using Dapper;
using GestionTareas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace GestionTareas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private DbConnection connection;
        public UsuariosController(IConfiguration conf)
        {
            var connString = conf.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
            connection.Open();
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var usuarios = connection.Query<dynamic>("SELECT * FROM Usuarios").ToList();
            return usuarios;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var usuarios = connection
                .QuerySingle<dynamic>("SELECT * FROM Usuarios WHERE id = @id", new { id });
            return usuarios;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            connection.Execute(
                @"INSERT INTO Usuarios (Id, Nombre, Email, Contrasenia)" +
                " VALUES (@Id, @Nombre, @Email, @Contrasenia)",
                new
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    Contrasenia = usuario.Contrasenia
                });

            return Ok(usuario); 
        }


        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario usuario)
        {
            connection.Execute(
                "UPDATE Usuarios SET Nombre = @Nombre, Email = @Email, Contrasenia = @Contrasenia WHERE id = @id",
                new { usuario.Nombre, usuario.Email, usuario.Contrasenia, id });
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("DELETE FROM Usuarios WHERE id = @id", new { id });
        }
    }
}
