using GestionTareas.API.Models;
using GestionTareas.API.Consumer;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.MVC.Controllers
{
    public class TareasController : Controller
    {
        public TareasController()
        {
            Crud<Tarea>.EndPoint = "https://localhost:7154/api/tareas";
        }

        // GET: Tareas
        public IActionResult Index()
        {
            try
            {
                var tareas = Crud<Tarea>.GetAll();
                return View(tareas);
            }
            catch (Exception ex)
            {
                return View(new List<Tarea>());
            }
        }

        // GET: Tareas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var tarea = Crud<Tarea>.GetById(id.Value);
                if (tarea == null)
                {
                    return NotFound();
                }
                return View(tarea);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Tareas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tareas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Titulo,Descripcion,Estado,Prioridad,ProyectoId,UsuarioId")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Crud<Tarea>.Create(tarea);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Error al crear la tarea");
                }
            }
            return View(tarea);
        }

        // GET: Tareas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var tarea = Crud<Tarea>.GetById(id.Value);
                if (tarea == null)
                {
                    return NotFound();
                }
                return View(tarea);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: Tareas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Titulo,Descripcion,Estado,Prioridad,ProyectoId,UsuarioId")] Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Crud<Tarea>.Update(id, tarea);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Error al actualizar la tarea");
                }
            }
            return View(tarea);
        }

        // GET: Tareas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var tarea = Crud<Tarea>.GetById(id.Value);
                if (tarea == null)
                {
                    return NotFound();
                }
                return View(tarea);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                Crud<Tarea>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return BadRequest("Error al eliminar la tarea");
            }
        }
    }
}