namespace CRUD.Vistas
{
    partial class FrmPolizasBuscador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgvPolizas = new System.Windows.Forms.DataGridView();
            this.idPolizasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreSKUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEmpleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sKUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadoGeneroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPolizasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolizas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPolizasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnSalir);
            this.gbLogin.Controls.Add(this.btnSeleccionar);
            this.gbLogin.Controls.Add(this.dgvPolizas);
            this.gbLogin.Location = new System.Drawing.Point(12, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(935, 668);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSalir.Location = new System.Drawing.Point(470, 612);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(150, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "[Esc] Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSeleccionar.Location = new System.Drawing.Point(314, 612);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(150, 50);
            this.btnSeleccionar.TabIndex = 1;
            this.btnSeleccionar.Text = "[F4] Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dgvPolizas
            // 
            this.dgvPolizas.AllowUserToAddRows = false;
            this.dgvPolizas.AllowUserToDeleteRows = false;
            this.dgvPolizas.AutoGenerateColumns = false;
            this.dgvPolizas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPolizas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPolizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPolizas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPolizasDataGridViewTextBoxColumn,
            this.nombreSKUDataGridViewTextBoxColumn,
            this.nombreEmpleadoDataGridViewTextBoxColumn,
            this.nombreClienteDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.sKUDataGridViewTextBoxColumn,
            this.empleadoGeneroDataGridViewTextBoxColumn,
            this.idClienteDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn});
            this.dgvPolizas.DataSource = this.gridPolizasBindingSource;
            this.dgvPolizas.Location = new System.Drawing.Point(6, 30);
            this.dgvPolizas.Name = "dgvPolizas";
            this.dgvPolizas.ReadOnly = true;
            this.dgvPolizas.RowHeadersVisible = false;
            this.dgvPolizas.RowHeadersWidth = 62;
            this.dgvPolizas.RowTemplate.Height = 33;
            this.dgvPolizas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPolizas.Size = new System.Drawing.Size(923, 576);
            this.dgvPolizas.TabIndex = 0;
            this.dgvPolizas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPolizas_CellClick);
            this.dgvPolizas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPolizas_CellDoubleClick);
            this.dgvPolizas.SelectionChanged += new System.EventHandler(this.dgvPolizas_SelectionChanged);
            // 
            // idPolizasDataGridViewTextBoxColumn
            // 
            this.idPolizasDataGridViewTextBoxColumn.DataPropertyName = "IdPolizas";
            this.idPolizasDataGridViewTextBoxColumn.HeaderText = "Poliza";
            this.idPolizasDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idPolizasDataGridViewTextBoxColumn.Name = "idPolizasDataGridViewTextBoxColumn";
            this.idPolizasDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPolizasDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreSKUDataGridViewTextBoxColumn
            // 
            this.nombreSKUDataGridViewTextBoxColumn.DataPropertyName = "NombreSKU";
            this.nombreSKUDataGridViewTextBoxColumn.HeaderText = "SKU";
            this.nombreSKUDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nombreSKUDataGridViewTextBoxColumn.Name = "nombreSKUDataGridViewTextBoxColumn";
            this.nombreSKUDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreSKUDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreEmpleadoDataGridViewTextBoxColumn
            // 
            this.nombreEmpleadoDataGridViewTextBoxColumn.DataPropertyName = "NombreEmpleado";
            this.nombreEmpleadoDataGridViewTextBoxColumn.HeaderText = "Empleado";
            this.nombreEmpleadoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nombreEmpleadoDataGridViewTextBoxColumn.Name = "nombreEmpleadoDataGridViewTextBoxColumn";
            this.nombreEmpleadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreEmpleadoDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreClienteDataGridViewTextBoxColumn
            // 
            this.nombreClienteDataGridViewTextBoxColumn.DataPropertyName = "NombreCliente";
            this.nombreClienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.nombreClienteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nombreClienteDataGridViewTextBoxColumn.Name = "nombreClienteDataGridViewTextBoxColumn";
            this.nombreClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreClienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 150;
            // 
            // sKUDataGridViewTextBoxColumn
            // 
            this.sKUDataGridViewTextBoxColumn.DataPropertyName = "SKU";
            this.sKUDataGridViewTextBoxColumn.HeaderText = "SKU";
            this.sKUDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sKUDataGridViewTextBoxColumn.Name = "sKUDataGridViewTextBoxColumn";
            this.sKUDataGridViewTextBoxColumn.ReadOnly = true;
            this.sKUDataGridViewTextBoxColumn.Visible = false;
            this.sKUDataGridViewTextBoxColumn.Width = 150;
            // 
            // empleadoGeneroDataGridViewTextBoxColumn
            // 
            this.empleadoGeneroDataGridViewTextBoxColumn.DataPropertyName = "EmpleadoGenero";
            this.empleadoGeneroDataGridViewTextBoxColumn.HeaderText = "EmpleadoGenero";
            this.empleadoGeneroDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.empleadoGeneroDataGridViewTextBoxColumn.Name = "empleadoGeneroDataGridViewTextBoxColumn";
            this.empleadoGeneroDataGridViewTextBoxColumn.ReadOnly = true;
            this.empleadoGeneroDataGridViewTextBoxColumn.Visible = false;
            this.empleadoGeneroDataGridViewTextBoxColumn.Width = 150;
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteDataGridViewTextBoxColumn.Visible = false;
            this.idClienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 150;
            // 
            // gridPolizasBindingSource
            // 
            this.gridPolizasBindingSource.DataSource = typeof(CRUD.Modelos.GridPolizas);
            // 
            // FrmPolizasBuscador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 692);
            this.ControlBox = false;
            this.Controls.Add(this.gbLogin);
            this.Name = "FrmPolizasBuscador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polizas (Buscador)";
            this.Load += new System.EventHandler(this.FrmPolizasBuscador_Load);
            this.gbLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolizas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPolizasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbLogin;
        private Button btnSalir;
        private Button btnSeleccionar;
        private DataGridView dgvPolizas;
        private BindingSource gridPolizasBindingSource;
        private DataGridViewTextBoxColumn idPolizasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreSKUDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreEmpleadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreClienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sKUDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn empleadoGeneroDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
    }
}