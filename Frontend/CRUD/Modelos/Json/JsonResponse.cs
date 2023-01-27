using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Modelos.Json
{
    /// <summary>
    /// Clase para obtener las respuestas del servidor.
    /// </summary>
    public class JsonResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public String Json { get; set; }
    }
}
