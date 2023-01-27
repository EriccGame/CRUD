using CRUD.Modelos;
using CRUD.Servicios;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRUD.Extensores
{
    /// <summary>
    /// Se usa para extender cualquier tipo de objeto o variable.
    /// </summary>
    internal static class Extensores
    {
        /// <summary>
        /// Se valida al momento de procesar la información Guardar/Actualizar/Borrar/Obtener.
        /// </summary>
        /// <param name="tb">Textbox usado.</param>
        /// <param name="iLonguitudMinima">Tamaño minimo para el texto capturado.</param>
        /// <returns></returns>
        public static bool ValidarTextoCapturado(this TextBox tb, Int32 iLonguitudMinima = 0)
        {
            bool bCapturaValida = true;

            if (String.IsNullOrEmpty(tb.Text.Trim()))
            {
                bCapturaValida = false;
            }
            else if (iLonguitudMinima > 0 && tb.TextLength < iLonguitudMinima)
            {
                bCapturaValida = false;
            }

            return bCapturaValida;
        }

        /// <summary>
        /// Valida al momento de teclar el usuario.
        /// </summary>
        /// <param name="tb">Textbox usado.</param>
        /// <param name="newTextValue">Valor nuevo tecleado por el usuario.</param>
        /// <param name="SoloNumeros">Solo aceptara numeros.</param>
        /// <param name="NumerosEspacios">Solo acepta numeros y espacios.</param>
        /// <param name="LetrasEspacios">Solo acepta letras y espacios.</param>
        /// <param name="TextoLibre">Permite texto que no afecta el funcionamiento en la integridad de datos.</param>
        /// <returns></returns>
        public static bool ValidarCaptura(this TextBox tb,
                                          String newTextValue,
                                          bool SoloNumeros = false,
                                          bool NumerosEspacios = false,
                                          bool LetrasEspacios = false,
                                          bool TextoLibre = false)
        {
            bool bCapturaValida = false;

            if (!String.IsNullOrEmpty(newTextValue))
            {
                if (newTextValue.Equals("\b"))
                {
                    bCapturaValida = true;
                }
                else if (SoloNumeros && !Regex.IsMatch(newTextValue, @"^[0-9]+$"))
                {
                    tb.Refresh();
                }
                else if (NumerosEspacios && !Regex.IsMatch(newTextValue, @"^[0-9 ]+$"))
                {
                    tb.Refresh();
                }
                else if (LetrasEspacios && !Regex.IsMatch(newTextValue, @"^[a-zA-Z áéíóúÁÉÍÓÚ]+$"))
                {
                    tb.Refresh();
                }
                else if (TextoLibre)
                {
                    bCapturaValida = true;
                }
                else if (!Regex.IsMatch(newTextValue, @"^[a-zA-Z0-9 áéíóúÁÉÍÓÚñÑ]+$"))
                {
                    tb.Refresh();
                }
                else if (newTextValue.Equals("\b"))
                {
                    bCapturaValida = true;
                }
                else
                {
                    bCapturaValida = true;
                }
            }

            tb.Refresh();

            return bCapturaValida;
        }

        /// <summary>
        /// Guarda un log dependiendo de un mensaje.
        /// </summary>
        /// <param name="descripcion">Descripcion de log.</param>
        /// <param name="logCrud">Objeto de datos en el log.</param>
        /// <returns></returns>
        public static async Task GuardarLogAsync(this String descripcion, LogCrud logCrud)
        {
            try
            {
                logCrud.Descripcion = descripcion;

                var apiService = new ApiService();
                var jsonResponse = await apiService.LlamarServicio("/log", Method.Post, JsonConvert.SerializeObject(logCrud), false);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Guarda un log de una excepción.
        /// </summary>
        /// <param name="ex">Excepción a guardar</param>
        /// <param name="logCrud">Objeto de datos en el log.</param>
        /// <returns></returns>
        public static async Task GuardarLogAsync(this Exception ex, LogCrud logCrud)
        {
            await GuardarLogAsync(ex.Message, logCrud);

            MessageBox.Show("Error al procesar petición", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
