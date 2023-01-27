using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Modelos
{
    /// <summary>
    /// Clase para los datos de inventario.
    /// </summary>
    public class Inventario
    {
        public String SKU { get; set; }
        public String Nombre { get; set; }
        public String Cantidad { get; set; }
    }
}
