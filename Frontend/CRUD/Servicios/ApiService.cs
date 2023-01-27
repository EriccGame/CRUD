using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using CRUD.Modelos.Json;

namespace CRUD.Servicios
{
    /// <summary>
    /// Clase para hacer peticiones a el servidor.
    /// </summary>
    public class ApiService
    {
        /// <summary>
        /// Url base del servicio a utilizar.
        /// </summary>
        private const String UrlBase = "http://localhost:8081/api";

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ApiService() 
        {

        }

        /// <summary>
        /// Llama a un servicio de servidor.
        /// </summary>
        /// <param name="sUrl">Ruta del controlador a llamar.</param>
        /// <param name="method">Metodo que se usara para procesar la petición.</param>
        /// <param name="sDatosJson">Datos en json para procesar como Get, Put, Post, etc.</param>
        /// <param name="bRequiereAutorizacion">Usado para rutas que no requieren token.</param>
        /// <returns></returns>
        public async Task<JsonResponse> LlamarServicio(string sUrl, Method method, String sDatosJson = "", Boolean bRequiereAutorizacion = true)
        {
            JsonResponse jsonResponse = new JsonResponse();

            try
            {
                var client = new RestClient(UrlBase);
                var request = new RestRequest(sUrl, method);

                request.AddHeader("Accept", "application/json");

                if (!String.IsNullOrEmpty(sDatosJson))
                {
                    request.AddParameter("application/json", sDatosJson, ParameterType.RequestBody);
                }

                if (bRequiereAutorizacion)
                {
                    request.AddHeader("Authorization", Program.Empleado.Token);
                }

                var response = await client.ExecuteAsync(request);

                jsonResponse.StatusCode = response.StatusCode;
                jsonResponse.Json = String.IsNullOrEmpty(response.Content) ? String.Empty : response.Content;
            }
            catch (Exception ex)
            {
                jsonResponse.StatusCode = HttpStatusCode.Conflict;
                MessageBox.Show(ex.Message);
            }

            return jsonResponse;
        }
    }
}
