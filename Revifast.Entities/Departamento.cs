using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Revifast.Entities
{
    public partial class Departamento
    {
        public Departamento()
        {
        }
        // ID
        public int DepartamentoId { get; set; }
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // ---------- HAS ONE
        // ---------- HAS MANY
    }
}
