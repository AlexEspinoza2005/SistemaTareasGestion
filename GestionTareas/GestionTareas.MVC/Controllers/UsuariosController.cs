using GestionTareas.API.Models;
using GestionTareas.API.Consumer;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        public UsuariosController()
        {
            Crud<Usuario>.EndPoint = "https://localhost:7154/api/Usuarios";
        }

        // GET: Usuarios
        public IActionResult Index()
        {
            try
            {
                var usuarios = Crud<Usuario>.GetAll();
                return View(usuarios);
            }
            catch (Exception ex)
            {
                return View(new List<Usuario>());
            }
        }

        // GET: Usuarios/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var usuario = Crud<Usuario>.GetById(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nombre,Email,Contrasenia")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Crud<Usuario>.Create(usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Error al crear el usuario");
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(int id)
        {
            try
            {
                var usuario = Crud<Usuario>.GetById(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nombre,Email,Contrasenia")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Crud<Usuario>.Update(id, usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Error al actualizar el usuario");
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                var usuario = Crud<Usuario>.GetById(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                Crud<Usuario>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return BadRequest("Error al eliminar el usuario");
            }
        }


        public IActionResult Perfil()
        {
            try
            {
                var usuarioId = HttpContext.Session.GetString("UsuarioId");
                if (string.IsNullOrEmpty(usuarioId))
                {
                    return RedirectToAction("Index", "Auth");
                }

                var usuario = Crud<Usuario>.GetById(int.Parse(usuarioId));
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}