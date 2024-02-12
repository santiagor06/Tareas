using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId{set;get;}
        [Required]
        [MaxLength(150)]
        public string Nombre{set;get;}
        public string Descripcion{set;get;}
        public virtual ICollection<Tarea>Tareas{set;get;}
    }
}