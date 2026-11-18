namespace Buddy.Views
{
    partial class FrmActualizarUsuario
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
            lblSeleccionarUsuario = new Label();
            cmbUsuarios = new ComboBox();
            lblNombre = new Label();
            lblNombreUsuario = new Label();
            lblCorreo = new Label();
            lblFechaNacimiento = new Label();
            lblPeso = new Label();
            lblAltura = new Label();
            txtNombre = new TextBox();
            txtNombreUsuario = new TextBox();
            txtCorreo = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            nudPesoKg = new NumericUpDown();
            nudAlturaMetros = new NumericUpDown();
            lblIMCTitulo = new Label();
            lblIMC = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPesoKg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAlturaMetros).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(150, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(257, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Actualización de Usuarios";
            //
            // lblSeleccionarUsuario
            //
            lblSeleccionarUsuario.AutoSize = true;
            lblSeleccionarUsuario.Location = new Point(40, 80);
            lblSeleccionarUsuario.Name = "lblSeleccionarUsuario";
            lblSeleccionarUsuario.Size = new Size(127, 15);
            lblSeleccionarUsuario.TabIndex = 1;
            lblSeleccionarUsuario.Text = "Seleccione un usuario:";
            //
            // cmbUsuarios
            //
            cmbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarios.FormattingEnabled = true;
            cmbUsuarios.Location = new Point(200, 77);
            cmbUsuarios.Name = "cmbUsuarios";
            cmbUsuarios.Size = new Size(300, 23);
            cmbUsuarios.TabIndex = 2;
            cmbUsuarios.SelectedIndexChanged += cmbUsuarios_SelectedIndexChanged;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(40, 128);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(104, 15);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre completo:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(200, 125);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 23);
            txtNombre.TabIndex = 4;
            //
            // lblNombreUsuario
            //
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(40, 166);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(110, 15);
            lblNombreUsuario.TabIndex = 5;
            lblNombreUsuario.Text = "Nombre de usuario:";
            //
            // txtNombreUsuario
            //
            txtNombreUsuario.Location = new Point(200, 163);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(300, 23);
            txtNombreUsuario.TabIndex = 6;
            //
            // lblCorreo
            //
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(40, 204);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(108, 15);
            lblCorreo.TabIndex = 7;
            lblCorreo.Text = "Correo electrónico:";
            //
            // txtCorreo
            //
            txtCorreo.Location = new Point(200, 201);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(300, 23);
            txtCorreo.TabIndex = 8;
            //
            // lblFechaNacimiento
            //
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(40, 242);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(120, 15);
            lblFechaNacimiento.TabIndex = 9;
            lblFechaNacimiento.Text = "Fecha de nacimiento:";
            //
            // dtpFechaNacimiento
            //
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(200, 239);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(150, 23);
            dtpFechaNacimiento.TabIndex = 10;
            //
            // lblPeso
            //
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(40, 280);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(59, 15);
            lblPeso.TabIndex = 11;
            lblPeso.Text = "Peso (kg):";
            //
            // nudPesoKg
            //
            nudPesoKg.DecimalPlaces = 2;
            nudPesoKg.Location = new Point(200, 277);
            nudPesoKg.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudPesoKg.Name = "nudPesoKg";
            nudPesoKg.Size = new Size(150, 23);
            nudPesoKg.TabIndex = 12;
            nudPesoKg.ValueChanged += nudDatosFisicos_ValueChanged;
            //
            // lblAltura
            //
            lblAltura.AutoSize = true;
            lblAltura.Location = new Point(40, 318);
            lblAltura.Name = "lblAltura";
            lblAltura.Size = new Size(64, 15);
            lblAltura.TabIndex = 13;
            lblAltura.Text = "Altura (m):";
            //
            // nudAlturaMetros
            //
            nudAlturaMetros.DecimalPlaces = 2;
            nudAlturaMetros.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudAlturaMetros.Location = new Point(200, 315);
            nudAlturaMetros.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            nudAlturaMetros.Name = "nudAlturaMetros";
            nudAlturaMetros.Size = new Size(150, 23);
            nudAlturaMetros.TabIndex = 14;
            nudAlturaMetros.ValueChanged += nudDatosFisicos_ValueChanged;
            //
            // lblIMCTitulo
            //
            lblIMCTitulo.AutoSize = true;
            lblIMCTitulo.Location = new Point(40, 356);
            lblIMCTitulo.Name = "lblIMCTitulo";
            lblIMCTitulo.Size = new Size(85, 15);
            lblIMCTitulo.TabIndex = 15;
            lblIMCTitulo.Text = "IMC calculado:";
            //
            // lblIMC
            //
            lblIMC.AutoSize = true;
            lblIMC.Location = new Point(200, 356);
            lblIMC.Name = "lblIMC";
            lblIMC.Size = new Size(19, 15);
            lblIMC.TabIndex = 16;
            lblIMC.Text = "—";
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(200, 390);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 32);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(360, 390);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 32);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            //
            // FrmActualizarUsuario
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(560, 445);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblIMC);
            Controls.Add(lblIMCTitulo);
            Controls.Add(nudAlturaMetros);
            Controls.Add(lblAltura);
            Controls.Add(nudPesoKg);
            Controls.Add(lblPeso);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(txtCorreo);
            Controls.Add(lblCorreo);
            Controls.Add(txtNombreUsuario);
            Controls.Add(lblNombreUsuario);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(cmbUsuarios);
            Controls.Add(lblSeleccionarUsuario);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmActualizarUsuario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buddy - Actualizar usuario";
            Load += FrmActualizarUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)nudPesoKg).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAlturaMetros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSeleccionarUsuario;
        private ComboBox cmbUsuarios;
        private Label lblNombre;
        private Label lblNombreUsuario;
        private Label lblCorreo;
        private Label lblFechaNacimiento;
        private Label lblPeso;
        private Label lblAltura;
        private TextBox txtNombre;
        private TextBox txtNombreUsuario;
        private TextBox txtCorreo;
        private DateTimePicker dtpFechaNacimiento;
        private NumericUpDown nudPesoKg;
        private NumericUpDown nudAlturaMetros;
        private Label lblIMCTitulo;
        private Label lblIMC;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
