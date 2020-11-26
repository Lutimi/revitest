using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Entities
{
    public partial class ReservaEstado
    {
        public ReservaEstado()
        {
            Reservas = new HashSet<Reserva>();
        }
        // ID
        public int ReservaEstadoId { get; set; }
        // ESTADO
        public string Estado { get; set; }
        // ---------- HAS ONE 
        // ---------- HAS MANY
        // RESERVAS
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
