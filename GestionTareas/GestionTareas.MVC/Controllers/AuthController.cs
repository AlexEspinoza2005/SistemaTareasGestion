using GestionTareas.API.Models;
using GestionTareas.API.Consumer;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.MVC.Controllers
{
    public class AuthController : Controller
    {
        public AuthController()
        {
            Crud<Usuario>.EndPoint = "https://localhost:7154/api/usuarios";
        }

        // GET: Auth/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string contrasenia)
        {
            try
            {
                var usuarios = Crud<Usuario>.GetAll();
                var usuario = usuarios.FirstOrDefault(u => u.Email == email && u.Contrasenia == contrasenia);

                if (usuario != null)
                {
                    HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
                    HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);
                    HttpContext.Session.SetString("UsuarioEmail", usuario.Email);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email o contraseña incorrectos");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error al intentar iniciar sesión");
            }

            return View();
        }

        public IActionResult Register()
        {
            return RedirectToAction("Create", "Usuarios");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}