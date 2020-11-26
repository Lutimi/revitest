using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Revifast.Entities
{
    public partial class Empresa
    {
        public Empresa()
        {
            Locales = new HashSet<Local>();
        }
        // ID
        public int EmpresaId { get; set; }
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
        // ---------- HAS ONE
        // ---------- HAS MANY
        // LOCALES
        public virtual ICollection<Local> Locales { get; set; }
    }
}
