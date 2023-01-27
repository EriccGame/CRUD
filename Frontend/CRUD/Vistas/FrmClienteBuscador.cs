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
    public partial class FrmClienteBuscador : Form
    {
        private ClienteViewModel ViewModel;
        public Cliente Cliente;

        public FrmClienteBuscador()
        {
            InitializeComponent();
        }

        private async void FrmClienteBuscador_Load(object sender, EventArgs e)
        {
            this.ViewModel = new ClienteViewModel();
            this.Cliente = new Cliente();

            var clientes = await ViewModel.ObtenerClientesAsync();

            if (clientes != null)
            {
                dgvCliente.DataSource = clientes;

                if (clientes.Count > 0)
                {
                    Cliente.IdCliente = dgvCliente.Rows[0].Cells[0].Value.ToString();
                    Cliente.Nombre = dgvCliente.Rows[0].Cells[1].Value.ToString();
                    Cliente.Apellido = dgvCliente.Rows[0].Cells[2].Value.ToString();
                    Cliente.FechaNacimiento = DateTime.Parse(dgvCliente.Rows[0].Cells[3].Value.ToString());
                }
            }
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private async void Buscar()
        {
            if (!String.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                var inventario = await ViewModel.ObtenerClientesPorNombreAsync(new Cliente { Nombre = txtNombre.Text });

                if (inventario != null)
                {
                    dgvCliente.DataSource = inventario;
                }
            }
            else
            {
                MessageBox.Show("Favor de capturar nombre del cliente.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Selecionar()
        {
            if (dgvCliente.CurrentCell.RowIndex != -1 && dgvCliente.CurrentCell.ColumnIndex != -1)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Salir()
        {
            if (MessageBox.Show("¿Desea cerrar la ventana?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                Cliente.IdCliente = dgvCliente.Rows[e.RowIndex].Cells[0].Value.ToString();
                Cliente.Nombre = dgvCliente.Rows[e.RowIndex].Cells[1].Value.ToString();
                Cliente.Apellido = dgvCliente.Rows[e.RowIndex].Cells[2].Value.ToString();
                Cliente.FechaNacimiento = DateTime.Parse(dgvCliente.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecionar();
        }

        private void dgvCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCliente.CurrentCell.RowIndex != -1 && dgvCliente.CurrentCell.ColumnIndex != -1)
            {
                Cliente.IdCliente = dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells[0].Value.ToString();
                Cliente.Nombre = dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells[1].Value.ToString();
                Cliente.Apellido = dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells[2].Value.ToString();
                Cliente.FechaNacimiento = DateTime.Parse(dgvCliente.Rows[dgvCliente.CurrentCell.RowIndex].Cells[3].Value.ToString());
            }
        }
    }
}
