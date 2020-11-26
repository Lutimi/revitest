using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Horario
{
    public class UpdateHorarioViewModel
    {
        public int HorarioId { get; set; }
        // HORA DE APERTURA
        public string HoraApertura { get; set; }
        // HORA DE CIERRE
        public string HoraCierre { get; set; }

        [Required(ErrorMessage = "Especificar Dia de Semana")]
        [DataType(DataType.Text)]
        public string Dia;

        [Required(ErrorMessage = "Especificar Si el Dia es Feriado")]
        public bool Feriado;
    }
}
