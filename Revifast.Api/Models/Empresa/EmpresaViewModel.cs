using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Empresa
{
    public class EmpresaViewModel
    {
        public int EmpresaId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // RUC
        public string Ruc { get; set; }
        // TELEFONO
        public string Telefono { get; set; }
        // CORREO
        public string Correo { get; set; }
    }
}
