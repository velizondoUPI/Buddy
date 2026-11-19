namespace Buddy.Views
{
    partial class FrmCrearRutina
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
            grpDatosGenerales = new GroupBox();
            lblEntrenador = new Label();
            cmbEntrenador = new ComboBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblObjetivo = new Label();
            cmbObjetivo = new ComboBox();
            lblDificultad = new Label();
            cmbDificultad = new ComboBox();
            lblDuracion = new Label();
            nudDuracion = new NumericUpDown();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblDias = new Label();
            clbDias = new CheckedListBox();
            grpEjercicios = new GroupBox();
            lblDiaEjercicio = new Label();
            cmbDiaEjercicio = new ComboBox();
            lblNombreEjercicio = new Label();
            txtNombreEjercicio = new TextBox();
            lblDescripcionEjercicio = new Label();
            txtDescripcionEjercicio = new TextBox();
            lblSeries = new Label();
            nudSeries = new NumericUpDown();
            lblRepeticiones = new Label();
            nudRepeticiones = new NumericUpDown();
            lblDescanso = new Label();
            nudDescanso = new NumericUpDown();
            chkPesoRecomendado = new CheckBox();
            nudPesoRecomendado = new NumericUpDown();
            lblIndicaciones = new Label();
            txtIndicaciones = new TextBox();
            btnAgregarEjercicio = new Button();
            btnModificarEjercicio = new Button();
            btnEliminarEjercicio = new Button();
            btnSubirEjercicio = new Button();
            btnBajarEjercicio = new Button();
            dgvEjercicios = new DataGridView();
            lblCamposObligatorios = new Label();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            grpDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).BeginInit();
            grpEjercicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeries).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRepeticiones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDescanso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPesoRecomendado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEjercicios).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(440, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(204, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Creación de Rutinas";
            // 
            // grpDatosGenerales
            // 
            grpDatosGenerales.Controls.Add(lblEntrenador);
            grpDatosGenerales.Controls.Add(cmbEntrenador);
            grpDatosGenerales.Controls.Add(lblNombre);
            grpDatosGenerales.Controls.Add(txtNombre);
            grpDatosGenerales.Controls.Add(lblObjetivo);
            grpDatosGenerales.Controls.Add(cmbObjetivo);
            grpDatosGenerales.Controls.Add(lblDificultad);
            grpDatosGenerales.Controls.Add(cmbDificultad);
            grpDatosGenerales.Controls.Add(lblDuracion);
            grpDatosGenerales.Controls.Add(nudDuracion);
            grpDatosGenerales.Controls.Add(lblDescripcion);
            grpDatosGenerales.Controls.Add(txtDescripcion);
            grpDatosGenerales.Controls.Add(lblDias);
            grpDatosGenerales.Controls.Add(clbDias);
            grpDatosGenerales.Location = new Point(20, 50);
            grpDatosGenerales.Name = "grpDatosGenerales";
            grpDatosGenerales.Size = new Size(430, 500);
            grpDatosGenerales.TabIndex = 1;
            grpDatosGenerales.TabStop = false;
            grpDatosGenerales.Text = "Datos generales";
            // 
            // lblEntrenador
            // 
            lblEntrenador.AutoSize = true;
            lblEntrenador.Location = new Point(15, 28);
            lblEntrenador.Name = "lblEntrenador";
            lblEntrenador.Size = new Size(119, 15);
            lblEntrenador.TabIndex = 0;
            lblEntrenador.Text = "Entrenador creador: *";
            // 
            // cmbEntrenador
            // 
            cmbEntrenador.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEntrenador.FormattingEnabled = true;
            cmbEntrenador.Location = new Point(15, 46);
            cmbEntrenador.Name = "cmbEntrenador";
            cmbEntrenador.Size = new Size(400, 23);
            cmbEntrenador.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(15, 78);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(124, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre de la rutina: *";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(15, 96);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(400, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblObjetivo
            // 
            lblObjetivo.AutoSize = true;
            lblObjetivo.Location = new Point(15, 128);
            lblObjetivo.Name = "lblObjetivo";
            lblObjetivo.Size = new Size(63, 15);
            lblObjetivo.TabIndex = 4;
            lblObjetivo.Text = "Objetivo: *";
            // 
            // cmbObjetivo
            // 
            cmbObjetivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbObjetivo.FormattingEnabled = true;
            cmbObjetivo.Location = new Point(15, 146);
            cmbObjetivo.Name = "cmbObjetivo";
            cmbObjetivo.Size = new Size(195, 23);
            cmbObjetivo.TabIndex = 5;
            // 
            // lblDificultad
            // 
            lblDificultad.AutoSize = true;
            lblDificultad.Location = new Point(220, 128);
            lblDificultad.Name = "lblDificultad";
            lblDificultad.Size = new Size(114, 15);
            lblDificultad.TabIndex = 6;
            lblDificultad.Text = "Nivel de dificultad: *";
            // 
            // cmbDificultad
            // 
            cmbDificultad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDificultad.FormattingEnabled = true;
            cmbDificultad.Location = new Point(220, 146);
            cmbDificultad.Name = "cmbDificultad";
            cmbDificultad.Size = new Size(195, 23);
            cmbDificultad.TabIndex = 7;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(15, 178);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(172, 15);
            lblDuracion.TabIndex = 8;
            lblDuracion.Text = "Duración estimada (minutos): *";
            // 
            // nudDuracion
            // 
            nudDuracion.Location = new Point(15, 196);
            nudDuracion.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudDuracion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuracion.Name = "nudDuracion";
            nudDuracion.Size = new Size(100, 23);
            nudDuracion.TabIndex = 9;
            nudDuracion.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(15, 228);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(80, 15);
            lblDescripcion.TabIndex = 10;
            lblDescripcion.Text = "Descripción: *";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(15, 246);
            txtDescripcion.MaxLength = 1000;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(400, 90);
            txtDescripcion.TabIndex = 11;
            // 
            // lblDias
            // 
            lblDias.AutoSize = true;
            lblDias.Location = new Point(15, 346);
            lblDias.Name = "lblDias";
            lblDias.Size = new Size(137, 15);
            lblDias.TabIndex = 12;
            lblDias.Text = "Días de entrenamiento: *";
            // 
            // clbDias
            // 
            clbDias.CheckOnClick = true;
            clbDias.FormattingEnabled = true;
            clbDias.Location = new Point(15, 364);
            clbDias.Name = "clbDias";
            clbDias.Size = new Size(400, 130);
            clbDias.TabIndex = 13;
            clbDias.ItemCheck += clbDias_ItemCheck;
            // 
            // grpEjercicios
            // 
            grpEjercicios.Controls.Add(lblDiaEjercicio);
            grpEjercicios.Controls.Add(cmbDiaEjercicio);
            grpEjercicios.Controls.Add(lblNombreEjercicio);
            grpEjercicios.Controls.Add(txtNombreEjercicio);
            grpEjercicios.Controls.Add(lblDescripcionEjercicio);
            grpEjercicios.Controls.Add(txtDescripcionEjercicio);
            grpEjercicios.Controls.Add(lblSeries);
            grpEjercicios.Controls.Add(nudSeries);
            grpEjercicios.Controls.Add(lblRepeticiones);
            grpEjercicios.Controls.Add(nudRepeticiones);
            grpEjercicios.Controls.Add(lblDescanso);
            grpEjercicios.Controls.Add(nudDescanso);
            grpEjercicios.Controls.Add(chkPesoRecomendado);
            grpEjercicios.Controls.Add(nudPesoRecomendado);
            grpEjercicios.Controls.Add(lblIndicaciones);
            grpEjercicios.Controls.Add(txtIndicaciones);
            grpEjercicios.Controls.Add(btnAgregarEjercicio);
            grpEjercicios.Controls.Add(btnModificarEjercicio);
            grpEjercicios.Controls.Add(btnEliminarEjercicio);
            grpEjercicios.Controls.Add(btnSubirEjercicio);
            grpEjercicios.Controls.Add(btnBajarEjercicio);
            grpEjercicios.Controls.Add(dgvEjercicios);
            grpEjercicios.Location = new Point(465, 50);
            grpEjercicios.Name = "grpEjercicios";
            grpEjercicios.Size = new Size(615, 500);
            grpEjercicios.TabIndex = 2;
            grpEjercicios.TabStop = false;
            grpEjercicios.Text = "Ejercicios";
            // 
            // lblDiaEjercicio
            // 
            lblDiaEjercicio.AutoSize = true;
            lblDiaEjercicio.Location = new Point(15, 28);
            lblDiaEjercicio.Name = "lblDiaEjercicio";
            lblDiaEjercicio.Size = new Size(35, 15);
            lblDiaEjercicio.TabIndex = 0;
            lblDiaEjercicio.Text = "Día: *";
            // 
            // cmbDiaEjercicio
            // 
            cmbDiaEjercicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDiaEjercicio.FormattingEnabled = true;
            cmbDiaEjercicio.Location = new Point(15, 46);
            cmbDiaEjercicio.Name = "cmbDiaEjercicio";
            cmbDiaEjercicio.Size = new Size(130, 23);
            cmbDiaEjercicio.TabIndex = 1;
            // 
            // lblNombreEjercicio
            // 
            lblNombreEjercicio.AutoSize = true;
            lblNombreEjercicio.Location = new Point(155, 28);
            lblNombreEjercicio.Name = "lblNombreEjercicio";
            lblNombreEjercicio.Size = new Size(62, 15);
            lblNombreEjercicio.TabIndex = 2;
            lblNombreEjercicio.Text = "Ejercicio: *";
            // 
            // txtNombreEjercicio
            // 
            txtNombreEjercicio.Location = new Point(155, 46);
            txtNombreEjercicio.MaxLength = 100;
            txtNombreEjercicio.Name = "txtNombreEjercicio";
            txtNombreEjercicio.Size = new Size(445, 23);
            txtNombreEjercicio.TabIndex = 3;
            txtNombreEjercicio.TextChanged += txtNombreEjercicio_TextChanged;
            // 
            // lblDescripcionEjercicio
            // 
            lblDescripcionEjercicio.AutoSize = true;
            lblDescripcionEjercicio.Location = new Point(15, 76);
            lblDescripcionEjercicio.Name = "lblDescripcionEjercicio";
            lblDescripcionEjercicio.Size = new Size(218, 15);
            lblDescripcionEjercicio.TabIndex = 4;
            lblDescripcionEjercicio.Text = "Descripción o indicación de ejecución: *";
            // 
            // txtDescripcionEjercicio
            // 
            txtDescripcionEjercicio.Location = new Point(15, 94);
            txtDescripcionEjercicio.MaxLength = 500;
            txtDescripcionEjercicio.Name = "txtDescripcionEjercicio";
            txtDescripcionEjercicio.Size = new Size(585, 23);
            txtDescripcionEjercicio.TabIndex = 5;
            // 
            // lblSeries
            // 
            lblSeries.AutoSize = true;
            lblSeries.Location = new Point(15, 124);
            lblSeries.Name = "lblSeries";
            lblSeries.Size = new Size(48, 15);
            lblSeries.TabIndex = 6;
            lblSeries.Text = "Series: *";
            // 
            // nudSeries
            // 
            nudSeries.Location = new Point(15, 142);
            nudSeries.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSeries.Name = "nudSeries";
            nudSeries.Size = new Size(80, 23);
            nudSeries.TabIndex = 7;
            nudSeries.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblRepeticiones
            // 
            lblRepeticiones.AutoSize = true;
            lblRepeticiones.Location = new Point(105, 124);
            lblRepeticiones.Name = "lblRepeticiones";
            lblRepeticiones.Size = new Size(85, 15);
            lblRepeticiones.TabIndex = 8;
            lblRepeticiones.Text = "Repeticiones: *";
            // 
            // nudRepeticiones
            // 
            nudRepeticiones.Location = new Point(105, 142);
            nudRepeticiones.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudRepeticiones.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRepeticiones.Name = "nudRepeticiones";
            nudRepeticiones.Size = new Size(80, 23);
            nudRepeticiones.TabIndex = 9;
            nudRepeticiones.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblDescanso
            // 
            lblDescanso.AutoSize = true;
            lblDescanso.Location = new Point(195, 124);
            lblDescanso.Name = "lblDescanso";
            lblDescanso.Size = new Size(97, 15);
            lblDescanso.TabIndex = 10;
            lblDescanso.Text = "Descanso (seg): *";
            // 
            // nudDescanso
            // 
            nudDescanso.Increment = new decimal(new int[] { 15, 0, 0, 0 });
            nudDescanso.Location = new Point(195, 142);
            nudDescanso.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            nudDescanso.Name = "nudDescanso";
            nudDescanso.Size = new Size(90, 23);
            nudDescanso.TabIndex = 11;
            nudDescanso.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // chkPesoRecomendado
            // 
            chkPesoRecomendado.AutoSize = true;
            chkPesoRecomendado.Location = new Point(300, 122);
            chkPesoRecomendado.Name = "chkPesoRecomendado";
            chkPesoRecomendado.Size = new Size(152, 19);
            chkPesoRecomendado.TabIndex = 12;
            chkPesoRecomendado.Text = "Peso recomendado (kg)";
            chkPesoRecomendado.UseVisualStyleBackColor = true;
            chkPesoRecomendado.CheckedChanged += chkPesoRecomendado_CheckedChanged;
            // 
            // nudPesoRecomendado
            // 
            nudPesoRecomendado.DecimalPlaces = 2;
            nudPesoRecomendado.Enabled = false;
            nudPesoRecomendado.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudPesoRecomendado.Location = new Point(300, 142);
            nudPesoRecomendado.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPesoRecomendado.Name = "nudPesoRecomendado";
            nudPesoRecomendado.Size = new Size(100, 23);
            nudPesoRecomendado.TabIndex = 13;
            // 
            // lblIndicaciones
            // 
            lblIndicaciones.AutoSize = true;
            lblIndicaciones.Location = new Point(15, 172);
            lblIndicaciones.Name = "lblIndicaciones";
            lblIndicaciones.Size = new Size(195, 15);
            lblIndicaciones.TabIndex = 14;
            lblIndicaciones.Text = "Indicaciones adicionales (opcional):";
            // 
            // txtIndicaciones
            // 
            txtIndicaciones.Location = new Point(15, 190);
            txtIndicaciones.MaxLength = 500;
            txtIndicaciones.Name = "txtIndicaciones";
            txtIndicaciones.Size = new Size(585, 23);
            txtIndicaciones.TabIndex = 15;
            // 
            // btnAgregarEjercicio
            // 
            btnAgregarEjercicio.Location = new Point(15, 222);
            btnAgregarEjercicio.Name = "btnAgregarEjercicio";
            btnAgregarEjercicio.Size = new Size(110, 28);
            btnAgregarEjercicio.TabIndex = 16;
            btnAgregarEjercicio.Text = "Agregar";
            btnAgregarEjercicio.UseVisualStyleBackColor = true;
            btnAgregarEjercicio.Click += btnAgregarEjercicio_Click;
            // 
            // btnModificarEjercicio
            // 
            btnModificarEjercicio.Location = new Point(130, 222);
            btnModificarEjercicio.Name = "btnModificarEjercicio";
            btnModificarEjercicio.Size = new Size(150, 28);
            btnModificarEjercicio.TabIndex = 17;
            btnModificarEjercicio.Text = "Modificar seleccionado";
            btnModificarEjercicio.UseVisualStyleBackColor = true;
            btnModificarEjercicio.Click += btnModificarEjercicio_Click;
            // 
            // btnEliminarEjercicio
            // 
            btnEliminarEjercicio.Location = new Point(285, 222);
            btnEliminarEjercicio.Name = "btnEliminarEjercicio";
            btnEliminarEjercicio.Size = new Size(100, 28);
            btnEliminarEjercicio.TabIndex = 18;
            btnEliminarEjercicio.Text = "Eliminar";
            btnEliminarEjercicio.UseVisualStyleBackColor = true;
            btnEliminarEjercicio.Click += btnEliminarEjercicio_Click;
            // 
            // btnSubirEjercicio
            // 
            btnSubirEjercicio.Location = new Point(410, 222);
            btnSubirEjercicio.Name = "btnSubirEjercicio";
            btnSubirEjercicio.Size = new Size(90, 28);
            btnSubirEjercicio.TabIndex = 19;
            btnSubirEjercicio.Text = "▲ Subir";
            btnSubirEjercicio.UseVisualStyleBackColor = true;
            btnSubirEjercicio.Click += btnSubirEjercicio_Click;
            // 
            // btnBajarEjercicio
            // 
            btnBajarEjercicio.Location = new Point(510, 222);
            btnBajarEjercicio.Name = "btnBajarEjercicio";
            btnBajarEjercicio.Size = new Size(90, 28);
            btnBajarEjercicio.TabIndex = 20;
            btnBajarEjercicio.Text = "▼ Bajar";
            btnBajarEjercicio.UseVisualStyleBackColor = true;
            btnBajarEjercicio.Click += btnBajarEjercicio_Click;
            // 
            // dgvEjercicios
            // 
            dgvEjercicios.AllowUserToAddRows = false;
            dgvEjercicios.AllowUserToDeleteRows = false;
            dgvEjercicios.AllowUserToResizeRows = false;
            dgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEjercicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEjercicios.Location = new Point(15, 258);
            dgvEjercicios.MultiSelect = false;
            dgvEjercicios.Name = "dgvEjercicios";
            dgvEjercicios.ReadOnly = true;
            dgvEjercicios.RowHeadersVisible = false;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEjercicios.Size = new Size(585, 228);
            dgvEjercicios.TabIndex = 21;
            dgvEjercicios.SelectionChanged += dgvEjercicios_SelectionChanged;
            // 
            // lblCamposObligatorios
            // 
            lblCamposObligatorios.AutoSize = true;
            lblCamposObligatorios.ForeColor = SystemColors.GrayText;
            lblCamposObligatorios.Location = new Point(20, 571);
            lblCamposObligatorios.Name = "lblCamposObligatorios";
            lblCamposObligatorios.Size = new Size(125, 15);
            lblCamposObligatorios.TabIndex = 3;
            lblCamposObligatorios.Text = "* Campos obligatorios";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(760, 562);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(170, 34);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar rutina";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(940, 562);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(140, 34);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar todo";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // FrmCrearRutina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 610);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(lblCamposObligatorios);
            Controls.Add(grpEjercicios);
            Controls.Add(grpDatosGenerales);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCrearRutina";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buddy - Crear rutina";
            Load += FrmCrearRutina_Load;
            grpDatosGenerales.ResumeLayout(false);
            grpDatosGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).EndInit();
            grpEjercicios.ResumeLayout(false);
            grpEjercicios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeries).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRepeticiones).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDescanso).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPesoRecomendado).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEjercicios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private GroupBox grpDatosGenerales;
        private Label lblEntrenador;
        private ComboBox cmbEntrenador;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblObjetivo;
        private ComboBox cmbObjetivo;
        private Label lblDificultad;
        private ComboBox cmbDificultad;
        private Label lblDuracion;
        private NumericUpDown nudDuracion;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblDias;
        private CheckedListBox clbDias;
        private GroupBox grpEjercicios;
        private Label lblDiaEjercicio;
        private ComboBox cmbDiaEjercicio;
        private Label lblNombreEjercicio;
        private TextBox txtNombreEjercicio;
        private Label lblDescripcionEjercicio;
        private TextBox txtDescripcionEjercicio;
        private Label lblSeries;
        private NumericUpDown nudSeries;
        private Label lblRepeticiones;
        private NumericUpDown nudRepeticiones;
        private Label lblDescanso;
        private NumericUpDown nudDescanso;
        private CheckBox chkPesoRecomendado;
        private NumericUpDown nudPesoRecomendado;
        private Label lblIndicaciones;
        private TextBox txtIndicaciones;
        private Button btnAgregarEjercicio;
        private Button btnModificarEjercicio;
        private Button btnEliminarEjercicio;
        private Button btnSubirEjercicio;
        private Button btnBajarEjercicio;
        private DataGridView dgvEjercicios;
        private Label lblCamposObligatorios;
        private Button btnGuardar;
        private Button btnLimpiar;
    }
}
