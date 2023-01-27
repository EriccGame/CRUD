using CRUD.Modelos.Json;
using CRUD.Modelos;
using CRUD.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using CRUD.Extensores;

namespace CRUD.VistaControlador
{
    public class EmpleadoViewModel
    {
        private ApiService apiService;

        public EmpleadoViewModel()
        {
            this.apiService = new ApiService();
        }

        public async Task<List<Puesto>> ObtenerPuestosAsync()
        {
            List<Puesto> puestos = null;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/puesto", Method.Get, String.Empty, false);
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        puestos = JsonConvert.DeserializeObject<List<Puesto>>(root.Data.ToString());
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
                    Metodo = "EmpleadoViewModel.ObtenerPuestosAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return puestos;
        }

        public async Task<List<Empleado>> ObtenerEmpleadosAsync()
        {
            List<Empleado> listaEmpleados = null;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/empleado", Method.Get);
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        listaEmpleados = JsonConvert.DeserializeObject<List<Empleado>>(root.Data.ToString());
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
                    Metodo = "EmpleadoViewModel.ObtenerEmpleadosAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return listaEmpleados;
        }

        public async Task<List<Empleado>> ObtenerEmpleadosPorNombreAsync(Empleado empleado)
        {
            List<Empleado> listaEmpleados = null;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/empleado", Method.Get, JsonConvert.SerializeObject(empleado));
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        listaEmpleados = JsonConvert.DeserializeObject<List<Empleado>>(root.Data.ToString());
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
                    Metodo = "EmpleadoViewModel.ObtenerEmpleadosPorNombreAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return listaEmpleados;
        }

        public async Task<bool> CrearEmpleadoAsync(Empleado empleado)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/empleado", Method.Post, JsonConvert.SerializeObject(empleado), false);
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
                    Metodo = "EmpleadoViewModel.CrearEmpleadoAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }

        public async Task<bool> ActualizarEmpleadoAsync(Empleado empleado)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/empleado", Method.Put, JsonConvert.SerializeObject(empleado));
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
                    Metodo = "EmpleadoViewModel.ActualizarEmpleadoAsync",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }
    }
}
