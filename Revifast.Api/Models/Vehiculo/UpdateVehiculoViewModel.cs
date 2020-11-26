using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Vehiculo
{
    public class UpdateVehiculoViewModel
    {
        // ID
        public int VehiculoId { get; set; }
        // PLACA
        [Required(ErrorMessage = "Placa es requerido")]
        [StringLength(10, ErrorMessage = "Placa permite hasta 10 caracteres")]
        [DataType(DataType.Text)]
        public string Placa { get; set; }
        // COLOR
        [Required(ErrorMessage = "Color es requerido")]
        [StringLength(10, ErrorMessage = "Color permite hasta 10 caracteres")]
        [DataType(DataType.Text)]
        public string Color { get; set; }
        // FECHA FABRICACION
        [Required(ErrorMessage = "Fecha de fabricacion es requerido")]
        [DataType(DataType.Text)]
        public string FechaFabricacion { get; set; }

        // ---------- HAS ONE 
        // CONDUCTOR
        [Required(ErrorMessage = "Conductor es requerido")]
        public int ConductorId { get; set; }
        // CATEGORIA
        [Required(ErrorMessage = "Categoria es requerido")]
        public int CategoriaId { get; set; }
        // MODELO
        [Required(ErrorMessage = "Modelo es requerido")]
        public int ModeloId { get; set; }
    }
}
