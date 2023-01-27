namespace CRUD.Vistas
{
    partial class FrmPolizas
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
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.dgvPolizas = new System.Windows.Forms.DataGridView();
            this.dgvColumnInventario = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColumnEmpleado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColumnCliente = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColumnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.gbCatalogos = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolizas)).BeginInit();
            this.gbCatalogos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleado.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEmpleado.Location = new System.Drawing.Point(171, 30);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(150, 50);
            this.btnEmpleado.TabIndex = 1;
            this.btnEmpleado.Text = "[F2] Empleado";
            this.btnEmpleado.UseVisualStyleBackColor = false;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInventario.Location = new System.Drawing.Point(15, 30);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(150, 50);
            this.btnInventario.TabIndex = 0;
            this.btnInventario.Text = "[F1] Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // dgvPolizas
            // 
            this.dgvPolizas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPolizas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPolizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPolizas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnInventario,
            this.dgvColumnEmpleado,
            this.dgvColumnCliente,
            this.dgvColumnCantidad});
            this.dgvPolizas.Location = new System.Drawing.Point(12, 116);
            this.dgvPolizas.Name = "dgvPolizas";
            this.dgvPolizas.RowHeadersVisible = false;
            this.dgvPolizas.RowHeadersWidth = 62;
            this.dgvPolizas.RowTemplate.Height = 33;
            this.dgvPolizas.Size = new System.Drawing.Size(1202, 564);
            this.dgvPolizas.TabIndex = 3;
            this.dgvPolizas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPolizas_EditingControlShowing);
            // 
            // dgvColumnInventario
            // 
            this.dgvColumnInventario.Frozen = true;
            this.dgvColumnInventario.HeaderText = "Artículo";
            this.dgvColumnInventario.MinimumWidth = 8;
            this.dgvColumnInventario.Name = "dgvColumnInventario";
            this.dgvColumnInventario.Width = 300;
            // 
            // dgvColumnEmpleado
            // 
            this.dgvColumnEmpleado.Frozen = true;
            this.dgvColumnEmpleado.HeaderText = "Empleado";
            this.dgvColumnEmpleado.MinimumWidth = 8;
            this.dgvColumnEmpleado.Name = "dgvColumnEmpleado";
            this.dgvColumnEmpleado.Width = 350;
            // 
            // dgvColumnCliente
            // 
            this.dgvColumnCliente.Frozen = true;
            this.dgvColumnCliente.HeaderText = "Cliente";
            this.dgvColumnCliente.MinimumWidth = 8;
            this.dgvColumnCliente.Name = "dgvColumnCliente";
            this.dgvColumnCliente.Width = 350;
            // 
            // dgvColumnCantidad
            // 
            this.dgvColumnCantidad.Frozen = true;
            this.dgvColumnCantidad.HeaderText = "Cantidad";
            this.dgvColumnCantidad.MinimumWidth = 8;
            this.dgvColumnCantidad.Name = "dgvColumnCantidad";
            this.dgvColumnCantidad.Width = 160;
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCliente.Location = new System.Drawing.Point(327, 30);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(150, 50);
            this.btnCliente.TabIndex = 2;
            this.btnCliente.Text = "[F3] Cliente";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(327, 30);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 50);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "[F6] Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEditar.Location = new System.Drawing.Point(171, 30);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 50);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "[F5] Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGenerar.Location = new System.Drawing.Point(15, 30);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(150, 50);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "[F4] Generar";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // gbCatalogos
            // 
            this.gbCatalogos.Controls.Add(this.btnEmpleado);
            this.gbCatalogos.Controls.Add(this.btnInventario);
            this.gbCatalogos.Controls.Add(this.btnCliente);
            this.gbCatalogos.Location = new System.Drawing.Point(12, 12);
            this.gbCatalogos.Name = "gbCatalogos";
            this.gbCatalogos.Size = new System.Drawing.Size(490, 98);
            this.gbCatalogos.TabIndex = 0;
            this.gbCatalogos.TabStop = false;
            this.gbCatalogos.Text = "Catalogos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGenerar);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Location = new System.Drawing.Point(513, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 98);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operaciones Polizas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Location = new System.Drawing.Point(1018, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 98);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSalir.Location = new System.Drawing.Point(24, 30);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(150, 50);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "[Esc] Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmPolizas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 692);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbCatalogos);
            this.Controls.Add(this.dgvPolizas);
            this.Name = "FrmPolizas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polizas";
            this.Load += new System.EventHandler(this.FrmPolizas_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolizas)).EndInit();
            this.gbCatalogos.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnEmpleado;
        private Button btnInventario;
        private DataGridView dgvPolizas;
        private Button btnCliente;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGenerar;
        private GroupBox gbCatalogos;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button btnSalir;
        private DataGridViewComboBoxColumn dgvColumnInventario;
        private DataGridViewComboBoxColumn dgvColumnEmpleado;
        private DataGridViewComboBoxColumn dgvColumnCliente;
        private DataGridViewTextBoxColumn dgvColumnCantidad;
    }
}