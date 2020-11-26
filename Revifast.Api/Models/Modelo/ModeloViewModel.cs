using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Modelo
{
    public class ModeloViewModel
    {
        public int ModeloId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // MARCA
        public int MarcaId { get; set; }
    }
}
