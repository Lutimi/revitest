using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revifast.Api.Models.Categoria
{
    public class CategoriaViewModel
    {
        public int CategoriaId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // DESCRIPCION
        public string Descripcion { get; set; }
    }
}
