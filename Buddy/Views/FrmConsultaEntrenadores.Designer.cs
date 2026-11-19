namespace Buddy.Views
{
    partial class FrmConsultaEntrenadores
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblFiltroTipo = new Label();
            cmbFiltroTipo = new ComboBox();
            lblFiltroEspecialidad = new Label();
            cmbFiltroEspecialidad = new ComboBox();
            btnLimpiarFiltros = new Button();
            lblResultados = new Label();
            dgvEntrenadores = new DataGridView();
            grpDetalle = new GroupBox();
            lblNombreTitulo = new Label();
            lblDetalleNombre = new Label();
            lblIdentificacionTitulo = new Label();
            lblDetalleIdentificacion = new Label();
            lblUsuarioTitulo = new Label();
            lblDetalleUsuario = new Label();
            lblCorreoTitulo = new Label();
            lblDetalleCorreo = new Label();
            lblTelefonoTitulo = new Label();
            lblDetalleTelefono = new Label();
            lblFechaNacimientoTitulo = new Label();
            lblDetalleFechaNacimiento = new Label();
            lblEdadTitulo = new Label();
            lblDetalleEdad = new Label();
            lblTipoTitulo = new Label();
            lblDetalleTipo = new Label();
            lblEspecialidadTitulo = new Label();
            lblDetalleEspecialidad = new Label();
            lblExperienciaTitulo = new Label();
            lblDetalleExperiencia = new Label();
            lblCertificacionesTitulo = new Label();
            lblDetalleCertificaciones = new Label();
            lblRolTitulo = new Label();
            lblDetalleRol = new Label();
            lblEstadoTitulo = new Label();
            lblDetalleEstado = new Label();
            lblFechaRegistroTitulo = new Label();
            lblDetalleFechaRegistro = new Label();
            btnActualizarEntrenador = new Button();
            btnCambiarContrasena = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEntrenadores).BeginInit();
            grpDetalle.SuspendLayout();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(370, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(260, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consulta de Entrenadores";
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(20, 60);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar:";
            //
            // txtBuscar
            //
            txtBuscar.Location = new Point(75, 57);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre, usuario o identificación";
            txtBuscar.Size = new Size(220, 23);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += Filtros_Changed;
            //
            // lblFiltroTipo
            //
            lblFiltroTipo.AutoSize = true;
            lblFiltroTipo.Location = new Point(310, 60);
            lblFiltroTipo.Name = "lblFiltroTipo";
            lblFiltroTipo.Size = new Size(34, 15);
            lblFiltroTipo.TabIndex = 3;
            lblFiltroTipo.Text = "Tipo:";
            //
            // cmbFiltroTipo
            //
            cmbFiltroTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroTipo.FormattingEnabled = true;
            cmbFiltroTipo.Location = new Point(350, 57);
            cmbFiltroTipo.Name = "cmbFiltroTipo";
            cmbFiltroTipo.Size = new Size(190, 23);
            cmbFiltroTipo.TabIndex = 4;
            cmbFiltroTipo.SelectedIndexChanged += Filtros_Changed;
            //
            // lblFiltroEspecialidad
            //
            lblFiltroEspecialidad.AutoSize = true;
            lblFiltroEspecialidad.Location = new Point(555, 60);
            lblFiltroEspecialidad.Name = "lblFiltroEspecialidad";
            lblFiltroEspecialidad.Size = new Size(75, 15);
            lblFiltroEspecialidad.TabIndex = 5;
            lblFiltroEspecialidad.Text = "Especialidad:";
            //
            // cmbFiltroEspecialidad
            //
            cmbFiltroEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEspecialidad.FormattingEnabled = true;
            cmbFiltroEspecialidad.Location = new Point(635, 57);
            cmbFiltroEspecialidad.Name = "cmbFiltroEspecialidad";
            cmbFiltroEspecialidad.Size = new Size(170, 23);
            cmbFiltroEspecialidad.TabIndex = 6;
            cmbFiltroEspecialidad.SelectedIndexChanged += Filtros_Changed;
            //
            // btnLimpiarFiltros
            //
            btnLimpiarFiltros.Location = new Point(820, 55);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(160, 27);
            btnLimpiarFiltros.TabIndex = 7;
            btnLimpiarFiltros.Text = "Limpiar filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            //
            // lblResultados
            //
            lblResultados.AutoSize = true;
            lblResultados.Location = new Point(20, 92);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(0, 15);
            lblResultados.TabIndex = 8;
            //
            // dgvEntrenadores
            //
            dgvEntrenadores.AllowUserToAddRows = false;
            dgvEntrenadores.AllowUserToDeleteRows = false;
            dgvEntrenadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntrenadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntrenadores.Location = new Point(20, 112);
            dgvEntrenadores.MultiSelect = false;
            dgvEntrenadores.Name = "dgvEntrenadores";
            dgvEntrenadores.ReadOnly = true;
            dgvEntrenadores.RowHeadersVisible = false;
            dgvEntrenadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEntrenadores.Size = new Size(960, 260);
            dgvEntrenadores.TabIndex = 9;
            dgvEntrenadores.SelectionChanged += dgvEntrenadores_SelectionChanged;
            //
            // grpDetalle
            //
            grpDetalle.Controls.Add(lblNombreTitulo);
            grpDetalle.Controls.Add(lblDetalleNombre);
            grpDetalle.Controls.Add(lblIdentificacionTitulo);
            grpDetalle.Controls.Add(lblDetalleIdentificacion);
            grpDetalle.Controls.Add(lblUsuarioTitulo);
            grpDetalle.Controls.Add(lblDetalleUsuario);
            grpDetalle.Controls.Add(lblCorreoTitulo);
            grpDetalle.Controls.Add(lblDetalleCorreo);
            grpDetalle.Controls.Add(lblTelefonoTitulo);
            grpDetalle.Controls.Add(lblDetalleTelefono);
            grpDetalle.Controls.Add(lblFechaNacimientoTitulo);
            grpDetalle.Controls.Add(lblDetalleFechaNacimiento);
            grpDetalle.Controls.Add(lblEdadTitulo);
            grpDetalle.Controls.Add(lblDetalleEdad);
            grpDetalle.Controls.Add(lblTipoTitulo);
            grpDetalle.Controls.Add(lblDetalleTipo);
            grpDetalle.Controls.Add(lblEspecialidadTitulo);
            grpDetalle.Controls.Add(lblDetalleEspecialidad);
            grpDetalle.Controls.Add(lblExperienciaTitulo);
            grpDetalle.Controls.Add(lblDetalleExperiencia);
            grpDetalle.Controls.Add(lblCertificacionesTitulo);
            grpDetalle.Controls.Add(lblDetalleCertificaciones);
            grpDetalle.Controls.Add(lblRolTitulo);
            grpDetalle.Controls.Add(lblDetalleRol);
            grpDetalle.Controls.Add(lblEstadoTitulo);
            grpDetalle.Controls.Add(lblDetalleEstado);
            grpDetalle.Controls.Add(lblFechaRegistroTitulo);
            grpDetalle.Controls.Add(lblDetalleFechaRegistro);
            grpDetalle.Location = new Point(20, 380);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Size = new Size(960, 155);
            grpDetalle.TabIndex = 10;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Detalles del entrenador";
            //
            // lblNombreTitulo
            //
            lblNombreTitulo.AutoSize = true;
            lblNombreTitulo.Location = new Point(15, 28);
            lblNombreTitulo.Name = "lblNombreTitulo";
            lblNombreTitulo.Size = new Size(54, 15);
            lblNombreTitulo.TabIndex = 0;
            lblNombreTitulo.Text = "Nombre:";
            //
            // lblDetalleNombre
            //
            lblDetalleNombre.AutoEllipsis = true;
            lblDetalleNombre.Location = new Point(120, 28);
            lblDetalleNombre.Name = "lblDetalleNombre";
            lblDetalleNombre.Size = new Size(200, 15);
            lblDetalleNombre.TabIndex = 1;
            lblDetalleNombre.Text = "—";
            //
            // lblIdentificacionTitulo
            //
            lblIdentificacionTitulo.AutoSize = true;
            lblIdentificacionTitulo.Location = new Point(15, 52);
            lblIdentificacionTitulo.Name = "lblIdentificacionTitulo";
            lblIdentificacionTitulo.Size = new Size(82, 15);
            lblIdentificacionTitulo.TabIndex = 2;
            lblIdentificacionTitulo.Text = "Identificación:";
            //
            // lblDetalleIdentificacion
            //
            lblDetalleIdentificacion.AutoEllipsis = true;
            lblDetalleIdentificacion.Location = new Point(120, 52);
            lblDetalleIdentificacion.Name = "lblDetalleIdentificacion";
            lblDetalleIdentificacion.Size = new Size(200, 15);
            lblDetalleIdentificacion.TabIndex = 3;
            lblDetalleIdentificacion.Text = "—";
            //
            // lblUsuarioTitulo
            //
            lblUsuarioTitulo.AutoSize = true;
            lblUsuarioTitulo.Location = new Point(15, 76);
            lblUsuarioTitulo.Name = "lblUsuarioTitulo";
            lblUsuarioTitulo.Size = new Size(50, 15);
            lblUsuarioTitulo.TabIndex = 4;
            lblUsuarioTitulo.Text = "Usuario:";
            //
            // lblDetalleUsuario
            //
            lblDetalleUsuario.AutoEllipsis = true;
            lblDetalleUsuario.Location = new Point(120, 76);
            lblDetalleUsuario.Name = "lblDetalleUsuario";
            lblDetalleUsuario.Size = new Size(200, 15);
            lblDetalleUsuario.TabIndex = 5;
            lblDetalleUsuario.Text = "—";
            //
            // lblCorreoTitulo
            //
            lblCorreoTitulo.AutoSize = true;
            lblCorreoTitulo.Location = new Point(15, 100);
            lblCorreoTitulo.Name = "lblCorreoTitulo";
            lblCorreoTitulo.Size = new Size(46, 15);
            lblCorreoTitulo.TabIndex = 6;
            lblCorreoTitulo.Text = "Correo:";
            //
            // lblDetalleCorreo
            //
            lblDetalleCorreo.AutoEllipsis = true;
            lblDetalleCorreo.Location = new Point(120, 100);
            lblDetalleCorreo.Name = "lblDetalleCorreo";
            lblDetalleCorreo.Size = new Size(200, 15);
            lblDetalleCorreo.TabIndex = 7;
            lblDetalleCorreo.Text = "—";
            //
            // lblTelefonoTitulo
            //
            lblTelefonoTitulo.AutoSize = true;
            lblTelefonoTitulo.Location = new Point(15, 124);
            lblTelefonoTitulo.Name = "lblTelefonoTitulo";
            lblTelefonoTitulo.Size = new Size(55, 15);
            lblTelefonoTitulo.TabIndex = 8;
            lblTelefonoTitulo.Text = "Teléfono:";
            //
            // lblDetalleTelefono
            //
            lblDetalleTelefono.AutoEllipsis = true;
            lblDetalleTelefono.Location = new Point(120, 124);
            lblDetalleTelefono.Name = "lblDetalleTelefono";
            lblDetalleTelefono.Size = new Size(200, 15);
            lblDetalleTelefono.TabIndex = 9;
            lblDetalleTelefono.Text = "—";
            //
            // lblFechaNacimientoTitulo
            //
            lblFechaNacimientoTitulo.AutoSize = true;
            lblFechaNacimientoTitulo.Location = new Point(335, 28);
            lblFechaNacimientoTitulo.Name = "lblFechaNacimientoTitulo";
            lblFechaNacimientoTitulo.Size = new Size(97, 15);
            lblFechaNacimientoTitulo.TabIndex = 10;
            lblFechaNacimientoTitulo.Text = "Fecha nacimiento:";
            //
            // lblDetalleFechaNacimiento
            //
            lblDetalleFechaNacimiento.AutoEllipsis = true;
            lblDetalleFechaNacimiento.Location = new Point(450, 28);
            lblDetalleFechaNacimiento.Name = "lblDetalleFechaNacimiento";
            lblDetalleFechaNacimiento.Size = new Size(190, 15);
            lblDetalleFechaNacimiento.TabIndex = 11;
            lblDetalleFechaNacimiento.Text = "—";
            //
            // lblEdadTitulo
            //
            lblEdadTitulo.AutoSize = true;
            lblEdadTitulo.Location = new Point(335, 52);
            lblEdadTitulo.Name = "lblEdadTitulo";
            lblEdadTitulo.Size = new Size(36, 15);
            lblEdadTitulo.TabIndex = 12;
            lblEdadTitulo.Text = "Edad:";
            //
            // lblDetalleEdad
            //
            lblDetalleEdad.AutoEllipsis = true;
            lblDetalleEdad.Location = new Point(450, 52);
            lblDetalleEdad.Name = "lblDetalleEdad";
            lblDetalleEdad.Size = new Size(190, 15);
            lblDetalleEdad.TabIndex = 13;
            lblDetalleEdad.Text = "—";
            //
            // lblTipoTitulo
            //
            lblTipoTitulo.AutoSize = true;
            lblTipoTitulo.Location = new Point(335, 76);
            lblTipoTitulo.Name = "lblTipoTitulo";
            lblTipoTitulo.Size = new Size(34, 15);
            lblTipoTitulo.TabIndex = 14;
            lblTipoTitulo.Text = "Tipo:";
            //
            // lblDetalleTipo
            //
            lblDetalleTipo.AutoEllipsis = true;
            lblDetalleTipo.Location = new Point(450, 76);
            lblDetalleTipo.Name = "lblDetalleTipo";
            lblDetalleTipo.Size = new Size(190, 15);
            lblDetalleTipo.TabIndex = 15;
            lblDetalleTipo.Text = "—";
            //
            // lblEspecialidadTitulo
            //
            lblEspecialidadTitulo.AutoSize = true;
            lblEspecialidadTitulo.Location = new Point(335, 100);
            lblEspecialidadTitulo.Name = "lblEspecialidadTitulo";
            lblEspecialidadTitulo.Size = new Size(75, 15);
            lblEspecialidadTitulo.TabIndex = 16;
            lblEspecialidadTitulo.Text = "Especialidad:";
            //
            // lblDetalleEspecialidad
            //
            lblDetalleEspecialidad.AutoEllipsis = true;
            lblDetalleEspecialidad.Location = new Point(450, 100);
            lblDetalleEspecialidad.Name = "lblDetalleEspecialidad";
            lblDetalleEspecialidad.Size = new Size(190, 15);
            lblDetalleEspecialidad.TabIndex = 17;
            lblDetalleEspecialidad.Text = "—";
            //
            // lblExperienciaTitulo
            //
            lblExperienciaTitulo.AutoSize = true;
            lblExperienciaTitulo.Location = new Point(335, 124);
            lblExperienciaTitulo.Name = "lblExperienciaTitulo";
            lblExperienciaTitulo.Size = new Size(70, 15);
            lblExperienciaTitulo.TabIndex = 18;
            lblExperienciaTitulo.Text = "Experiencia:";
            //
            // lblDetalleExperiencia
            //
            lblDetalleExperiencia.AutoEllipsis = true;
            lblDetalleExperiencia.Location = new Point(450, 124);
            lblDetalleExperiencia.Name = "lblDetalleExperiencia";
            lblDetalleExperiencia.Size = new Size(190, 15);
            lblDetalleExperiencia.TabIndex = 19;
            lblDetalleExperiencia.Text = "—";
            //
            // lblCertificacionesTitulo
            //
            lblCertificacionesTitulo.AutoSize = true;
            lblCertificacionesTitulo.Location = new Point(655, 28);
            lblCertificacionesTitulo.Name = "lblCertificacionesTitulo";
            lblCertificacionesTitulo.Size = new Size(88, 15);
            lblCertificacionesTitulo.TabIndex = 20;
            lblCertificacionesTitulo.Text = "Certificaciones:";
            //
            // lblDetalleCertificaciones
            //
            lblDetalleCertificaciones.AutoEllipsis = true;
            lblDetalleCertificaciones.Location = new Point(760, 28);
            lblDetalleCertificaciones.Name = "lblDetalleCertificaciones";
            lblDetalleCertificaciones.Size = new Size(190, 15);
            lblDetalleCertificaciones.TabIndex = 21;
            lblDetalleCertificaciones.Text = "—";
            //
            // lblRolTitulo
            //
            lblRolTitulo.AutoSize = true;
            lblRolTitulo.Location = new Point(655, 52);
            lblRolTitulo.Name = "lblRolTitulo";
            lblRolTitulo.Size = new Size(27, 15);
            lblRolTitulo.TabIndex = 22;
            lblRolTitulo.Text = "Rol:";
            //
            // lblDetalleRol
            //
            lblDetalleRol.AutoEllipsis = true;
            lblDetalleRol.Location = new Point(760, 52);
            lblDetalleRol.Name = "lblDetalleRol";
            lblDetalleRol.Size = new Size(190, 15);
            lblDetalleRol.TabIndex = 23;
            lblDetalleRol.Text = "—";
            //
            // lblEstadoTitulo
            //
            lblEstadoTitulo.AutoSize = true;
            lblEstadoTitulo.Location = new Point(655, 76);
            lblEstadoTitulo.Name = "lblEstadoTitulo";
            lblEstadoTitulo.Size = new Size(45, 15);
            lblEstadoTitulo.TabIndex = 24;
            lblEstadoTitulo.Text = "Estado:";
            //
            // lblDetalleEstado
            //
            lblDetalleEstado.AutoEllipsis = true;
            lblDetalleEstado.Location = new Point(760, 76);
            lblDetalleEstado.Name = "lblDetalleEstado";
            lblDetalleEstado.Size = new Size(190, 15);
            lblDetalleEstado.TabIndex = 25;
            lblDetalleEstado.Text = "—";
            //
            // lblFechaRegistroTitulo
            //
            lblFechaRegistroTitulo.AutoSize = true;
            lblFechaRegistroTitulo.Location = new Point(655, 100);
            lblFechaRegistroTitulo.Name = "lblFechaRegistroTitulo";
            lblFechaRegistroTitulo.Size = new Size(84, 15);
            lblFechaRegistroTitulo.TabIndex = 26;
            lblFechaRegistroTitulo.Text = "Fecha registro:";
            //
            // lblDetalleFechaRegistro
            //
            lblDetalleFechaRegistro.AutoEllipsis = true;
            lblDetalleFechaRegistro.Location = new Point(760, 100);
            lblDetalleFechaRegistro.Name = "lblDetalleFechaRegistro";
            lblDetalleFechaRegistro.Size = new Size(190, 15);
            lblDetalleFechaRegistro.TabIndex = 27;
            lblDetalleFechaRegistro.Text = "—";
            //
            // btnActualizarEntrenador
            //
            btnActualizarEntrenador.Location = new Point(610, 547);
            btnActualizarEntrenador.Name = "btnActualizarEntrenador";
            btnActualizarEntrenador.Size = new Size(180, 32);
            btnActualizarEntrenador.TabIndex = 11;
            btnActualizarEntrenador.Text = "Actualizar entrenador";
            btnActualizarEntrenador.UseVisualStyleBackColor = true;
            btnActualizarEntrenador.Click += btnActualizarEntrenador_Click;
            //
            // btnCambiarContrasena
            //
            btnCambiarContrasena.Location = new Point(800, 547);
            btnCambiarContrasena.Name = "btnCambiarContrasena";
            btnCambiarContrasena.Size = new Size(180, 32);
            btnCambiarContrasena.TabIndex = 12;
            btnCambiarContrasena.Text = "Cambiar contraseña";
            btnCambiarContrasena.UseVisualStyleBackColor = true;
            btnCambiarContrasena.Click += btnCambiarContrasena_Click;
            //
            // FrmConsultaEntrenadores
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 595);
            Controls.Add(btnCambiarContrasena);
            Controls.Add(btnActualizarEntrenador);
            Controls.Add(grpDetalle);
            Controls.Add(dgvEntrenadores);
            Controls.Add(lblResultados);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(cmbFiltroEspecialidad);
            Controls.Add(lblFiltroEspecialidad);
            Controls.Add(cmbFiltroTipo);
            Controls.Add(lblFiltroTipo);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmConsultaEntrenadores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buddy - Consulta de entrenadores";
            Load += FrmConsultaEntrenadores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEntrenadores).EndInit();
            grpDetalle.ResumeLayout(false);
            grpDetalle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Label lblFiltroTipo;
        private ComboBox cmbFiltroTipo;
        private Label lblFiltroEspecialidad;
        private ComboBox cmbFiltroEspecialidad;
        private Button btnLimpiarFiltros;
        private Label lblResultados;
        private DataGridView dgvEntrenadores;
        private GroupBox grpDetalle;
        private Label lblNombreTitulo;
        private Label lblDetalleNombre;
        private Label lblIdentificacionTitulo;
        private Label lblDetalleIdentificacion;
        private Label lblUsuarioTitulo;
        private Label lblDetalleUsuario;
        private Label lblCorreoTitulo;
        private Label lblDetalleCorreo;
        private Label lblTelefonoTitulo;
        private Label lblDetalleTelefono;
        private Label lblFechaNacimientoTitulo;
        private Label lblDetalleFechaNacimiento;
        private Label lblEdadTitulo;
        private Label lblDetalleEdad;
        private Label lblTipoTitulo;
        private Label lblDetalleTipo;
        private Label lblEspecialidadTitulo;
        private Label lblDetalleEspecialidad;
        private Label lblExperienciaTitulo;
        private Label lblDetalleExperiencia;
        private Label lblCertificacionesTitulo;
        private Label lblDetalleCertificaciones;
        private Label lblRolTitulo;
        private Label lblDetalleRol;
        private Label lblEstadoTitulo;
        private Label lblDetalleEstado;
        private Label lblFechaRegistroTitulo;
        private Label lblDetalleFechaRegistro;
        private Button btnActualizarEntrenador;
        private Button btnCambiarContrasena;
    }
}
