using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Promocion
{
    public class CreatePromocionViewModel
    {
        // NOMBRE
        public string Nombre { get; set; }
        // DESCUENTO
        public decimal Descuento { get; set; }
        // DESCRIPCION
        public string Descripcion { get; set; }
        public int ServicioId { get; set; }
    }
}
