using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionTareas.API.Models;

    public class GestionTareasDbContext : DbContext
    {
        public GestionTareasDbContext (DbContextOptions<GestionTareasDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestionTareas.API.Models.Proyecto> Proyectos { get; set; } = default!;

public DbSet<GestionTareas.API.Models.Tarea> Tareas { get; set; } = default!;

public DbSet<GestionTareas.API.Models.Usuario> Usuarios { get; set; } = default!;
    }
