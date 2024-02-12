using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Tarea
    {
        public Guid TareaId{set;get;}
        public Guid CategoriaId{set;get;}
        public string Titulo{set;get;}
        public string Descripcion{set;get;}
        public Prioridad Prioridad{set;get;}
        public DateTime Fecha{set;get;}
        public virtual Categoria Categoria{set;get;}
    }

    public enum Prioridad{
        Alta,
        Media,
        Baja

    }
}