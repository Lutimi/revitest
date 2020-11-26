using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Horario
{
    public class HorarioViewModel
    {
        public int HorarioId { get; set; }
        // HORA DE APERTURA
        public string HoraApertura { get; set; }
        // HORA DE CIERRE
        public string HoraCierre { get; set; }

        public string Dia;

        public bool Feriado;
    }
}
