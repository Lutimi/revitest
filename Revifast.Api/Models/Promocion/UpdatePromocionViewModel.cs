using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Promocion
{
    public class UpdatePromocionViewModel
    {
        // ID
        public int PromocionId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // DESCUENTO
        public decimal Descuento { get; set; }
        // DESCRIPCION
        public string Descripcion { get; set; }
        public int ServicioId { get; set; }
    }
}
