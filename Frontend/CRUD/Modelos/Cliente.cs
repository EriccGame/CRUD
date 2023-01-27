using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Modelos
{
    /// <summary>
    /// Clase para los datos de cliente.
    /// </summary>
    public class Cliente
    {
        public String IdCliente { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
