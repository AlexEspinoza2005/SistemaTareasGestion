using GestionTareas.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestionTareas.MVC.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7154/api/proyectos";

        public ProyectosController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Proyectos
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Proyecto>>(_apiBaseUrl);
            return View(response);
        }

        // GET: Proyectos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Proyecto>($"{_apiBaseUrl}/{id}");
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Proyectos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proyectos/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync(_apiBaseUrl, proyecto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(proyecto);
        }

        // GET: Proyectos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Proyecto>($"{_apiBaseUrl}/{id}");
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // POST: Proyectos/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] Proyecto proyecto)
        {
            if (id != proyecto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/{id}", proyecto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(proyecto);
        }

        // GET: Proyectos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Proyecto>($"{_apiBaseUrl}/{id}");
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }
    }
}
