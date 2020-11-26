using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Revifast.Entities
{
    public partial class Distrito
    {
        public Distrito()
        {
            Locales = new HashSet<Local>();
        }
        // ID
        public int DistritoId { get; set; }
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // ---------- HAS ONE
        // PROVINCIA
        [Required(ErrorMessage = "Provincia es requerido")]
        public int ProvinciaId { get; set; }
        // ---------- HAS MANY
        // LOCALES
        public virtual ICollection<Local> Locales { get; set; }
    }
}
