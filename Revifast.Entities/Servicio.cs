using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Revifast.Entities
{
    public partial class Servicio
    {
        public Servicio()
        {
            Promociones = new HashSet<Promocion>();
        }

        // ID
        public int ServicioId { get; set; }
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(50, ErrorMessage = "Nombre permite hasta 50 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // PRECIO

        // DESCRIPCION
        [Required(ErrorMessage = "Descripcion es requerido")]
        [StringLength(250, ErrorMessage = "Descripcion permite 250 caracteres")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
        // ---------- HAS ONE
        // LOCAL
        public int LocalId { get; set; }
        public virtual Local Local { get; set; }
        // CATEGORIA
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        // ---------- HAS MANY
        // PROMOCION
        public virtual ICollection<Promocion> Promociones { get; set; }

    }
}
