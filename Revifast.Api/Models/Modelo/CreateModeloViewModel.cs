using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Modelo
{
    public class CreateModeloViewModel
    {
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // MARCA
        [Required(ErrorMessage = "Marca es requerido")]
        public int MarcaId { get; set; }
    }
}
