﻿namespace GestionTareas.API.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
