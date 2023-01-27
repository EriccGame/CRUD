using CRUD.Extensores;
using CRUD.Modelos;
using CRUD.Modelos.Json;
using CRUD.Servicios;
using CRUD.VistaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Vistas
{
    public partial class FrmLogin : Form
    {
        /// <summary>
        /// Propiedad de ViewModel
        /// </summary>
        private LoginViewModel ViewModel;

        /// <summary>
        /// Constructor de Login.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento de carga en Login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.ViewModel = new LoginViewModel();
        }

        /// <summary>
        /// Procesador de teclas pulsadas por el usuario.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.Equals(Keys.Escape))
            {
                if (MessageBox.Show("¿Desea cerrar la ventana?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Evento al dar click en iniciar sesión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            if (!txtIdEmpleado.ValidarTextoCapturado(8))
            {
                MessageBox.Show("Favor de verificar id de empleado.", "ID Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdEmpleado.Focus();
            }
            else if (!txtContraseña.ValidarTextoCapturado(4))
            {
                MessageBox.Show("Favor de verificar contraseña.", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContraseña.Focus();
            }
            else 
            {
                var login = new Empleado
                {
                    IdEmpleado = txtIdEmpleado.Text,
                    Contraseña = txtContraseña.Text
                };

                if (await ViewModel.IniciarSesion(login))
                {
                    if (await ViewModel.ObtenerEmpleado(login))
                    {
                        FrmPolizas frmPolizas = new FrmPolizas();

                        this.Hide();

                        frmPolizas.ShowDialog();

                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Evento al dar click en registrar empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaEmpleado_Click(object sender, EventArgs e)
        {
            FrmEmpleado frmEmpleado = new FrmEmpleado(true);

            frmEmpleado.ShowDialog();
        }

        /// <summary>
        /// Evento para controlar lo que el usuario escribe en id empleado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIdEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!txtIdEmpleado.ValidarCaptura(e.KeyChar.ToString(), true))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Evento para controlar lo que el usuario escribe en contraseña.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtContraseña.ValidarCaptura(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}
