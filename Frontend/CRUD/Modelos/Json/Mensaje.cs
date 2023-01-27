using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Modelos.Json
{
    public class Mensaje
    {
        public string IDMensaje { get; set; }
    }

    public class RootMensaje
    {
        public Mensaje Mensaje { get; set; }
    }
}
