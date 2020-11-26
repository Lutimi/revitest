using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Local
{
    public class CreateLocalViewModel
    {
        // DIRECCION
        [Required(ErrorMessage = "Direccion es requerida")]
        [StringLength(250, ErrorMessage = "Direccion permite hasta 250 caracteres")]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }
        // HORARIO
        [Required(ErrorMessage = "Horario es requerida")]
        public int HorarioId { get; set; }
        // EMPRESA
        [Required(ErrorMessage = "Empresa es requerida")]
        public int EmpresaId { get; set; }
        // DISTRITO
        [Required(ErrorMessage = "Distrito es requerida")]
        public int DistritoId { get; set; }
    }
}
