using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Entities
{
    public partial class Conductor
    {
        public Conductor()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }
        // ID
        public int ConductorId { get; set; }
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Nombre permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // APELLIDO
        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(20, ErrorMessage = "Apellido permite hasta 20 caracteres")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }
        // DNI
        [Required(ErrorMessage = "DNI es requerido")]
        [StringLength(8, ErrorMessage = "DNI permite hasta 8 caracteres")]
        [DataType(DataType.Text)]
        public string Dni { get; set; }
        // DIRECCION
        [StringLength(250, ErrorMessage = "Direccion permite hasta 250 caracteres")]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }
        // CELULAR
        [StringLength(10, ErrorMessage = "Celular permite 10 caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Celular { get; set; }
        // CORREO
        [StringLength(50, ErrorMessage = "Correo permite 50 caracteres")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Correo { get; set; }

        // ---------- HAS ONE
        // ---------- HAS MANY
        // VEHICULO
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }

    }
}
