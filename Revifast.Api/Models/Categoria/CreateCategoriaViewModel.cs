using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Categoria
{
    public class CreateCategoriaViewModel
    {
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(2, ErrorMessage = "Nombre permite 2 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // DESCRIPCION
        [Required(ErrorMessage = "Descripcion es requerido")]
        [StringLength(250, ErrorMessage = "Descripcion permite 250 caracteres")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
    }
}
