using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Entities
{
    public partial class Modelo
    {
        public Modelo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }
        // ID
        public int ModeloId { get; set; }
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        // ---------- HAS ONE
        // MARCA
        [Required(ErrorMessage = "Marca es requerido")]
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }

        // ---------- HAS MANY
        // VEHICULO
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
