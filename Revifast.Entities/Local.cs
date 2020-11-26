using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Revifast.Entities
{
    public partial class Local
    {
        public Local()
        {
            Servicios = new HashSet<Servicio>();
            Reservas = new HashSet<Reserva>();
        }
        // ID
        public int LocalId { get; set; }
        // DIRECCION
        [Required(ErrorMessage = "Direccion es requerida")]
        [StringLength(250, ErrorMessage = "Direccion permite hasta 250 caracteres")]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }
        // ---------- HAS ONE
        // HORARIO
        public int HorarioId { get; set; }
        public virtual Horario Horario { get; set; }
        // EMPRESA
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        // DISTRITO
        public int DistritoId { get; set; }
        public virtual Distrito Distrito { get; set; }
        // ---------- HAS MANY
        // SERVICIOS
        public virtual ICollection<Servicio> Servicios { get; set; }
        // RESERVAS
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
