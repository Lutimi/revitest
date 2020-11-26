using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Reserva
{
    public class CreateReservaViewModel
    {
        // FECHA
        public string Fecha { get; set; }
        // HORA ATENCION
        public string Hora { get; set; }
        // OBSERVACIONES
        public string Observaciones { get; set; }
        // ---------- HAS ONE
        // VEHICULO (CONDUCTOR)
        public int VehiculoId { get; set; }
        // LOCAL (EMPRESA)
        public int LocalId { get; set; }
        // PAGO ADELANTADO
        // RESERVA ESTADO
        public int ReservaEstadoId { get; set; }
    }
}
