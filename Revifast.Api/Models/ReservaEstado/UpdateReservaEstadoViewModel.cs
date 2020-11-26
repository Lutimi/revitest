using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.ReservaEstado
{
    public class UpdateReservaEstadoViewModel
    {
        // ID
        public int ReservaEstadoId { get; set; }
        // ESTADO
        public string Estado { get; set; }
    }
}
