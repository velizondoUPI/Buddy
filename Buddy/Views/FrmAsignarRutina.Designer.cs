namespace Buddy.Views
{
    partial class FrmAsignarRutina
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
            grpUsuario = new GroupBox();
            lblBuscarUsuario = new Label();
            txtBuscarUsuario = new TextBox();
            dgvUsuarios = new DataGridView();
            lblInfoUsuario = new Label();
            lblAsignacionesUsuario = new Label();
            dgvAsignacionesUsuario = new DataGridView();
            grpRutina = new GroupBox();
            lblEntrenador = new Label();
            cmbEntrenador = new ComboBox();
            lblRutinas = new Label();
            dgvRutinas = new DataGridView();
            lblDescripcionRutina = new Label();
            grpDatosAsignacion = new GroupBox();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaFin = new Label();
            dtpFechaFin = new DateTimePicker();
            lblFrecuencia = new Label();
            nudFrecuencia = new NumericUpDown();
            lblEstadoInicial = new Label();
            lblIndicaciones = new Label();
            txtIndicaciones = new TextBox();
            lblCamposObligatorios = new Label();
            btnAsignar = new Button();
            btnLimpiar = new Button();
            grpUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsignacionesUsuario).BeginInit();
            grpRutina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRutinas).BeginInit();
            grpDatosAsignacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFrecuencia).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(460, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(240, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Asignación de Rutinas";
            //
            // grpUsuario
            //
            grpUsuario.Controls.Add(lblBuscarUsuario);
            grpUsuario.Controls.Add(txtBuscarUsuario);
            grpUsuario.Controls.Add(dgvUsuarios);
            grpUsuario.Controls.Add(lblInfoUsuario);
            grpUsuario.Controls.Add(lblAsignacionesUsuario);
            grpUsuario.Controls.Add(dgvAsignacionesUsuario);
            grpUsuario.Location = new Point(20, 50);
            grpUsuario.Name = "grpUsuario";
            grpUsuario.Size = new Size(560, 590);
            grpUsuario.TabIndex = 1;
            grpUsuario.TabStop = false;
            grpUsuario.Text = "1. Usuario";
            //
            // lblBuscarUsuario
            //
            lblBuscarUsuario.AutoSize = true;
            lblBuscarUsuario.Location = new Point(15, 28);
            lblBuscarUsuario.Name = "lblBuscarUsuario";
            lblBuscarUsuario.Size = new Size(45, 15);
            lblBuscarUsuario.TabIndex = 0;
            lblBuscarUsuario.Text = "Buscar:";
            //
            // txtBuscarUsuario
            //
            txtBuscarUsuario.Location = new Point(70, 25);
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.PlaceholderText = "Nombre o nombre de usuario";
            txtBuscarUsuario.Size = new Size(475, 23);
            txtBuscarUsuario.TabIndex = 1;
            txtBuscarUsuario.TextChanged += txtBuscarUsuario_TextChanged;
            //
            // dgvUsuarios
            //
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(15, 58);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(530, 150);
            dgvUsuarios.TabIndex = 2;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            //
            // lblInfoUsuario
            //
            lblInfoUsuario.Location = new Point(15, 216);
            lblInfoUsuario.Name = "lblInfoUsuario";
            lblInfoUsuario.Size = new Size(530, 44);
            lblInfoUsuario.TabIndex = 3;
            lblInfoUsuario.Text = "Seleccione un usuario.";
            //
            // lblAsignacionesUsuario
            //
            lblAsignacionesUsuario.AutoSize = true;
            lblAsignacionesUsuario.Location = new Point(15, 266);
            lblAsignacionesUsuario.Name = "lblAsignacionesUsuario";
            lblAsignacionesUsuario.Size = new Size(173, 15);
            lblAsignacionesUsuario.TabIndex = 4;
            lblAsignacionesUsuario.Text = "Rutinas asignadas al usuario:";
            //
            // dgvAsignacionesUsuario
            //
            dgvAsignacionesUsuario.AllowUserToAddRows = false;
            dgvAsignacionesUsuario.AllowUserToDeleteRows = false;
            dgvAsignacionesUsuario.AllowUserToResizeRows = false;
            dgvAsignacionesUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAsignacionesUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsignacionesUsuario.Location = new Point(15, 286);
            dgvAsignacionesUsuario.MultiSelect = false;
            dgvAsignacionesUsuario.Name = "dgvAsignacionesUsuario";
            dgvAsignacionesUsuario.ReadOnly = true;
            dgvAsignacionesUsuario.RowHeadersVisible = false;
            dgvAsignacionesUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsignacionesUsuario.Size = new Size(530, 288);
            dgvAsignacionesUsuario.TabIndex = 5;
            dgvAsignacionesUsuario.TabStop = false;
            //
            // grpRutina
            //
            grpRutina.Controls.Add(lblEntrenador);
            grpRutina.Controls.Add(cmbEntrenador);
            grpRutina.Controls.Add(lblRutinas);
            grpRutina.Controls.Add(dgvRutinas);
            grpRutina.Controls.Add(lblDescripcionRutina);
            grpRutina.Location = new Point(595, 50);
            grpRutina.Name = "grpRutina";
            grpRutina.Size = new Size(565, 330);
            grpRutina.TabIndex = 2;
            grpRutina.TabStop = false;
            grpRutina.Text = "2. Entrenador y rutina";
            //
            // lblEntrenador
            //
            lblEntrenador.AutoSize = true;
            lblEntrenador.Location = new Point(15, 28);
            lblEntrenador.Name = "lblEntrenador";
            lblEntrenador.Size = new Size(129, 15);
            lblEntrenador.TabIndex = 0;
            lblEntrenador.Text = "Entrenador personal: *";
            //
            // cmbEntrenador
            //
            cmbEntrenador.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEntrenador.FormattingEnabled = true;
            cmbEntrenador.Location = new Point(160, 25);
            cmbEntrenador.Name = "cmbEntrenador";
            cmbEntrenador.Size = new Size(390, 23);
            cmbEntrenador.TabIndex = 1;
            //
            // lblRutinas
            //
            lblRutinas.AutoSize = true;
            lblRutinas.Location = new Point(15, 58);
            lblRutinas.Name = "lblRutinas";
            lblRutinas.Size = new Size(126, 15);
            lblRutinas.TabIndex = 2;
            lblRutinas.Text = "Rutinas disponibles: *";
            //
            // dgvRutinas
            //
            dgvRutinas.AllowUserToAddRows = false;
            dgvRutinas.AllowUserToDeleteRows = false;
            dgvRutinas.AllowUserToResizeRows = false;
            dgvRutinas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutinas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutinas.Location = new Point(15, 78);
            dgvRutinas.MultiSelect = false;
            dgvRutinas.Name = "dgvRutinas";
            dgvRutinas.ReadOnly = true;
            dgvRutinas.RowHeadersVisible = false;
            dgvRutinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRutinas.Size = new Size(535, 170);
            dgvRutinas.TabIndex = 3;
            dgvRutinas.SelectionChanged += dgvRutinas_SelectionChanged;
            //
            // lblDescripcionRutina
            //
            lblDescripcionRutina.AutoEllipsis = true;
            lblDescripcionRutina.Location = new Point(15, 255);
            lblDescripcionRutina.Name = "lblDescripcionRutina";
            lblDescripcionRutina.Size = new Size(535, 65);
            lblDescripcionRutina.TabIndex = 4;
            lblDescripcionRutina.Text = "Seleccione una rutina para ver su descripción.";
            //
            // grpDatosAsignacion
            //
            grpDatosAsignacion.Controls.Add(lblFechaInicio);
            grpDatosAsignacion.Controls.Add(dtpFechaInicio);
            grpDatosAsignacion.Controls.Add(lblFechaFin);
            grpDatosAsignacion.Controls.Add(dtpFechaFin);
            grpDatosAsignacion.Controls.Add(lblFrecuencia);
            grpDatosAsignacion.Controls.Add(nudFrecuencia);
            grpDatosAsignacion.Controls.Add(lblEstadoInicial);
            grpDatosAsignacion.Controls.Add(lblIndicaciones);
            grpDatosAsignacion.Controls.Add(txtIndicaciones);
            grpDatosAsignacion.Location = new Point(595, 390);
            grpDatosAsignacion.Name = "grpDatosAsignacion";
            grpDatosAsignacion.Size = new Size(565, 250);
            grpDatosAsignacion.TabIndex = 3;
            grpDatosAsignacion.TabStop = false;
            grpDatosAsignacion.Text = "3. Datos de la asignación";
            //
            // lblFechaInicio
            //
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(15, 30);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(98, 15);
            lblFechaInicio.TabIndex = 0;
            lblFechaInicio.Text = "Fecha de inicio: *";
            //
            // dtpFechaInicio
            //
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(190, 27);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(130, 23);
            dtpFechaInicio.TabIndex = 1;
            dtpFechaInicio.ValueChanged += dtpFechaInicio_ValueChanged;
            //
            // lblFechaFin
            //
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(15, 62);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(134, 15);
            lblFechaFin.TabIndex = 2;
            lblFechaFin.Text = "Fecha de finalización: *";
            //
            // dtpFechaFin
            //
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(190, 59);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(130, 23);
            dtpFechaFin.TabIndex = 3;
            //
            // lblFrecuencia
            //
            lblFrecuencia.AutoSize = true;
            lblFrecuencia.Location = new Point(15, 94);
            lblFrecuencia.Name = "lblFrecuencia";
            lblFrecuencia.Size = new Size(165, 15);
            lblFrecuencia.TabIndex = 4;
            lblFrecuencia.Text = "Frecuencia semanal (días): *";
            //
            // nudFrecuencia
            //
            nudFrecuencia.Location = new Point(190, 91);
            nudFrecuencia.Maximum = new decimal(new int[] { 7, 0, 0, 0 });
            nudFrecuencia.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFrecuencia.Name = "nudFrecuencia";
            nudFrecuencia.Size = new Size(60, 23);
            nudFrecuencia.TabIndex = 5;
            nudFrecuencia.Value = new decimal(new int[] { 3, 0, 0, 0 });
            //
            // lblEstadoInicial
            //
            lblEstadoInicial.AutoSize = true;
            lblEstadoInicial.Location = new Point(340, 30);
            lblEstadoInicial.Name = "lblEstadoInicial";
            lblEstadoInicial.Size = new Size(84, 15);
            lblEstadoInicial.TabIndex = 6;
            lblEstadoInicial.Text = "Estado inicial: —";
            //
            // lblIndicaciones
            //
            lblIndicaciones.AutoSize = true;
            lblIndicaciones.Location = new Point(15, 126);
            lblIndicaciones.Name = "lblIndicaciones";
            lblIndicaciones.Size = new Size(203, 15);
            lblIndicaciones.TabIndex = 7;
            lblIndicaciones.Text = "Indicaciones adicionales (opcional):";
            //
            // txtIndicaciones
            //
            txtIndicaciones.Location = new Point(15, 144);
            txtIndicaciones.MaxLength = 500;
            txtIndicaciones.Multiline = true;
            txtIndicaciones.Name = "txtIndicaciones";
            txtIndicaciones.ScrollBars = ScrollBars.Vertical;
            txtIndicaciones.Size = new Size(535, 90);
            txtIndicaciones.TabIndex = 8;
            //
            // lblCamposObligatorios
            //
            lblCamposObligatorios.AutoSize = true;
            lblCamposObligatorios.ForeColor = SystemColors.GrayText;
            lblCamposObligatorios.Location = new Point(20, 661);
            lblCamposObligatorios.Name = "lblCamposObligatorios";
            lblCamposObligatorios.Size = new Size(125, 15);
            lblCamposObligatorios.TabIndex = 4;
            lblCamposObligatorios.Text = "* Campos obligatorios";
            //
            // btnAsignar
            //
            btnAsignar.Location = new Point(830, 652);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(180, 34);
            btnAsignar.TabIndex = 5;
            btnAsignar.Text = "Asignar rutina";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Location = new Point(1020, 652);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(140, 34);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // FrmAsignarRutina
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 700);
            Controls.Add(btnLimpiar);
            Controls.Add(btnAsignar);
            Controls.Add(lblCamposObligatorios);
            Controls.Add(grpDatosAsignacion);
            Controls.Add(grpRutina);
            Controls.Add(grpUsuario);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAsignarRutina";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buddy - Asignar rutina";
            Load += FrmAsignarRutina_Load;
            grpUsuario.ResumeLayout(false);
            grpUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsignacionesUsuario).EndInit();
            grpRutina.ResumeLayout(false);
            grpRutina.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRutinas).EndInit();
            grpDatosAsignacion.ResumeLayout(false);
            grpDatosAsignacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFrecuencia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private GroupBox grpUsuario;
        private Label lblBuscarUsuario;
        private TextBox txtBuscarUsuario;
        private DataGridView dgvUsuarios;
        private Label lblInfoUsuario;
        private Label lblAsignacionesUsuario;
        private DataGridView dgvAsignacionesUsuario;
        private GroupBox grpRutina;
        private Label lblEntrenador;
        private ComboBox cmbEntrenador;
        private Label lblRutinas;
        private DataGridView dgvRutinas;
        private Label lblDescripcionRutina;
        private GroupBox grpDatosAsignacion;
        private Label lblFechaInicio;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaFin;
        private Label lblFrecuencia;
        private NumericUpDown nudFrecuencia;
        private Label lblEstadoInicial;
        private Label lblIndicaciones;
        private TextBox txtIndicaciones;
        private Label lblCamposObligatorios;
        private Button btnAsignar;
        private Button btnLimpiar;
    }
}
