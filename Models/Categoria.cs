using System;

using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Categoria
    {
        public Guid CategoriaId{set;get;}
        public string Nombre{set;get;}
        public string Descripcion{set;get;}
        public virtual ICollection<Tarea>Tareas{set;get;}
    }
}