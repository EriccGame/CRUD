using CRUD.Extensores;
using CRUD.Modelos;
using CRUD.VistaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Vistas
{
    public partial class FrmEmpleado : Form
    {
        private EmpleadoViewModel ViewModel;

        public FrmEmpleado(Boolean bCrearEmpleado)
        {
            InitializeComponent();

            if (bCrearEmpleado)
            {
                btnBuscar.Visible = false;
            }

            btnGuardar.Text = "[F5] Guardar";
        }

        private async void FrmEmpleado_Load(object sender, EventArgs e)
        {
            this.ViewModel = new EmpleadoViewModel();

            var puesto = await ViewModel.ObtenerPuestosAsync();

            if (puesto != null)
            {
                cmbPuesto.DataSource = puesto;

                if (btnGuardar.Text.Equals("[F5] Actualizar"))
                {
                    cmbPuesto.SelectedValue = Program.Empleado.IdPuesto;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.Equals(Keys.Escape))
            {
                if (MessageBox.Show("¿Desea cerrar la ventana?", "Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else if (keyData.Equals(Keys.F2))
            {
                BuscarEmpleado();
            }
            else if (keyData.Equals(Keys.F5))
            {
                if (ValidarDatosCapturados())
                {
                    _ = RegistrarEmpleadoAsync();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEmpleado();
        }

        private async void btnGuardar_ClickAsync(object sender, EventArgs e)
        {
            if (ValidarDatosCapturados())
            {
                await RegistrarEmpleadoAsync();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la ventana?", "Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtIdEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtIdEmpleado.ValidarCaptura(e.KeyChar.ToString(), true))
            {
                e.Handled = true;
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtContraseña.ValidarCaptura(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtNombre.ValidarCaptura(e.KeyChar.ToString(), LetrasEspacios: true))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtApellido.ValidarCaptura(e.KeyChar.ToString(), LetrasEspacios: true))
            {
                e.Handled = true;
            }
        }

        private Boolean ValidarDatosCapturados()
        {
            Boolean bTodoOK = false;

            if (!txtIdEmpleado.ValidarTextoCapturado(8))
            {
                MessageBox.Show("Favor de verificar id de empleado.", "ID Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdEmpleado.Focus();
            }
            else if (!txtNombre.ValidarTextoCapturado(1))
            {
                MessageBox.Show("Favor de verificar nombre.", "Nombre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
            }
            else if (!txtApellido.ValidarTextoCapturado(1))
            {
                MessageBox.Show("Favor de verificar apellido.", "Apellido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtApellido.Focus();
            }
            else if (!txtContraseña.ValidarTextoCapturado(4))
            {
                MessageBox.Show("Favor de verificar contraseña.", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContraseña.Focus();
            }
            else
            {
                bTodoOK = true;
            }

            return bTodoOK;
        }

        private void BuscarEmpleado()
        {
            if (btnBuscar.Visible)
            {
                FrmEmpleadoBuscador frmEmpleadoBuscador = new FrmEmpleadoBuscador();

                if (frmEmpleadoBuscador.ShowDialog() == DialogResult.OK)
                {
                    txtIdEmpleado.Text = frmEmpleadoBuscador.Empleado.IdEmpleado;
                    txtNombre.Text = frmEmpleadoBuscador.Empleado.Nombre;
                    txtApellido.Text = frmEmpleadoBuscador.Empleado.Apellido;
                    cmbPuesto.SelectedValue = frmEmpleadoBuscador.Empleado.IdPuesto;

                    txtIdEmpleado.ReadOnly = true;

                    txtNombre.Focus();

                    btnGuardar.Text = "[F5] Actualizar";
                }
            }
        }

        private async Task RegistrarEmpleadoAsync()
        {
            var empleado = new Empleado
            {
                IdEmpleado = txtIdEmpleado.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                IdPuesto = cmbPuesto.SelectedValue.ToString(),
                Contraseña = txtContraseña.Text
            };

            if (btnGuardar.Text.Equals("[F5] Guardar"))
            {
                if (await this.ViewModel.CrearEmpleadoAsync(empleado))
                {
                    MessageBox.Show("Se ha creado empleado con éxito.", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    txtIdEmpleado.Focus();
                }
            }
            else
            {
                if (await this.ViewModel.ActualizarEmpleadoAsync(empleado))
                {
                    if (Program.Empleado.IdEmpleado.Equals(empleado.IdEmpleado))
                    {
                        Program.Empleado.Nombre = empleado.Nombre;
                        Program.Empleado.Nombre = empleado.Apellido;
                        Program.Empleado.Nombre = empleado.IdPuesto;
                    }

                    MessageBox.Show("Se ha actualizado empleado con éxito.", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}