using Revifast.Api.Models.Distrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Local
{
    public class LocalViewModel
    {
        // ID
        public int LocalId { get; set; }
        // DIRECCION
        public string Direccion { get; set; }

        // HORA DE APERTURA
        public string HoraApertura { get; set; }
        // HORA DE CIERRE
        public string HoraCierre { get; set; }
        // EMPRESA
        public string Empresa { get; set; }
        // DISTRITO
        public string Distrito { get; set; }
   
    }
}
