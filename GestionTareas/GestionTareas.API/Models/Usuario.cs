﻿namespace GestionTareas.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public List<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
