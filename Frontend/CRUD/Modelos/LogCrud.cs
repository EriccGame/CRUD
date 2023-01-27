using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Modelos
{
    /// <summary>
    /// Clase para los datos de log de errores.
    /// </summary>
    public class LogCrud
    {
        public String IdLog { get; set; }
        public String Sistema { get; set; }
        public String Metodo { get; set; }
        public String Tipo { get; set; }
        public String Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
