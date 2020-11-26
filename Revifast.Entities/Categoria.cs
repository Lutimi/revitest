using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revifast.Entities
{
    public partial class Categoria
    {
        public Categoria()
        {
            Vehiculos = new HashSet<Vehiculo>();
            Servicios = new HashSet<Servicio>();
        }
        // ID
        public int CategoriaId { get; set; }
        // NOMBRE
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(10, ErrorMessage = "Nombre permite 10 caracteres")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        // DESCRIPCION
        [Required(ErrorMessage = "Descripcion es requerido")]
        [StringLength(250, ErrorMessage = "Descripcion permite 250 caracteres")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
        // ---------- HAS ONE
        // ---------- HAS MANY
        // VEHICULO
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
        // SERVICIOS
        public virtual ICollection<Servicio> Servicios { get; set; }



    }
}
