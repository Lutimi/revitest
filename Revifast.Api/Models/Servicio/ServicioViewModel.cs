using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Servicio
{
    public class ServicioViewModel
    {
        public int ServicioId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // DESCRIPCION
        public string Descripcion { get; set; }
        // LOCAL
        public int LocalId { get; set; }
        // CATEGORIA
        public int CategoriaId { get; set; }
        // PROMOCION
        public string Promocion { get; set; }
    }
}
