using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Distrito
{
    public class CreateDistritoViewModel
    {
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Provincia es requerido")]
        public int ProvinciaId { get; set; }
    }
}
