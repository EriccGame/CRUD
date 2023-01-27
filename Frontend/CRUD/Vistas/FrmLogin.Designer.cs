namespace CRUD.Vistas
{
    partial class FrmLogin
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
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnAltaEmeplado = new System.Windows.Forms.Button();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtIdEmpleado = new System.Windows.Forms.TextBox();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnAltaEmeplado);
            this.gbLogin.Controls.Add(this.btnIniciarSesion);
            this.gbLogin.Controls.Add(this.txtContraseña);
            this.gbLogin.Controls.Add(this.lblContraseña);
            this.gbLogin.Controls.Add(this.txtIdEmpleado);
            this.gbLogin.Controls.Add(this.lblIdEmpleado);
            this.gbLogin.Location = new System.Drawing.Point(363, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(500, 668);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            // 
            // btnAltaEmeplado
            // 
            this.btnAltaEmeplado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaEmeplado.Location = new System.Drawing.Point(110, 408);
            this.btnAltaEmeplado.Name = "btnAltaEmeplado";
            this.btnAltaEmeplado.Size = new System.Drawing.Size(298, 50);
            this.btnAltaEmeplado.TabIndex = 5;
            this.btnAltaEmeplado.Text = "Registrar Empleado";
            this.btnAltaEmeplado.UseVisualStyleBackColor = true;
            this.btnAltaEmeplado.Click += new System.EventHandler(this.btnAltaEmpleado_Click);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIniciarSesion.Location = new System.Drawing.Point(110, 352);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(298, 50);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(110, 285);
            this.txtContraseña.MaxLength = 20;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(298, 31);
            this.txtContraseña.TabIndex = 3;
            this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseña_KeyPress);
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(110, 257);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(101, 25);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "Contraseña";
            // 
            // txtIdEmpleado
            // 
            this.txtIdEmpleado.Location = new System.Drawing.Point(110, 223);
            this.txtIdEmpleado.MaxLength = 8;
            this.txtIdEmpleado.Name = "txtIdEmpleado";
            this.txtIdEmpleado.Size = new System.Drawing.Size(298, 31);
            this.txtIdEmpleado.TabIndex = 1;
            this.txtIdEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdEmpleado_KeyPress);
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.Location = new System.Drawing.Point(110, 195);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(115, 25);
            this.lblIdEmpleado.TabIndex = 0;
            this.lblIdEmpleado.Text = "ID Empleado";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 692);
            this.ControlBox = false;
            this.Controls.Add(this.gbLogin);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso Empleado";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbLogin;
        private Button btnAltaEmeplado;
        private Button btnIniciarSesion;
        private TextBox txtContraseña;
        private Label lblContraseña;
        private TextBox txtIdEmpleado;
        private Label lblIdEmpleado;
    }
}