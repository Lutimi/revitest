using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Entities
{
    public partial class Promocion
    {
        public Promocion()
        {
        }
        // ID
        public int PromocionId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // DESCUENTO
        public decimal Descuento { get; set; }
        // DESCRIPCION
        public string Descripcion { get; set; }
        // ---------- HAS ONE
        // ---------- HAS MANY
        // SERVICIOS
        [Required(ErrorMessage = "El Servicio es requerido")]
        public int ServicioId { get; set; }
        public virtual Servicio Servicio { get; set; } 
    }
}
