using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public class TareasContext:DbContext
    {
        public DbSet<Categoria>Categorias{set;get;}
        public DbSet<Tarea>Tareas{set;get;}

        public TareasContext(DbContextOptions<TareasContext>options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(categoria=>{
                categoria.ToTable("Categoria");
                categoria.HasKey(p=>p.CategoriaId);
                categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p=>p.Descripcion);
            });
            modelBuilder.Entity<Tarea>(tarea=>{
                tarea.ToTable("Tarea");
                tarea.HasKey(p=>p.TareaId);
                tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId);
                tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(250);
                tarea.Property(p=>p.Descripcion);
                tarea.Property(p=>p.Prioridad);
                tarea.Property(p=>p.Fecha);
                tarea.Ignore(p=>p.Resumen);
            });
        }

    }
}