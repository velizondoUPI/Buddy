namespace Buddy.Views
{
    partial class FrmRegistroUsuario
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
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            lblFechaNacimiento = new Label();
            lblPeso = new Label();
            nudPesoKg = new NumericUpDown();
            lblAltura = new Label();
            nudAlturaMetros = new NumericUpDown();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            label1 = new Label();
            txtCorreoElectronico = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudPesoKg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAlturaMetros).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(191, 34);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(250, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Usuarios";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F);
            lblNombre.Location = new Point(43, 103);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(123, 19);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre completo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(186, 99);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(255, 23);
            txtNombre.TabIndex = 2;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 10F);
            lblNombreUsuario.Location = new Point(43, 193);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(130, 19);
            lblNombreUsuario.TabIndex = 3;
            lblNombreUsuario.Text = "Nombre de usuario:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(186, 189);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(255, 23);
            txtNombreUsuario.TabIndex = 4;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CalendarFont = new Font("Segoe UI", 10F);
            dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.Location = new Point(186, 237);
            dtpFechaNacimiento.MaxDate = new DateTime(2026, 11, 4, 0, 0, 0, 0);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(250, 23);
            dtpFechaNacimiento.TabIndex = 5;
            dtpFechaNacimiento.Value = new DateTime(2026, 11, 4, 0, 0, 0, 0);
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Font = new Font("Segoe UI", 10F);
            lblFechaNacimiento.Location = new Point(43, 241);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(137, 19);
            lblFechaNacimiento.TabIndex = 7;
            lblFechaNacimiento.Text = "Fecha de nacimiento:";
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Segoe UI", 10F);
            lblPeso.Location = new Point(43, 282);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(67, 19);
            lblPeso.TabIndex = 8;
            lblPeso.Text = "Peso (kg):";
            // 
            // nudPesoKg
            // 
            nudPesoKg.DecimalPlaces = 2;
            nudPesoKg.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudPesoKg.Location = new Point(186, 282);
            nudPesoKg.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudPesoKg.Name = "nudPesoKg";
            nudPesoKg.Size = new Size(250, 23);
            nudPesoKg.TabIndex = 9;
            // 
            // lblAltura
            // 
            lblAltura.AutoSize = true;
            lblAltura.Location = new Point(43, 324);
            lblAltura.Name = "lblAltura";
            lblAltura.Size = new Size(64, 15);
            lblAltura.TabIndex = 10;
            lblAltura.Text = "Altura (m):";
            // 
            // nudAlturaMetros
            // 
            nudAlturaMetros.DecimalPlaces = 2;
            nudAlturaMetros.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudAlturaMetros.Location = new Point(186, 324);
            nudAlturaMetros.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            nudAlturaMetros.Name = "nudAlturaMetros";
            nudAlturaMetros.Size = new Size(255, 23);
            nudAlturaMetros.TabIndex = 11;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(166, 386);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(125, 23);
            btnRegistrar.TabIndex = 12;
            btnRegistrar.Text = "Registrar usuario";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(332, 386);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(125, 23);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(43, 149);
            label1.Name = "label1";
            label1.Size = new Size(124, 19);
            label1.TabIndex = 14;
            label1.Text = "Correo electrónico:";
            // 
            // txtCorreoElectronico
            // 
            txtCorreoElectronico.Location = new Point(186, 149);
            txtCorreoElectronico.Name = "txtCorreoElectronico";
            txtCorreoElectronico.Size = new Size(255, 23);
            txtCorreoElectronico.TabIndex = 15;
            // 
            // FrmRegistroUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtCorreoElectronico);
            Controls.Add(label1);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrar);
            Controls.Add(nudAlturaMetros);
            Controls.Add(lblAltura);
            Controls.Add(nudPesoKg);
            Controls.Add(lblPeso);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtNombreUsuario);
            Controls.Add(lblNombreUsuario);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Name = "FrmRegistroUsuario";
            Text = "Buddy - Registro de usuarios";
            ((System.ComponentModel.ISupportInitialize)nudPesoKg).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAlturaMetros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblNombreUsuario;
        private TextBox txtNombreUsuario;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblFechaNacimiento;
        private Label lblPeso;
        private NumericUpDown nudPesoKg;
        private Label lblAltura;
        private NumericUpDown nudAlturaMetros;
        private Button btnRegistrar;
        private Button btnLimpiar;
        private Label label1;
        private TextBox txtCorreoElectronico;
    }
}