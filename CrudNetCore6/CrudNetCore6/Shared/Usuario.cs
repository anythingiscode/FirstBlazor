using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudNetCore6.Shared
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage= "* Obligatorio")]       // Esto enlaza con nuestro formulario de Nuevo usuario --> msgs de validacion - Necesita el "using System.ComponentModel.DataAnnotations;"
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "* Obligatorio")]
        public string Apellido { get; set; } = null!;
        [Required(ErrorMessage = "* Obligatorio")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "* Obligatorio")]
        public string Telefono { get; set; } = null!;
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
