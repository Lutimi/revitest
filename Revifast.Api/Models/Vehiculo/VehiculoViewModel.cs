using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Vehiculo
{
    public class VehiculoViewModel
    {
        // ID
        public int VehiculoId { get; set; }
        // PLACA
        public string Placa { get; set; }
        // COLOR
        public string Color { get; set; }
        // FECHA FABRICACION
        public string FechaFabricacion { get; set; }
        // ---------- HAS ONE 
        // CONDUCTOR
        public int ConductorId { get; set; }
        // CATEGORIA
        public int CategoriaId { get; set; }
        // MODELO
        public int ModeloId { get; set; }
    }
}
