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
    public class InventarioViewModel
    {
        private ApiService apiService;

        public InventarioViewModel()
        {
            this.apiService = new ApiService();
        }

        public async Task<List<Inventario>> ObtenerInventarioAsync()
        {
            List<Inventario> inventario = null;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/inventario", Method.Get, String.Empty);
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        inventario = JsonConvert.DeserializeObject<List<Inventario>>(root.Data.ToString());
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
                    Metodo = "InventarioViewModel.ObtenerInventarioAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return inventario;
        }

        public async Task<List<Inventario>> ObtenerInventarioPorNombreAsync(Inventario inventario)
        {
            List<Inventario> listaInventario = null;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/inventario", Method.Get, JsonConvert.SerializeObject(inventario));
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        listaInventario = JsonConvert.DeserializeObject<List<Inventario>>(root.Data.ToString());
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
                    Metodo = "InventarioViewModel.ObtenerInventarioPorNombreAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return listaInventario;
        }

        public async Task<bool> CrearInventarioAsync(Inventario inventario)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/inventario", Method.Post, JsonConvert.SerializeObject(inventario));
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
                    Metodo = "InventarioViewModel.CrearInventarioAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }

        public async Task<bool> ActualizarInventarioAsync(Inventario inventario)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/inventario", Method.Put, JsonConvert.SerializeObject(inventario));
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
                    Metodo = "InventarioViewModel.ActualizarInventarioAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }
    }
}
