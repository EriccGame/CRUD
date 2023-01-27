using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Modelos
{
    /// <summary>
    /// Clase para los datos de empleado.
    /// </summary>
    public class Empleado
    {
        public String IdEmpleado { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String? IdPuesto { get; set; }
        public String Contraseña { get; set; }
        public String Token { get; set; }
    }
}
