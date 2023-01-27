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
    public partial class FrmInventarioBuscador : Form
    {
        private InventarioViewModel ViewModel;
        public Inventario Inventario { get; set; }

        public FrmInventarioBuscador()
        {
            InitializeComponent();
        }

        private async void FrmInventarioBuscador_LoadAsync(object sender, EventArgs e)
        {
            this.ViewModel = new InventarioViewModel();
            this.Inventario = new Inventario();

            var inventario = await ViewModel.ObtenerInventarioAsync();

            if (inventario != null)
            {
                dgvInventario.DataSource = inventario;

                if (inventario.Count > 0)
                {
                    Inventario.SKU = dgvInventario.Rows[0].Cells[0].Value.ToString();
                    Inventario.Nombre = dgvInventario.Rows[0].Cells[1].Value.ToString();
                    Inventario.Cantidad = dgvInventario.Rows[0].Cells[2].Value.ToString();
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
                BuscarAsync();
            }
            else if (keyData.Equals(Keys.F4))
            {
                Selecionar();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarAsync();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                Inventario.SKU = dgvInventario.Rows[e.RowIndex].Cells[0].Value.ToString();
                Inventario.Nombre = dgvInventario.Rows[e.RowIndex].Cells[1].Value.ToString();
                Inventario.Cantidad = dgvInventario.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecionar();
        }

        private void dgvInventario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentCell.RowIndex != -1 && dgvInventario.CurrentCell.ColumnIndex != -1)
            {
                Inventario.SKU = dgvInventario.Rows[dgvInventario.CurrentCell.RowIndex].Cells[0].Value.ToString();
                Inventario.Nombre = dgvInventario.Rows[dgvInventario.CurrentCell.RowIndex].Cells[1].Value.ToString();
                Inventario.Cantidad = dgvInventario.Rows[dgvInventario.CurrentCell.RowIndex].Cells[2].Value.ToString();
            }
        }

        private async void BuscarAsync()
        {
            if (!String.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                var inventario = await ViewModel.ObtenerInventarioPorNombreAsync(new Inventario { Nombre = txtNombre.Text });

                if (inventario != null)
                {
                    dgvInventario.DataSource = inventario;
                }
                else
                {
                    MessageBox.Show("No se encontro información en inventario.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor de capturar nombre del articulo en inventario.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Selecionar()
        {
            if (dgvInventario.CurrentCell.RowIndex != -1 && dgvInventario.CurrentCell.ColumnIndex != -1)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Salir()
        {
            if (MessageBox.Show("¿Desea cerrar la ventana?", "Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void gbLogin_Enter(object sender, EventArgs e)
        {

        }
    }
}
