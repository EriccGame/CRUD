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
    public partial class FrmCliente : Form
    {
        private ClienteViewModel ViewModel;

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.ViewModel = new ClienteViewModel();

            btnGuardar.Text = "[F5] Guardar";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.Equals(Keys.Escape))
            {
                Salir();
            }
            else if (keyData.Equals(Keys.F2))
            {
                Buscar();
            }
            else if (keyData.Equals(Keys.F5))
            {
                if (ValidarDatosCapturados())
                {
                    _ = Guardar();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtIdCliente.ValidarCaptura(e.KeyChar.ToString(), true))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtNombre.ValidarCaptura(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtApellido.ValidarCaptura(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private Boolean ValidarDatosCapturados()
        {
            Boolean bTodoOK = false;

            if (!txtIdCliente.ValidarTextoCapturado(1))
            {
                MessageBox.Show("Favor de verificar id cliente.", "Id Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdCliente.Focus();
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
            else
            {
                bTodoOK = true;
            }

            return bTodoOK;
        }

        private void Buscar()
        {
            if (btnBuscar.Visible)
            {
                FrmClienteBuscador frmClienteBuscador = new FrmClienteBuscador();

                if (frmClienteBuscador.ShowDialog() == DialogResult.OK)
                {
                    txtIdCliente.Text = frmClienteBuscador.Cliente.IdCliente;
                    txtNombre.Text = frmClienteBuscador.Cliente.Nombre;
                    txtApellido.Text = frmClienteBuscador.Cliente.Apellido;
                    dtpFechaNacimiento.Value = frmClienteBuscador.Cliente.FechaNacimiento;

                    txtIdCliente.ReadOnly = true;

                    txtNombre.Focus();

                    btnGuardar.Text = "[F5] Actualizar";
                }
            }
        }

        private async Task Guardar()
        {
            var cliente = new Cliente
            {
                IdCliente = txtIdCliente.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = dtpFechaNacimiento.Value
            };

            if (btnGuardar.Text.Equals("[F5] Guardar"))
            {
                if (await this.ViewModel.CrearClienteAsync(cliente))
                {
                    MessageBox.Show("Se ha creado cliente con éxito.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    txtIdCliente.Focus();
                }
            }
            else
            {
                if (await this.ViewModel.ActualizarClienteAsync(cliente))
                {
                    MessageBox.Show("Se ha actualizado cliente con éxito.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    txtIdCliente.Focus();
                }
            }
        }

        private void Salir()
        {
            if (MessageBox.Show("¿Desea cerrar la ventana?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
