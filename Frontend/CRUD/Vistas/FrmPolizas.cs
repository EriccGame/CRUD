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
    public partial class FrmPolizas : Form
    {
        /// <summary>
        /// Propiedad de ViewModel
        /// </summary>
        private PolizasViewModel ViewModel;

        /// <summary>
        /// Constructor de formulario de polizas.
        /// </summary>
        public FrmPolizas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga inicial del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmPolizas_LoadAsync(object sender, EventArgs e)
        {
            ViewModel = new PolizasViewModel();

            CargarInventario();

            CargarEmpleados();

            CargarClientes();
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
                Salir();
            }
            else if (keyData.Equals(Keys.F1))
            {
                FrmInventario frmInventario = new FrmInventario();

                frmInventario.ShowDialog();
            }
            else if (keyData.Equals(Keys.F2))
            {
                FrmEmpleado frmEmpleado = new FrmEmpleado(false);

                frmEmpleado.ShowDialog();
            }
            else if (keyData.Equals(Keys.F3))
            {
                FrmCliente frmCliente = new FrmCliente();

                frmCliente.ShowDialog();
            }
            else if (keyData.Equals(Keys.F4))
            {
                Generar();
            }
            else if (keyData.Equals(Keys.F5))
            {
                Editar();
            }
            else if (keyData.Equals(Keys.F6))
            {
                Eliminar();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Evento del click al boton empleado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnEmpleado_Click(object sender, EventArgs e)
        {
            FrmEmpleado frmEmpleado = new FrmEmpleado(false);

            frmEmpleado.ShowDialog();

            CargarEmpleados();
        }

        /// <summary>
        /// Evento del click al boton inventario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario frmInventario = new FrmInventario();

            frmInventario.ShowDialog();

            CargarInventario();
        }

        /// <summary>
        /// Evento del click al boton cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();

            frmCliente.ShowDialog();

            CargarClientes();
        }

        /// <summary>
        /// Evento para detectar la captura de cantidad en la poliza.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPolizas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgvCantidad_KeyPress);

            if (dgvPolizas.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgvCantidad_KeyPress);
                }
            }
        }

        /// <summary>
        /// Evento que permite solo la captura de números.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Evento del click al boton generar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Generar();
        }

        /// <summary>
        /// Evento del click al boton editar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        /// <summary>
        /// Evento del click al boton eliminar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        /// <summary>
        /// Evento del click al boton salir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        /// <summary>
        /// Metodo para la carga de empleados.
        /// </summary>
        private async void CargarEmpleados()
        {
            dgvColumnEmpleado.DisplayMember = "Nombre";
            dgvColumnEmpleado.ValueMember = "IdEmpleado";

            var viewModelEmpleado = new EmpleadoViewModel();
            var empleados = await viewModelEmpleado.ObtenerEmpleadosAsync();

            if (empleados != null)
            {
                foreach (var item in empleados)
                {
                    item.Nombre = item.Nombre + " " + item.Apellido;
                }

                dgvColumnEmpleado.DataSource = empleados;
                dgvPolizas.Refresh();
            }
        }

        /// <summary>
        /// Metodo para la carga de inventario.
        /// </summary>
        private async void CargarInventario()
        {
            dgvColumnInventario.DisplayMember = "Nombre";
            dgvColumnInventario.ValueMember = "SKU";

            var viewModelInventario = new InventarioViewModel();
            var inventario = await viewModelInventario.ObtenerInventarioAsync();

            if (inventario != null)
            {
                dgvColumnInventario.DataSource = inventario;
                dgvPolizas.Refresh();
            }
        }

        /// <summary>
        /// Metodo para la carga de clientes.
        /// </summary>
        private async void CargarClientes()
        {
            dgvColumnCliente.DisplayMember = "Nombre";
            dgvColumnCliente.ValueMember = "IdCliente";

            var viewModelCliente = new ClienteViewModel();
            var clientes = await viewModelCliente.ObtenerClientesAsync();

            if (clientes != null)
            {
                foreach (var item in clientes)
                {
                    item.Nombre = item.Nombre + " " + item.Apellido;
                }

                dgvColumnCliente.DataSource = clientes;
                dgvPolizas.Refresh();
            }
        }

        /// <summary>
        /// Valida los datos capturados por en el grid.
        /// </summary>
        /// <returns></returns>
        private Boolean ValidarCaptura()
        {
            Boolean bResultado = true;

            if (dgvPolizas.RowCount - 1 == 0)
            {
                MessageBox.Show("Favor capturar por lo menos una poliza a generar.", "Polizas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bResultado = false;
            }
            else
            {
                for (int i = 0; i < dgvPolizas.RowCount - 1; i++)
                {
                    if (dgvPolizas.Rows[i].Cells[0].Value == null)
                    {
                        MessageBox.Show("Favor capturar artículo de inventario.", "Polizas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvPolizas.Rows[i].Cells[0].Selected = true;
                        dgvPolizas.CurrentCell = dgvPolizas.Rows[i].Cells[0];
                        dgvPolizas.BeginEdit(true);

                        bResultado = false;

                        break;
                    }
                    else if (dgvPolizas.Rows[i].Cells[1].Value == null)
                    {
                        MessageBox.Show("Favor capturar empleado.", "Polizas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvPolizas.Rows[i].Cells[1].Selected = true;
                        dgvPolizas.CurrentCell = dgvPolizas.Rows[i].Cells[1];
                        dgvPolizas.BeginEdit(true);

                        bResultado = false;

                        break;
                    }
                    else if (dgvPolizas.Rows[i].Cells[2].Value == null)
                    {
                        MessageBox.Show("Favor capturar cliente.", "Polizas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvPolizas.Rows[i].Cells[2].Selected = true;
                        dgvPolizas.CurrentCell = dgvPolizas.Rows[i].Cells[2];
                        dgvPolizas.BeginEdit(true);

                        bResultado = false;

                        break;
                    }
                    else if (dgvPolizas.Rows[i].Cells[3].Value == null)
                    {
                        MessageBox.Show("Favor capturar cantidad.", "Polizas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvPolizas.Rows[i].Cells[3].Selected = true;
                        dgvPolizas.CurrentCell = dgvPolizas.Rows[i].Cells[3];
                        dgvPolizas.BeginEdit(true);

                        bResultado = false;

                        break;
                    }
                    else if (dgvPolizas.Rows[i].Cells[3].Value.ToString().Equals("0"))
                    {
                        MessageBox.Show("Favor capturar cantidad mayor a cero.", "Polizas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvPolizas.Rows[i].Cells[3].Selected = true;
                        dgvPolizas.CurrentCell = dgvPolizas.Rows[i].Cells[3];
                        dgvPolizas.BeginEdit(true);

                        bResultado = false;

                        break;
                    }
                }
            }

            return bResultado;
        }

        /// <summary>
        /// Genera las polizas capturadas en el grid.
        /// </summary>
        private async void Generar()
        {
            if (ValidarCaptura())
            {
                List<Polizas> listaPolizas = new List<Polizas>();

                for (int i = 0; i < dgvPolizas.RowCount - 1; i++)
                {
                    var poliza = new Polizas
                    {
                        SKU = dgvPolizas.Rows[i].Cells[0].Value.ToString(),
                        EmpleadoGenero = dgvPolizas.Rows[i].Cells[1].Value.ToString(),
                        IdCliente = dgvPolizas.Rows[i].Cells[2].Value.ToString(),
                        Cantidad = Int32.Parse(dgvPolizas.Rows[i].Cells[3].Value.ToString()),
                        Fecha = DateTime.Now,
                    };

                    listaPolizas.Add(poliza);
                }

                if (listaPolizas.Count > 0)
                {
                    if (await this.ViewModel.CrearPolizasAsync(listaPolizas))
                    {
                        MessageBox.Show("Se ha generado la(s) poliza(s) con éxito.", "Polizas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvPolizas.Rows.Clear();
                        dgvPolizas.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// Abre el formulario de buscador de polizas.
        /// </summary>
        private void Editar()
        {
            FrmPolizasBuscador frmPolizasBuscador = new FrmPolizasBuscador(true);

            frmPolizasBuscador.ShowDialog();
        }

        /// <summary>
        /// Abre el formulario de buscador de polizas.
        /// </summary>
        private void Eliminar()
        {
            FrmPolizasBuscador frmPolizasBuscador = new FrmPolizasBuscador(false);

            frmPolizasBuscador.ShowDialog();
        }

        /// <summary>
        /// Abre para salir de la pantalla actual.
        /// </summary>
        private void Salir()
        {
            if (MessageBox.Show("¿Desea cerrar la ventana?", "Polizas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
