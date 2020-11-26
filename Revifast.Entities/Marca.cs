using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Entities
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
        }
        // ID
        public int MarcaId { get; set; }
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        // ---------- HAS MANY
        // MODELO
        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
