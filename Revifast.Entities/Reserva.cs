using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Entities
{
    public partial class Reserva
    {
        public Reserva()
        {
            
        }
        // ID
        public int ReservaId { get; set; }
        // FECHA
        public string Fecha { get; set; }
        // HORA ATENCION
        public string Hora { get; set; }
        // OBSERVACIONES
        public string Observaciones { get; set; }
        // ---------- HAS ONE
        // VEHICULO (CONDUCTOR)
        public int VehiculoId { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        // LOCAL (EMPRESA)
        public int LocalId { get; set; }
        public virtual Local Local { get; set; }
        // PAGO ADELANTADO
        public int ReservaEstadoId { get; set; }
        public virtual ReservaEstado ReservaEstado { get; set; }
        // ---------- HAS MANY
    }
}
