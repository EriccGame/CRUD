using CRUD.Extensores;
using CRUD.Modelos;
using CRUD.Modelos.Json;
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
    public class LoginViewModel
    {
        private ApiService apiService;

        public LoginViewModel()
        {
            this.apiService = new ApiService();
        }

        public async Task<Boolean> IniciarSesion(Empleado empleado)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/login", Method.Post, JsonConvert.SerializeObject(empleado), false);
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        Program.Empleado = JsonConvert.DeserializeObject<Empleado>(root.Data.ToString());

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
                    Metodo = "LoginViewModel.IniciarSesion",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }

        public async Task<Boolean> ObtenerEmpleado(Empleado empleado)
        {
            Boolean bResultado = false;

            try
            {
                var jsonResponse = await apiService.LlamarServicio("/empleado", Method.Get, JsonConvert.SerializeObject(empleado));
                var root = JsonConvert.DeserializeObject<Root>(jsonResponse.Json);
                var token = Program.Empleado.Token;

                if (root != null)
                {
                    if (root.Meta.Status.Equals("OK"))
                    {
                        Program.Empleado = JsonConvert.DeserializeObject<Empleado>(root.Data[0].ToString());
                        Program.Empleado.Token = token;

                        bResultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogCrud logCrud = new LogCrud
                {
                    Sistema = "Polizas",
                    Metodo = "LoginViewModel.ObtenerEmpleado",
                    Tipo = "Error",
                };

                await ex.GuardarLogAsync(logCrud);
            }

            return bResultado;
        }
    }
}
