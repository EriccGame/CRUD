using CRUD.Extensores;
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

namespace CRUD.VistaControlador
{
    public class PolizasViewModel
    {
        private ApiService apiService;

        public PolizasViewModel()
        {
            this.apiService = new ApiService();
        }

        public async Task<List<Polizas>> ObtenerPolizasAsync()
        {
            List<Polizas> listaPolizass = null;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/polizas", Method.Get);
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        listaPolizass = JsonConvert.DeserializeObject<List<Polizas>>(root.Data.ToString());
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
                    Metodo = "PolizasViewModel.ObtenerPolizassAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return listaPolizass;
        }

        public async Task<Polizas> ObtenerPolizasPorIdAsync(String idPolizas)
        {
            Polizas polizas = null;

            try
            {
                var jsonResponse = await apiService.LlamarServicio($"/polizas/{idPolizas}", Method.Get);
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        polizas = JsonConvert.DeserializeObject<Polizas>(root.Data.ToString());
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
                    Metodo = "PolizasViewModel.ObtenerPolizassPorNombreAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return polizas;
        }

        public async Task<bool> CrearPolizasAsync(List<Polizas> listaPolizas)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/polizas", Method.Post, JsonConvert.SerializeObject(listaPolizas));
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
                    Metodo = "PolizasViewModel.CrearPolizasAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }

        public async Task<bool> ActualizarPolizasAsync(Polizas polizas)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/polizas", Method.Put, JsonConvert.SerializeObject(polizas));
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        bResultado = true;

                        var msj = JsonConvert.DeserializeObject<RootMensaje>(root.Data.ToString());

                        MessageBox.Show(msj.Mensaje.IDMensaje, "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Metodo = "PolizasViewModel.ActualizarPolizasAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }

        public async Task<bool> EliminarPolizasAsync(String idPoliza)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio($"/polizas/{idPoliza}", Method.Delete);
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        bResultado = true;

                        var msj = JsonConvert.DeserializeObject<RootMensaje>(root.Data.ToString());

                        MessageBox.Show(msj.Mensaje.IDMensaje, "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Metodo = "PolizasViewModel.ActualizarPolizasAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }
    }
}
