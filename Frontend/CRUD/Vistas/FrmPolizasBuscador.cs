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
    public partial class FrmPolizasBuscador : Form
    {
        public PolizasViewModel ViewModel;
        public Polizas Polizas { get; set; }
        private List<GridPolizas> listaPolizas = new List<GridPolizas>();
        private Boolean bEsEdicion;

        public FrmPolizasBuscador(Boolean bEsEdicion)
        {
            InitializeComponent();

            this.bEsEdicion = bEsEdicion;   
        }

        private void FrmPolizasBuscador_Load(object sender, EventArgs e)
        {
            ViewModel = new PolizasViewModel();
            this.Polizas = new Polizas();

            CargarGrid();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.Equals(Keys.Escape))
            {
                Salir();
            }
            else if (keyData.Equals(Keys.F4))
            {
                Selecionar();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private async void CargarGrid()
        {
            var polizas = await ViewModel.ObtenerPolizasAsync();

            if (polizas != null)
            {
                var viewModelInventario = new InventarioViewModel();
                var listaInventario = await viewModelInventario.ObtenerInventarioAsync();

                var viewModelEmpleado = new EmpleadoViewModel();
                var listaEmpleado = await viewModelEmpleado.ObtenerEmpleadosAsync();

                var viewModelCliente = new ClienteViewModel();
                var listaCliente = await viewModelCliente.ObtenerClientesAsync();

                listaPolizas.Clear();

                foreach (var item in polizas)
                {
                    var articulo = listaInventario.Where(x => x.SKU.Equals(item.SKU)).FirstOrDefault();
                    var empleado = listaEmpleado.Where(x => x.IdEmpleado.Equals(item.EmpleadoGenero)).FirstOrDefault();
                    var cliente = listaCliente.Where(x => x.IdCliente.Equals(item.IdCliente)).FirstOrDefault();

                    listaPolizas.Add(new GridPolizas
                    {
                        IdPolizas = item.IdPolizas,
                        EmpleadoGenero = item.EmpleadoGenero,
                        Cantidad = item.Cantidad,
                        Fecha = item.Fecha,
                        IdCliente = item.IdCliente,
                        SKU = item.SKU,
                        NombreSKU = articulo.Nombre,
                        NombreEmpleado = empleado.Nombre + " " + empleado.Apellido,
                        NombreCliente = cliente.Nombre + " " + cliente.Apellido
                    });
                }

                if (listaPolizas.Count > 0)
                {
                    dgvPolizas.DataSource = listaPolizas;

                    Polizas.IdPolizas = long.Parse(dgvPolizas.Rows[0].Cells[0].Value.ToString());
                    Polizas.Cantidad = int.Parse(dgvPolizas.Rows[0].Cells[4].Value.ToString());
                    Polizas.SKU = dgvPolizas.Rows[0].Cells[5].Value.ToString();
                    Polizas.EmpleadoGenero = dgvPolizas.Rows[0].Cells[6].Value.ToString();
                    Polizas.IdCliente = dgvPolizas.Rows[0].Cells[7].Value.ToString();
                    Polizas.Fecha = DateTime.Parse(dgvPolizas.Rows[0].Cells[8].Value.ToString());
                }
            }

            dgvPolizas.Refresh();
        }

        private void Selecionar()
        {
            if (dgvPolizas.CurrentCell.RowIndex != -1 && dgvPolizas.CurrentCell.ColumnIndex != -1)
            {
                FrmPolizasEditar frmPolizasEditar = new FrmPolizasEditar(Polizas, bEsEdicion);

                if (frmPolizasEditar.ShowDialog() == DialogResult.OK)
                {
                    CargarGrid();
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

        private void dgvPolizas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                Polizas.IdPolizas = long.Parse(dgvPolizas.Rows[e.RowIndex].Cells[0].Value.ToString());
                Polizas.Cantidad = int.Parse(dgvPolizas.Rows[e.RowIndex].Cells[4].Value.ToString());
                Polizas.SKU = dgvPolizas.Rows[e.RowIndex].Cells[5].Value.ToString();
                Polizas.EmpleadoGenero = dgvPolizas.Rows[e.RowIndex].Cells[6].Value.ToString();
                Polizas.IdCliente = dgvPolizas.Rows[e.RowIndex].Cells[7].Value.ToString();
                Polizas.Fecha = DateTime.Parse(dgvPolizas.Rows[e.RowIndex].Cells[8].Value.ToString());
            }
        }

        private void dgvPolizas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecionar();
        }

        private void dgvPolizas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPolizas.CurrentCell.RowIndex != -1 && dgvPolizas.CurrentCell.ColumnIndex != -1)
            {
                Polizas.IdPolizas = long.Parse(dgvPolizas.Rows[dgvPolizas.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Polizas.Cantidad = int.Parse(dgvPolizas.Rows[dgvPolizas.CurrentCell.RowIndex].Cells[4].Value.ToString());
                Polizas.SKU = dgvPolizas.Rows[dgvPolizas.CurrentCell.RowIndex].Cells[5].Value.ToString();
                Polizas.EmpleadoGenero = dgvPolizas.Rows[dgvPolizas.CurrentCell.RowIndex].Cells[6].Value.ToString();
                Polizas.IdCliente = dgvPolizas.Rows[dgvPolizas.CurrentCell.RowIndex].Cells[7].Value.ToString();
                Polizas.Fecha = DateTime.Parse(dgvPolizas.Rows[dgvPolizas.CurrentCell.RowIndex].Cells[8].Value.ToString());
            }
        }
    }
}
