using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Revifast.Entities
{
    public partial class Horario
    {
        public Horario()
        {
            Locales = new HashSet<Local>();
        }
        // ID
        public int HorarioId { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public string Dia { get; set; }
        public bool? Feriado { get; set; }
        // ---------- HAS ONE
        // ---------- HAS MANY
        // LOCALES
        public virtual ICollection<Local> Locales { get; set; }
    }
}
