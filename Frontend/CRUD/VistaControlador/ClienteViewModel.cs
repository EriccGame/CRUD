using CRUD.Modelos.Json;
using CRUD.Modelos;
using CRUD.Servicios;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Extensores;

namespace CRUD.VistaControlador
{
    public class ClienteViewModel
    {
        private ApiService apiService;

        public ClienteViewModel()
        {
            this.apiService = new ApiService();
        }

        /// <summary>
        /// Obtiene todos los clientes registrados.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            List<Cliente> listaClientes = null;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/cliente", Method.Get);
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(root.Data.ToString());
                    }
                    else
                    {
                        var msj = JsonConvert.DeserializeObject<RootMensaje>(root.Data.ToString());

                        MessageBox.Show(msj.Mensaje.IDMensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                LogCrud logCrud = new LogCrud
                {
                    Sistema = "Polizas",
                    Metodo = "ClienteViewModel.ObtenerClientesAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return listaClientes;
        }

        /// <summary>
        /// Obtiene los clientes que coincidan con el nombre capturado.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<List<Cliente>> ObtenerClientesPorNombreAsync(Cliente cliente)
        {
            List<Cliente> listaClientes = null;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/cliente", Method.Get, JsonConvert.SerializeObject(cliente));
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(root.Data.ToString());
                    }
                    else
                    {
                        var msj = JsonConvert.DeserializeObject<RootMensaje>(root.Data.ToString());

                        MessageBox.Show(msj.Mensaje.IDMensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                LogCrud logCrud = new LogCrud
                {
                    Sistema = "Polizas",
                    Metodo = "ClienteViewModel.ObtenerClientesPorNombreAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return listaClientes;
        }

        /// <summary>
        /// Crea un cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<bool> CrearClienteAsync(Cliente cliente)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/cliente", Method.Post, JsonConvert.SerializeObject(cliente));
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        bResultado = true;
                    }
                    else
                    {
                        var msj = JsonConvert.DeserializeObject<RootMensaje>(root.Data.ToString());

                        MessageBox.Show(msj.Mensaje.IDMensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                LogCrud logCrud = new LogCrud
                {
                    Sistema = "Polizas",
                    Metodo = "ClienteViewModel.CrearClienteAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }

        /// <summary>
        /// Actualiza los datos del cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/cliente", Method.Put, JsonConvert.SerializeObject(cliente));
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        bResultado = true;
                    }
                    else
                    {
                        var msj = JsonConvert.DeserializeObject<RootMensaje>(root.Data.ToString());

                        MessageBox.Show(msj.Mensaje.IDMensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                LogCrud logCrud = new LogCrud
                {
                    Sistema = "Polizas",
                    Metodo = "ClienteViewModel.ActualizarClienteAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }
    }
}
