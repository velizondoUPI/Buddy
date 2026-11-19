namespace Buddy.Views
{
    partial class FrmRegistroEntrenador
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
            grpDatosPersonales = new GroupBox();
            lblIdentificacion = new Label();
            txtIdentificacion = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPrimerApellido = new Label();
            txtPrimerApellido = new TextBox();
            lblSegundoApellido = new Label();
            txtSegundoApellido = new TextBox();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            grpAcceso = new GroupBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            lblConfirmarContrasena = new Label();
            txtConfirmarContrasena = new TextBox();
            grpDatosProfesionales = new GroupBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblEspecialidad = new Label();
            cmbEspecialidad = new ComboBox();
            lblAniosExperiencia = new Label();
            nudAniosExperiencia = new NumericUpDown();
            lblCertificaciones = new Label();
            txtCertificaciones = new TextBox();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            lblCamposObligatorios = new Label();
            grpDatosPersonales.SuspendLayout();
            grpAcceso.SuspendLayout();
            grpDatosProfesionales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAniosExperiencia).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(180, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(258, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Entrenadores";
            //
            // grpDatosPersonales
            //
            grpDatosPersonales.Controls.Add(lblIdentificacion);
            grpDatosPersonales.Controls.Add(txtIdentificacion);
            grpDatosPersonales.Controls.Add(lblNombre);
            grpDatosPersonales.Controls.Add(txtNombre);
            grpDatosPersonales.Controls.Add(lblPrimerApellido);
            grpDatosPersonales.Controls.Add(txtPrimerApellido);
            grpDatosPersonales.Controls.Add(lblSegundoApellido);
            grpDatosPersonales.Controls.Add(txtSegundoApellido);
            grpDatosPersonales.Controls.Add(lblFechaNacimiento);
            grpDatosPersonales.Controls.Add(dtpFechaNacimiento);
            grpDatosPersonales.Controls.Add(lblTelefono);
            grpDatosPersonales.Controls.Add(txtTelefono);
            grpDatosPersonales.Location = new Point(20, 55);
            grpDatosPersonales.Name = "grpDatosPersonales";
            grpDatosPersonales.Size = new Size(580, 225);
            grpDatosPersonales.TabIndex = 1;
            grpDatosPersonales.TabStop = false;
            grpDatosPersonales.Text = "Datos personales";
            //
            // lblIdentificacion
            //
            lblIdentificacion.AutoSize = true;
            lblIdentificacion.Location = new Point(15, 31);
            lblIdentificacion.Name = "lblIdentificacion";
            lblIdentificacion.Size = new Size(87, 15);
            lblIdentificacion.TabIndex = 0;
            lblIdentificacion.Text = "Identificación: *";
            //
            // txtIdentificacion
            //
            txtIdentificacion.Location = new Point(170, 28);
            txtIdentificacion.MaxLength = 20;
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(380, 23);
            txtIdentificacion.TabIndex = 1;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(15, 63);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(62, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre: *";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(170, 60);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(380, 23);
            txtNombre.TabIndex = 3;
            //
            // lblPrimerApellido
            //
            lblPrimerApellido.AutoSize = true;
            lblPrimerApellido.Location = new Point(15, 95);
            lblPrimerApellido.Name = "lblPrimerApellido";
            lblPrimerApellido.Size = new Size(99, 15);
            lblPrimerApellido.TabIndex = 4;
            lblPrimerApellido.Text = "Primer apellido: *";
            //
            // txtPrimerApellido
            //
            txtPrimerApellido.Location = new Point(170, 92);
            txtPrimerApellido.MaxLength = 60;
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(380, 23);
            txtPrimerApellido.TabIndex = 5;
            //
            // lblSegundoApellido
            //
            lblSegundoApellido.AutoSize = true;
            lblSegundoApellido.Location = new Point(15, 127);
            lblSegundoApellido.Name = "lblSegundoApellido";
            lblSegundoApellido.Size = new Size(150, 15);
            lblSegundoApellido.TabIndex = 6;
            lblSegundoApellido.Text = "Segundo apellido (opcional):";
            //
            // txtSegundoApellido
            //
            txtSegundoApellido.Location = new Point(170, 124);
            txtSegundoApellido.MaxLength = 60;
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(380, 23);
            txtSegundoApellido.TabIndex = 7;
            //
            // lblFechaNacimiento
            //
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(15, 159);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(129, 15);
            lblFechaNacimiento.TabIndex = 8;
            lblFechaNacimiento.Text = "Fecha de nacimiento: *";
            //
            // dtpFechaNacimiento
            //
            dtpFechaNacimiento.Checked = false;
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(170, 156);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.ShowCheckBox = true;
            dtpFechaNacimiento.Size = new Size(160, 23);
            dtpFechaNacimiento.TabIndex = 9;
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(15, 191);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(64, 15);
            lblTelefono.TabIndex = 10;
            lblTelefono.Text = "Teléfono: *";
            //
            // txtTelefono
            //
            txtTelefono.Location = new Point(170, 188);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "8888-1234 o +506 8888-1234";
            txtTelefono.Size = new Size(380, 23);
            txtTelefono.TabIndex = 11;
            //
            // grpAcceso
            //
            grpAcceso.Controls.Add(lblCorreo);
            grpAcceso.Controls.Add(txtCorreo);
            grpAcceso.Controls.Add(lblNombreUsuario);
            grpAcceso.Controls.Add(txtNombreUsuario);
            grpAcceso.Controls.Add(lblContrasena);
            grpAcceso.Controls.Add(txtContrasena);
            grpAcceso.Controls.Add(lblConfirmarContrasena);
            grpAcceso.Controls.Add(txtConfirmarContrasena);
            grpAcceso.Location = new Point(20, 290);
            grpAcceso.Name = "grpAcceso";
            grpAcceso.Size = new Size(580, 160);
            grpAcceso.TabIndex = 2;
            grpAcceso.TabStop = false;
            grpAcceso.Text = "Datos de acceso";
            //
            // lblCorreo
            //
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(15, 31);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(116, 15);
            lblCorreo.TabIndex = 0;
            lblCorreo.Text = "Correo electrónico: *";
            //
            // txtCorreo
            //
            txtCorreo.Location = new Point(170, 28);
            txtCorreo.MaxLength = 100;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(380, 23);
            txtCorreo.TabIndex = 1;
            //
            // lblNombreUsuario
            //
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(15, 63);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(118, 15);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "Nombre de usuario: *";
            //
            // txtNombreUsuario
            //
            txtNombreUsuario.Location = new Point(170, 60);
            txtNombreUsuario.MaxLength = 30;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(380, 23);
            txtNombreUsuario.TabIndex = 3;
            //
            // lblContrasena
            //
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(15, 95);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(78, 15);
            lblContrasena.TabIndex = 4;
            lblContrasena.Text = "Contraseña: *";
            //
            // txtContrasena
            //
            txtContrasena.Location = new Point(170, 92);
            txtContrasena.MaxLength = 100;
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PlaceholderText = "Mínimo 8 caracteres";
            txtContrasena.Size = new Size(380, 23);
            txtContrasena.TabIndex = 5;
            txtContrasena.UseSystemPasswordChar = true;
            //
            // lblConfirmarContrasena
            //
            lblConfirmarContrasena.AutoSize = true;
            lblConfirmarContrasena.Location = new Point(15, 127);
            lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            lblConfirmarContrasena.Size = new Size(134, 15);
            lblConfirmarContrasena.TabIndex = 6;
            lblConfirmarContrasena.Text = "Confirmar contraseña: *";
            //
            // txtConfirmarContrasena
            //
            txtConfirmarContrasena.Location = new Point(170, 124);
            txtConfirmarContrasena.MaxLength = 100;
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.Size = new Size(380, 23);
            txtConfirmarContrasena.TabIndex = 7;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            //
            // grpDatosProfesionales
            //
            grpDatosProfesionales.Controls.Add(lblTipo);
            grpDatosProfesionales.Controls.Add(cmbTipo);
            grpDatosProfesionales.Controls.Add(lblEspecialidad);
            grpDatosProfesionales.Controls.Add(cmbEspecialidad);
            grpDatosProfesionales.Controls.Add(lblAniosExperiencia);
            grpDatosProfesionales.Controls.Add(nudAniosExperiencia);
            grpDatosProfesionales.Controls.Add(lblCertificaciones);
            grpDatosProfesionales.Controls.Add(txtCertificaciones);
            grpDatosProfesionales.Location = new Point(20, 460);
            grpDatosProfesionales.Name = "grpDatosProfesionales";
            grpDatosProfesionales.Size = new Size(580, 160);
            grpDatosProfesionales.TabIndex = 3;
            grpDatosProfesionales.TabStop = false;
            grpDatosProfesionales.Text = "Datos profesionales";
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(15, 31);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(115, 15);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de entrenador: *";
            //
            // cmbTipo
            //
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(170, 28);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(380, 23);
            cmbTipo.TabIndex = 1;
            //
            // lblEspecialidad
            //
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new Point(15, 63);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(82, 15);
            lblEspecialidad.TabIndex = 2;
            lblEspecialidad.Text = "Especialidad: *";
            //
            // cmbEspecialidad
            //
            cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecialidad.FormattingEnabled = true;
            cmbEspecialidad.Location = new Point(170, 60);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(380, 23);
            cmbEspecialidad.TabIndex = 3;
            //
            // lblAniosExperiencia
            //
            lblAniosExperiencia.AutoSize = true;
            lblAniosExperiencia.Location = new Point(15, 95);
            lblAniosExperiencia.Name = "lblAniosExperiencia";
            lblAniosExperiencia.Size = new Size(126, 15);
            lblAniosExperiencia.TabIndex = 4;
            lblAniosExperiencia.Text = "Años de experiencia: *";
            //
            // nudAniosExperiencia
            //
            nudAniosExperiencia.Location = new Point(170, 92);
            nudAniosExperiencia.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nudAniosExperiencia.Name = "nudAniosExperiencia";
            nudAniosExperiencia.Size = new Size(100, 23);
            nudAniosExperiencia.TabIndex = 5;
            //
            // lblCertificaciones
            //
            lblCertificaciones.AutoSize = true;
            lblCertificaciones.Location = new Point(15, 127);
            lblCertificaciones.Name = "lblCertificaciones";
            lblCertificaciones.Size = new Size(144, 15);
            lblCertificaciones.TabIndex = 6;
            lblCertificaciones.Text = "Certificaciones (opcional):";
            //
            // txtCertificaciones
            //
            txtCertificaciones.Location = new Point(170, 124);
            txtCertificaciones.MaxLength = 200;
            txtCertificaciones.Name = "txtCertificaciones";
            txtCertificaciones.Size = new Size(380, 23);
            txtCertificaciones.TabIndex = 7;
            //
            // btnRegistrar
            //
            btnRegistrar.Location = new Point(190, 632);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(170, 32);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "Registrar entrenador";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Location = new Point(380, 632);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 32);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // lblCamposObligatorios
            //
            lblCamposObligatorios.AutoSize = true;
            lblCamposObligatorios.ForeColor = SystemColors.GrayText;
            lblCamposObligatorios.Location = new Point(20, 641);
            lblCamposObligatorios.Name = "lblCamposObligatorios";
            lblCamposObligatorios.Size = new Size(125, 15);
            lblCamposObligatorios.TabIndex = 6;
            lblCamposObligatorios.Text = "* Campos obligatorios";
            //
            // FrmRegistroEntrenador
            //
            AcceptButton = btnRegistrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 680);
            Controls.Add(lblCamposObligatorios);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrar);
            Controls.Add(grpDatosProfesionales);
            Controls.Add(grpAcceso);
            Controls.Add(grpDatosPersonales);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistroEntrenador";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buddy - Registro de entrenadores";
            Load += FrmRegistroEntrenador_Load;
            grpDatosPersonales.ResumeLayout(false);
            grpDatosPersonales.PerformLayout();
            grpAcceso.ResumeLayout(false);
            grpAcceso.PerformLayout();
            grpDatosProfesionales.ResumeLayout(false);
            grpDatosProfesionales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAniosExperiencia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private GroupBox grpDatosPersonales;
        private Label lblIdentificacion;
        private TextBox txtIdentificacion;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPrimerApellido;
        private TextBox txtPrimerApellido;
        private Label lblSegundoApellido;
        private TextBox txtSegundoApellido;
        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private GroupBox grpAcceso;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblNombreUsuario;
        private TextBox txtNombreUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Label lblConfirmarContrasena;
        private TextBox txtConfirmarContrasena;
        private GroupBox grpDatosProfesionales;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblEspecialidad;
        private ComboBox cmbEspecialidad;
        private Label lblAniosExperiencia;
        private NumericUpDown nudAniosExperiencia;
        private Label lblCertificaciones;
        private TextBox txtCertificaciones;
        private Button btnRegistrar;
        private Button btnLimpiar;
        private Label lblCamposObligatorios;
    }
}
