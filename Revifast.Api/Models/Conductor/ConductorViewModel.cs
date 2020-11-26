using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Conductor
{
    public class ConductorViewModel
    {
        // ID
        public int ConductorId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // APELLIDO
        public string Apellido { get; set; }
        // DNI
        public string Dni { get; set; }
        // DIRECCION
        public string Direccion { get; set; }
        // CELULAR
        public string Celular { get; set; }
        // CORREO
        public string Correo { get; set; }
    }
}
