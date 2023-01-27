namespace CRUD.Vistas
{
    partial class FrmPolizasEditar
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
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.empleadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblArticulo = new System.Windows.Forms.Label();
            this.cmbInventario = new System.Windows.Forms.ComboBox();
            this.inventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.btnOperacion = new System.Windows.Forms.Button();
            this.txtIdPoliza = new System.Windows.Forms.TextBox();
            this.lblIdPoliza = new System.Windows.Forms.Label();
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.cmbEmpleado);
            this.gbLogin.Controls.Add(this.lblArticulo);
            this.gbLogin.Controls.Add(this.cmbInventario);
            this.gbLogin.Controls.Add(this.btnSalir);
            this.gbLogin.Controls.Add(this.cmbCliente);
            this.gbLogin.Controls.Add(this.txtCantidad);
            this.gbLogin.Controls.Add(this.lblCantidad);
            this.gbLogin.Controls.Add(this.label2);
            this.gbLogin.Controls.Add(this.lblEmpleado);
            this.gbLogin.Controls.Add(this.btnOperacion);
            this.gbLogin.Controls.Add(this.txtIdPoliza);
            this.gbLogin.Controls.Add(this.lblIdPoliza);
            this.gbLogin.Location = new System.Drawing.Point(363, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(500, 668);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.DataSource = this.empleadoBindingSource;
            this.cmbEmpleado.DisplayMember = "Nombre";
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(110, 241);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(298, 33);
            this.cmbEmpleado.TabIndex = 5;
            this.cmbEmpleado.ValueMember = "IdEmpleado";
            // 
            // empleadoBindingSource
            // 
            this.empleadoBindingSource.DataSource = typeof(CRUD.Modelos.Empleado);
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Location = new System.Drawing.Point(110, 149);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(73, 25);
            this.lblArticulo.TabIndex = 2;
            this.lblArticulo.Text = "Artículo";
            // 
            // cmbInventario
            // 
            this.cmbInventario.DataSource = this.inventarioBindingSource;
            this.cmbInventario.DisplayMember = "Nombre";
            this.cmbInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventario.FormattingEnabled = true;
            this.cmbInventario.Location = new System.Drawing.Point(110, 177);
            this.cmbInventario.Name = "cmbInventario";
            this.cmbInventario.Size = new System.Drawing.Size(298, 33);
            this.cmbInventario.TabIndex = 3;
            this.cmbInventario.ValueMember = "SKU";
            // 
            // inventarioBindingSource
            // 
            this.inventarioBindingSource.DataSource = typeof(CRUD.Modelos.Inventario);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSalir.Location = new System.Drawing.Point(110, 563);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(298, 50);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "[Esc] Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.DataSource = this.clienteBindingSource;
            this.cmbCliente.DisplayMember = "Nombre";
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(110, 305);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(298, 33);
            this.cmbCliente.TabIndex = 7;
            this.cmbCliente.ValueMember = "IdCliente";
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataSource = typeof(CRUD.Modelos.Cliente);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(110, 369);
            this.txtCantidad.MaxLength = 10;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(298, 31);
            this.txtCantidad.TabIndex = 9;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(110, 341);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(83, 25);
            this.lblCantidad.TabIndex = 8;
            this.lblCantidad.Text = "Cantidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cliente";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(110, 213);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(92, 25);
            this.lblEmpleado.TabIndex = 4;
            this.lblEmpleado.Text = "Empleado";
            // 
            // btnOperacion
            // 
            this.btnOperacion.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperacion.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOperacion.Location = new System.Drawing.Point(110, 507);
            this.btnOperacion.Name = "btnOperacion";
            this.btnOperacion.Size = new System.Drawing.Size(298, 50);
            this.btnOperacion.TabIndex = 10;
            this.btnOperacion.Text = "[F5] Actualizar";
            this.btnOperacion.UseVisualStyleBackColor = false;
            this.btnOperacion.Click += new System.EventHandler(this.btnOperacion_Click);
            // 
            // txtIdPoliza
            // 
            this.txtIdPoliza.Location = new System.Drawing.Point(110, 115);
            this.txtIdPoliza.MaxLength = 10;
            this.txtIdPoliza.Name = "txtIdPoliza";
            this.txtIdPoliza.ReadOnly = true;
            this.txtIdPoliza.Size = new System.Drawing.Size(298, 31);
            this.txtIdPoliza.TabIndex = 1;
            // 
            // lblIdPoliza
            // 
            this.lblIdPoliza.AutoSize = true;
            this.lblIdPoliza.Location = new System.Drawing.Point(110, 87);
            this.lblIdPoliza.Name = "lblIdPoliza";
            this.lblIdPoliza.Size = new System.Drawing.Size(80, 25);
            this.lblIdPoliza.TabIndex = 0;
            this.lblIdPoliza.Text = "ID Poliza";
            // 
            // FrmPolizasEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 692);
            this.ControlBox = false;
            this.Controls.Add(this.gbLogin);
            this.Name = "FrmPolizasEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polizas (Editar)";
            this.Load += new System.EventHandler(this.FrmPolizasEditar_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbLogin;
        private ComboBox cmbEmpleado;
        private ComboBox cmbInventario;
        private Button btnSalir;
        private ComboBox cmbCliente;
        private TextBox txtCantidad;
        private Label lblCantidad;
        private Label label2;
        private Label lblEmpleado;
        private Button btnOperacion;
        private Label lblArticulo;
        private TextBox txtIdPoliza;
        private Label lblIdPoliza;
        private BindingSource empleadoBindingSource;
        private BindingSource inventarioBindingSource;
        private BindingSource clienteBindingSource;
    }
}