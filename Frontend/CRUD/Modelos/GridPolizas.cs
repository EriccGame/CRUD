using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Modelos
{
    /// <summary>
    /// Clase para los datos del grid de polizas.
    /// </summary>
    public class GridPolizas
    {
        public Int64 IdPolizas { get; set; }
        public String EmpleadoGenero { get; set; }
        public String SKU { get; set; }
        public Int32 Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public String IdCliente { get; set; }
        public String NombreEmpleado { get; set; }
        public String NombreSKU { get; set; }
        public String NombreCliente { get; set; }
    }
}
