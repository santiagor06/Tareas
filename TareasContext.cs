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

    }
}