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
    public partial class FrmInventario : Form
    {
        private InventarioViewModel ViewModel;

        public FrmInventario()
        {
            InitializeComponent();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            this.ViewModel = new InventarioViewModel();
            
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
                BuscarInventario();
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

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosCapturados())
            {
                await Guardar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarInventario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void txtSKU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtSKU.ValidarCaptura(e.KeyChar.ToString(), true))
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtCantidad.ValidarCaptura(e.KeyChar.ToString(), true))
            {
                e.Handled = true;
            }
        }

        private Boolean ValidarDatosCapturados()
        {
            Boolean bTodoOK = false;

            if (!txtSKU.ValidarTextoCapturado(1))
            {
                MessageBox.Show("Favor de verificar sku.", "SKU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSKU.Focus();
            }
            else if (!txtNombre.ValidarTextoCapturado(1))
            {
                MessageBox.Show("Favor de verificar nombre.", "Nombre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
            }
            else if (!txtCantidad.ValidarTextoCapturado(1))
            {
                MessageBox.Show("Favor de verificar cantidad.", "Apellido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantidad.Focus();
            }
            else
            {
                bTodoOK = true;
            }

            return bTodoOK;
        }

        private void BuscarInventario()
        {
            if (btnBuscar.Visible)
            {
                FrmInventarioBuscador frmInventarioBuscador = new FrmInventarioBuscador();

                if (frmInventarioBuscador.ShowDialog() == DialogResult.OK)
                {
                    txtSKU.Text = frmInventarioBuscador.Inventario.SKU;
                    txtNombre.Text = frmInventarioBuscador.Inventario.Nombre;
                    txtCantidad.Text = frmInventarioBuscador.Inventario.Cantidad;

                    txtSKU.ReadOnly = true;

                    txtNombre.Focus();

                    btnGuardar.Text = "[F5] Actualizar";
                }
            }
        }

        private async Task Guardar()
        {
            var inventario = new Inventario
            {
                SKU = txtSKU.Text,
                Nombre = txtNombre.Text,
                Cantidad = txtCantidad.Text
            };

            if (btnGuardar.Text.Equals("[F5] Guardar"))
            {
                if (await this.ViewModel.CrearInventarioAsync(inventario))
                {
                    MessageBox.Show("Se ha creado inventario con éxito.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    txtSKU.Focus();
                }
            }
            else
            {
                if (await this.ViewModel.ActualizarInventarioAsync(inventario))
                {
                    MessageBox.Show("Se ha actualizado inventario con éxito.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    txtSKU.Focus();
                }
            }
        }

        private void Salir()
        {
            if (MessageBox.Show("¿Desea cerrar la ventana?", "Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
