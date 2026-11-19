namespace Buddy.Views
{
    partial class FrmConsultaAsignaciones
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
            lblVerPor = new Label();
            cmbVerPor = new ComboBox();
            lblPersona = new Label();
            cmbPersona = new ComboBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            lblResultados = new Label();
            dgvAsignaciones = new DataGridView();
            grpDetalle = new GroupBox();
            lblDetalle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAsignaciones).BeginInit();
            grpDetalle.SuspendLayout();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(340, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(310, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consulta de Rutinas Asignadas";
            //
            // lblVerPor
            //
            lblVerPor.AutoSize = true;
            lblVerPor.Location = new Point(20, 60);
            lblVerPor.Name = "lblVerPor";
            lblVerPor.Size = new Size(50, 15);
            lblVerPor.TabIndex = 1;
            lblVerPor.Text = "Ver por:";
            //
            // cmbVerPor
            //
            cmbVerPor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVerPor.FormattingEnabled = true;
            cmbVerPor.Location = new Point(80, 57);
            cmbVerPor.Name = "cmbVerPor";
            cmbVerPor.Size = new Size(130, 23);
            cmbVerPor.TabIndex = 2;
            cmbVerPor.SelectedIndexChanged += cmbVerPor_SelectedIndexChanged;
            //
            // lblPersona
            //
            lblPersona.AutoSize = true;
            lblPersona.Location = new Point(225, 60);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(50, 15);
            lblPersona.TabIndex = 3;
            lblPersona.Text = "Usuario:";
            //
            // cmbPersona
            //
            cmbPersona.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPersona.FormattingEnabled = true;
            cmbPersona.Location = new Point(300, 57);
            cmbPersona.Name = "cmbPersona";
            cmbPersona.Size = new Size(330, 23);
            cmbPersona.TabIndex = 4;
            cmbPersona.SelectedIndexChanged += Filtros_Changed;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(650, 60);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 5;
            lblEstado.Text = "Estado:";
            //
            // cmbEstado
            //
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(705, 57);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(150, 23);
            cmbEstado.TabIndex = 6;
            cmbEstado.SelectedIndexChanged += Filtros_Changed;
            //
            // lblResultados
            //
            lblResultados.AutoSize = true;
            lblResultados.Location = new Point(20, 92);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(0, 15);
            lblResultados.TabIndex = 7;
            //
            // dgvAsignaciones
            //
            dgvAsignaciones.AllowUserToAddRows = false;
            dgvAsignaciones.AllowUserToDeleteRows = false;
            dgvAsignaciones.AllowUserToResizeRows = false;
            dgvAsignaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAsignaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsignaciones.Location = new Point(20, 112);
            dgvAsignaciones.MultiSelect = false;
            dgvAsignaciones.Name = "dgvAsignaciones";
            dgvAsignaciones.ReadOnly = true;
            dgvAsignaciones.RowHeadersVisible = false;
            dgvAsignaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsignaciones.Size = new Size(960, 280);
            dgvAsignaciones.TabIndex = 8;
            dgvAsignaciones.SelectionChanged += dgvAsignaciones_SelectionChanged;
            //
            // grpDetalle
            //
            grpDetalle.Controls.Add(lblDetalle);
            grpDetalle.Location = new Point(20, 400);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Size = new Size(960, 150);
            grpDetalle.TabIndex = 9;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Detalle de la asignación";
            //
            // lblDetalle
            //
            lblDetalle.Location = new Point(15, 25);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(930, 115);
            lblDetalle.TabIndex = 0;
            lblDetalle.Text = "Seleccione una asignación para ver su detalle.";
            //
            // FrmConsultaAsignaciones
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 570);
            Controls.Add(grpDetalle);
            Controls.Add(dgvAsignaciones);
            Controls.Add(lblResultados);
            Controls.Add(cmbEstado);
            Controls.Add(lblEstado);
            Controls.Add(cmbPersona);
            Controls.Add(lblPersona);
            Controls.Add(cmbVerPor);
            Controls.Add(lblVerPor);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmConsultaAsignaciones";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buddy - Rutinas asignadas";
            Load += FrmConsultaAsignaciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAsignaciones).EndInit();
            grpDetalle.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblVerPor;
        private ComboBox cmbVerPor;
        private Label lblPersona;
        private ComboBox cmbPersona;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Label lblResultados;
        private DataGridView dgvAsignaciones;
        private GroupBox grpDetalle;
        private Label lblDetalle;
    }
}
