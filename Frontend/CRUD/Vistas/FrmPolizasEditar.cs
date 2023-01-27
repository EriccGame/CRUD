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
    public partial class FrmPolizasEditar : Form
    {
        public PolizasViewModel ViewModel;
        public Polizas Polizas { get; set; }

        public FrmPolizasEditar(Polizas polizas, Boolean bEsEdicion)
        {
            InitializeComponent();

            this.Polizas = polizas;

            if (bEsEdicion)
            {
                btnOperacion.Text = "[F5] Editar";
            }
            else
            {
                btnOperacion.Text = "[F5] Eliminar";
            }
        }

        private async void FrmPolizasEditar_Load(object sender, EventArgs e)
        {
            this.ViewModel = new PolizasViewModel();

            txtIdPoliza.Text = this.Polizas.IdPolizas.ToString();

            var inventarioViewModel = new InventarioViewModel();
            var listaArticulos = await inventarioViewModel.ObtenerInventarioAsync();

            if (listaArticulos != null)
            {
                cmbInventario.DataSource = listaArticulos;
                cmbInventario.SelectedValue = Polizas.SKU;
            }

            var empleadoViewModel = new EmpleadoViewModel();
            var listaEmpleados = await empleadoViewModel.ObtenerEmpleadosAsync();

            if (listaEmpleados != null)
            {
                cmbEmpleado.DataSource = listaEmpleados;
                cmbEmpleado.SelectedValue = Polizas.EmpleadoGenero;
            }

            var clienteViewModel = new ClienteViewModel();
            var listaClientes = await clienteViewModel.ObtenerClientesAsync();

            if (listaClientes != null)
            {
                cmbCliente.DataSource = listaClientes;
                cmbCliente.SelectedValue = Polizas.IdCliente;
            }

            txtCantidad.Text = this.Polizas.Cantidad.ToString();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.Equals(Keys.Escape))
            {
                Salir();
            }
            else if (keyData.Equals(Keys.F5))
            {
                Operacion();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private async void btnOperacion_Click(object sender, EventArgs e)
        {
            Operacion();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private async void Operacion()
        {
            if (btnOperacion.Text.Equals("[F5] Eliminar"))
            {

                if (await ViewModel.EliminarPolizasAsync(Polizas.IdPolizas.ToString()))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else if (btnOperacion.Text.Equals("[F5] Editar"))
            {
                Polizas.SKU = cmbInventario.SelectedValue.ToString();
                Polizas.EmpleadoGenero = cmbEmpleado.SelectedValue.ToString();
                Polizas.IdCliente = cmbCliente.SelectedValue.ToString();
                Polizas.Cantidad = Int32.Parse(txtCantidad.Text);

                if (await ViewModel.ActualizarPolizasAsync(Polizas))
                {
                    this.DialogResult = DialogResult.OK;
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
