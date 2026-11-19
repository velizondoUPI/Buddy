namespace Buddy.Views
{
    partial class FrmActualizarEntrenador
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
            lblSeleccionarEntrenador = new Label();
            cmbEntrenadores = new ComboBox();
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
            lblEdad = new Label();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            grpAcceso = new GroupBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            grpDatosProfesionales = new GroupBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblEspecialidad = new Label();
            cmbEspecialidad = new ComboBox();
            lblAniosExperiencia = new Label();
            nudAniosExperiencia = new NumericUpDown();
            lblCertificaciones = new Label();
            txtCertificaciones = new TextBox();
            grpCuenta = new GroupBox();
            lblRol = new Label();
            lblEstado = new Label();
            lblFechaRegistro = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            grpDatosPersonales.SuspendLayout();
            grpAcceso.SuspendLayout();
            grpDatosProfesionales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAniosExperiencia).BeginInit();
            grpCuenta.SuspendLayout();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(355, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Actualización de Entrenadores";
            //
            // lblSeleccionarEntrenador
            //
            lblSeleccionarEntrenador.AutoSize = true;
            lblSeleccionarEntrenador.Location = new Point(20, 58);
            lblSeleccionarEntrenador.Name = "lblSeleccionarEntrenador";
            lblSeleccionarEntrenador.Size = new Size(147, 15);
            lblSeleccionarEntrenador.TabIndex = 1;
            lblSeleccionarEntrenador.Text = "Seleccione un entrenador:";
            //
            // cmbEntrenadores
            //
            cmbEntrenadores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEntrenadores.FormattingEnabled = true;
            cmbEntrenadores.Location = new Point(185, 55);
            cmbEntrenadores.Name = "cmbEntrenadores";
            cmbEntrenadores.Size = new Size(400, 23);
            cmbEntrenadores.TabIndex = 2;
            cmbEntrenadores.SelectedIndexChanged += cmbEntrenadores_SelectedIndexChanged;
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
            grpDatosPersonales.Controls.Add(lblEdad);
            grpDatosPersonales.Controls.Add(lblTelefono);
            grpDatosPersonales.Controls.Add(txtTelefono);
            grpDatosPersonales.Location = new Point(20, 90);
            grpDatosPersonales.Name = "grpDatosPersonales";
            grpDatosPersonales.Size = new Size(480, 225);
            grpDatosPersonales.TabIndex = 3;
            grpDatosPersonales.TabStop = false;
            grpDatosPersonales.Text = "Datos personales";
            //
            // lblIdentificacion
            //
            lblIdentificacion.AutoSize = true;
            lblIdentificacion.Location = new Point(15, 31);
            lblIdentificacion.Name = "lblIdentificacion";
            lblIdentificacion.Size = new Size(82, 15);
            lblIdentificacion.TabIndex = 0;
            lblIdentificacion.Text = "Identificación:";
            //
            // txtIdentificacion
            //
            txtIdentificacion.Location = new Point(165, 28);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.ReadOnly = true;
            txtIdentificacion.Size = new Size(295, 23);
            txtIdentificacion.TabIndex = 1;
            txtIdentificacion.TabStop = false;
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
            txtNombre.Location = new Point(165, 60);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(295, 23);
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
            txtPrimerApellido.Location = new Point(165, 92);
            txtPrimerApellido.MaxLength = 60;
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(295, 23);
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
            txtSegundoApellido.Location = new Point(165, 124);
            txtSegundoApellido.MaxLength = 60;
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(295, 23);
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
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(165, 156);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(140, 23);
            dtpFechaNacimiento.TabIndex = 9;
            dtpFechaNacimiento.ValueChanged += dtpFechaNacimiento_ValueChanged;
            //
            // lblEdad
            //
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(320, 159);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(55, 15);
            lblEdad.TabIndex = 10;
            lblEdad.Text = "Edad: —";
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(15, 191);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(64, 15);
            lblTelefono.TabIndex = 11;
            lblTelefono.Text = "Teléfono: *";
            //
            // txtTelefono
            //
            txtTelefono.Location = new Point(165, 188);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "8888-1234 o +506 8888-1234";
            txtTelefono.Size = new Size(295, 23);
            txtTelefono.TabIndex = 12;
            //
            // grpAcceso
            //
            grpAcceso.Controls.Add(lblCorreo);
            grpAcceso.Controls.Add(txtCorreo);
            grpAcceso.Controls.Add(lblNombreUsuario);
            grpAcceso.Controls.Add(txtNombreUsuario);
            grpAcceso.Location = new Point(510, 90);
            grpAcceso.Name = "grpAcceso";
            grpAcceso.Size = new Size(480, 95);
            grpAcceso.TabIndex = 4;
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
            txtCorreo.Location = new Point(165, 28);
            txtCorreo.MaxLength = 100;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(295, 23);
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
            txtNombreUsuario.Location = new Point(165, 60);
            txtNombreUsuario.MaxLength = 30;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(295, 23);
            txtNombreUsuario.TabIndex = 3;
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
            grpDatosProfesionales.Location = new Point(510, 195);
            grpDatosProfesionales.Name = "grpDatosProfesionales";
            grpDatosProfesionales.Size = new Size(480, 160);
            grpDatosProfesionales.TabIndex = 5;
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
            cmbTipo.Location = new Point(165, 28);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(295, 23);
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
            cmbEspecialidad.Location = new Point(165, 60);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(295, 23);
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
            nudAniosExperiencia.Location = new Point(165, 92);
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
            txtCertificaciones.Location = new Point(165, 124);
            txtCertificaciones.MaxLength = 200;
            txtCertificaciones.Name = "txtCertificaciones";
            txtCertificaciones.Size = new Size(295, 23);
            txtCertificaciones.TabIndex = 7;
            //
            // grpCuenta
            //
            grpCuenta.Controls.Add(lblRol);
            grpCuenta.Controls.Add(lblEstado);
            grpCuenta.Controls.Add(lblFechaRegistro);
            grpCuenta.Location = new Point(20, 325);
            grpCuenta.Name = "grpCuenta";
            grpCuenta.Size = new Size(480, 60);
            grpCuenta.TabIndex = 6;
            grpCuenta.TabStop = false;
            grpCuenta.Text = "Información de la cuenta (solo lectura)";
            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Location = new Point(15, 28);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(46, 15);
            lblRol.TabIndex = 0;
            lblRol.Text = "Rol: —";
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(150, 28);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(64, 15);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Estado: —";
            //
            // lblFechaRegistro
            //
            lblFechaRegistro.AutoSize = true;
            lblFechaRegistro.Location = new Point(270, 28);
            lblFechaRegistro.Name = "lblFechaRegistro";
            lblFechaRegistro.Size = new Size(89, 15);
            lblFechaRegistro.TabIndex = 2;
            lblFechaRegistro.Text = "Registrado: —";
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(650, 370);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(160, 32);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(830, 370);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 32);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            //
            // FrmActualizarEntrenador
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(1010, 420);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(grpCuenta);
            Controls.Add(grpDatosProfesionales);
            Controls.Add(grpAcceso);
            Controls.Add(grpDatosPersonales);
            Controls.Add(cmbEntrenadores);
            Controls.Add(lblSeleccionarEntrenador);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmActualizarEntrenador";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buddy - Actualizar entrenador";
            Load += FrmActualizarEntrenador_Load;
            grpDatosPersonales.ResumeLayout(false);
            grpDatosPersonales.PerformLayout();
            grpAcceso.ResumeLayout(false);
            grpAcceso.PerformLayout();
            grpDatosProfesionales.ResumeLayout(false);
            grpDatosProfesionales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAniosExperiencia).EndInit();
            grpCuenta.ResumeLayout(false);
            grpCuenta.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSeleccionarEntrenador;
        private ComboBox cmbEntrenadores;
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
        private Label lblEdad;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private GroupBox grpAcceso;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblNombreUsuario;
        private TextBox txtNombreUsuario;
        private GroupBox grpDatosProfesionales;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblEspecialidad;
        private ComboBox cmbEspecialidad;
        private Label lblAniosExperiencia;
        private NumericUpDown nudAniosExperiencia;
        private Label lblCertificaciones;
        private TextBox txtCertificaciones;
        private GroupBox grpCuenta;
        private Label lblRol;
        private Label lblEstado;
        private Label lblFechaRegistro;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
