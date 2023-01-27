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
    public partial class FrmEmpleadoBuscador : Form
    {
        private EmpleadoViewModel ViewModel;

        public Empleado Empleado { get; set; }

        public FrmEmpleadoBuscador()
        {
            InitializeComponent();
        }

        private async void FrmEmpleadoBuscador_Load(object sender, EventArgs e)
        {
            this.ViewModel = new EmpleadoViewModel();
            this.Empleado = new Empleado();

            var empleados = await ViewModel.ObtenerEmpleadosAsync();

            if (empleados != null)
            {
                dgvEmpleado.DataSource = empleados;

                if (empleados.Count > 0)
                {
                    Empleado.IdEmpleado = dgvEmpleado.Rows[0].Cells[0].Value.ToString();
                    Empleado.Nombre = dgvEmpleado.Rows[0].Cells[1].Value.ToString();
                    Empleado.Apellido = dgvEmpleado.Rows[0].Cells[2].Value.ToString();
                    Empleado.IdPuesto = dgvEmpleado.Rows[0].Cells[3].Value.ToString();
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarAsync();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private async void BuscarAsync()
        {
            if (!String.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                var inventario = await ViewModel.ObtenerEmpleadosPorNombreAsync(new Empleado { Nombre = txtNombre.Text });

                if (inventario != null)
                {
                    dgvEmpleado.DataSource = inventario;
                }
            }
            else
            {
                MessageBox.Show("Favor de capturar nombre del articulo en inventario.", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Selecionar()
        {
            if (dgvEmpleado.CurrentCell.RowIndex != -1 && dgvEmpleado.CurrentCell.ColumnIndex != -1)
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

        private void dgvEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                Empleado.IdEmpleado = dgvEmpleado.Rows[e.RowIndex].Cells[0].Value.ToString();
                Empleado.Nombre = dgvEmpleado.Rows[e.RowIndex].Cells[1].Value.ToString();
                Empleado.Apellido = dgvEmpleado.Rows[e.RowIndex].Cells[2].Value.ToString();
                Empleado.IdPuesto = dgvEmpleado.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void dgvEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecionar();
        }

        private void dgvEmpleado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleado.CurrentCell.RowIndex != -1 && dgvEmpleado.CurrentCell.ColumnIndex != -1)
            {
                Empleado.IdEmpleado = dgvEmpleado.Rows[dgvEmpleado.CurrentCell.RowIndex].Cells[0].Value.ToString();
                Empleado.Nombre = dgvEmpleado.Rows[dgvEmpleado.CurrentCell.RowIndex].Cells[1].Value.ToString();
                Empleado.Apellido = dgvEmpleado.Rows[dgvEmpleado.CurrentCell.RowIndex].Cells[2].Value.ToString();
                Empleado.IdPuesto = dgvEmpleado.Rows[dgvEmpleado.CurrentCell.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
}
