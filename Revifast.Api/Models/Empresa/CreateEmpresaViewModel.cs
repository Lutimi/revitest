using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Empresa
{
    public class CreateEmpresaViewModel
    {
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // RUC
        [Required(ErrorMessage = "RUC es requerido")]
        [StringLength(20, ErrorMessage = "RUC permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Ruc { get; set; }
        // TELEFONO
        [StringLength(10, ErrorMessage = "Celular permite 10 caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Telefono { get; set; }
        // CORREO
        [StringLength(50, ErrorMessage = "Correo permite 50 caracteres")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Correo { get; set; }
    }
}
