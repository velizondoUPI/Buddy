namespace Buddy.Views
{
    partial class FrmConsultaUsuarios
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
            label2 = new Label();
            lblBuscar = new Label();
            txtBuscarUsuario = new TextBox();
            dgvUsuarios = new DataGridView();
            grpDetalleUsuario = new GroupBox();
            lblDetalleIMC = new Label();
            lblIMCTitulo = new Label();
            lblDetalleAltura = new Label();
            lblAlturaTitulo = new Label();
            lblDetallePeso = new Label();
            lblPesoTitulo = new Label();
            lblDetalleEdad = new Label();
            lblEdadTitulo = new Label();
            lblDetalleCorreo = new Label();
            lblCorreoTitulo = new Label();
            lblDetalleUsuario = new Label();
            lblUsuarioTitulo = new Label();
            lblDetalleNombre = new Label();
            lblNombreTitulo = new Label();
            btnActualizarUsuario = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            grpDetalleUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(350, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(215, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consulta de Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(350, 65);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 1;
            label2.Click += label2_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F);
            lblBuscar.Location = new Point(305, 81);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(101, 19);
            lblBuscar.TabIndex = 2;
            lblBuscar.Text = "Buscar usuario:";
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Font = new Font("Segoe UI", 10F);
            txtBuscarUsuario.Location = new Point(412, 81);
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.Size = new Size(142, 25);
            txtBuscarUsuario.TabIndex = 3;
            txtBuscarUsuario.TextChanged += textBox1_TextChanged;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(148, 121);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(687, 277);
            dgvUsuarios.TabIndex = 4;
            dgvUsuarios.CellContentClick += dgvUsuarios_CellContentClick;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            // 
            // grpDetalleUsuario
            // 
            grpDetalleUsuario.Controls.Add(lblDetalleIMC);
            grpDetalleUsuario.Controls.Add(lblIMCTitulo);
            grpDetalleUsuario.Controls.Add(lblDetalleAltura);
            grpDetalleUsuario.Controls.Add(lblAlturaTitulo);
            grpDetalleUsuario.Controls.Add(lblDetallePeso);
            grpDetalleUsuario.Controls.Add(lblPesoTitulo);
            grpDetalleUsuario.Controls.Add(lblDetalleEdad);
            grpDetalleUsuario.Controls.Add(lblEdadTitulo);
            grpDetalleUsuario.Controls.Add(lblDetalleCorreo);
            grpDetalleUsuario.Controls.Add(lblCorreoTitulo);
            grpDetalleUsuario.Controls.Add(lblDetalleUsuario);
            grpDetalleUsuario.Controls.Add(lblUsuarioTitulo);
            grpDetalleUsuario.Controls.Add(lblDetalleNombre);
            grpDetalleUsuario.Controls.Add(lblNombreTitulo);
            grpDetalleUsuario.Location = new Point(148, 404);
            grpDetalleUsuario.Name = "grpDetalleUsuario";
            grpDetalleUsuario.Size = new Size(687, 145);
            grpDetalleUsuario.TabIndex = 5;
            grpDetalleUsuario.TabStop = false;
            grpDetalleUsuario.Text = "Detalles del usuario";
            // 
            // lblDetalleIMC
            // 
            lblDetalleIMC.AutoSize = true;
            lblDetalleIMC.Location = new Point(478, 87);
            lblDetalleIMC.Name = "lblDetalleIMC";
            lblDetalleIMC.Size = new Size(19, 15);
            lblDetalleIMC.TabIndex = 13;
            lblDetalleIMC.Text = "—";
            // 
            // lblIMCTitulo
            // 
            lblIMCTitulo.AutoSize = true;
            lblIMCTitulo.Location = new Point(440, 87);
            lblIMCTitulo.Name = "lblIMCTitulo";
            lblIMCTitulo.Size = new Size(32, 15);
            lblIMCTitulo.TabIndex = 12;
            lblIMCTitulo.Text = "IMC:";
            // 
            // lblDetalleAltura
            // 
            lblDetalleAltura.AutoSize = true;
            lblDetalleAltura.Location = new Point(310, 87);
            lblDetalleAltura.Name = "lblDetalleAltura";
            lblDetalleAltura.Size = new Size(19, 15);
            lblDetalleAltura.TabIndex = 11;
            lblDetalleAltura.Text = "—";
            // 
            // lblAlturaTitulo
            // 
            lblAlturaTitulo.AutoSize = true;
            lblAlturaTitulo.Location = new Point(262, 87);
            lblAlturaTitulo.Name = "lblAlturaTitulo";
            lblAlturaTitulo.Size = new Size(42, 15);
            lblAlturaTitulo.TabIndex = 10;
            lblAlturaTitulo.Text = "Altura:";
            // 
            // lblDetallePeso
            // 
            lblDetallePeso.AutoSize = true;
            lblDetallePeso.Location = new Point(50, 89);
            lblDetallePeso.Name = "lblDetallePeso";
            lblDetallePeso.Size = new Size(19, 15);
            lblDetallePeso.TabIndex = 9;
            lblDetallePeso.Text = "—";
            // 
            // lblPesoTitulo
            // 
            lblPesoTitulo.AutoSize = true;
            lblPesoTitulo.Location = new Point(15, 87);
            lblPesoTitulo.Name = "lblPesoTitulo";
            lblPesoTitulo.Size = new Size(35, 15);
            lblPesoTitulo.TabIndex = 8;
            lblPesoTitulo.Text = "Peso:";
            // 
            // lblDetalleEdad
            // 
            lblDetalleEdad.AutoSize = true;
            lblDetalleEdad.Location = new Point(304, 62);
            lblDetalleEdad.Name = "lblDetalleEdad";
            lblDetalleEdad.Size = new Size(19, 15);
            lblDetalleEdad.TabIndex = 7;
            lblDetalleEdad.Text = "—";
            // 
            // lblEdadTitulo
            // 
            lblEdadTitulo.AutoSize = true;
            lblEdadTitulo.Location = new Point(262, 62);
            lblEdadTitulo.Name = "lblEdadTitulo";
            lblEdadTitulo.Size = new Size(36, 15);
            lblEdadTitulo.TabIndex = 6;
            lblEdadTitulo.Text = "Edad:";
            // 
            // lblDetalleCorreo
            // 
            lblDetalleCorreo.AutoSize = true;
            lblDetalleCorreo.Location = new Point(63, 62);
            lblDetalleCorreo.Name = "lblDetalleCorreo";
            lblDetalleCorreo.Size = new Size(19, 15);
            lblDetalleCorreo.TabIndex = 5;
            lblDetalleCorreo.Text = "—";
            // 
            // lblCorreoTitulo
            // 
            lblCorreoTitulo.AutoSize = true;
            lblCorreoTitulo.Location = new Point(15, 62);
            lblCorreoTitulo.Name = "lblCorreoTitulo";
            lblCorreoTitulo.Size = new Size(46, 15);
            lblCorreoTitulo.TabIndex = 4;
            lblCorreoTitulo.Text = "Correo:";
            // 
            // lblDetalleUsuario
            // 
            lblDetalleUsuario.AutoSize = true;
            lblDetalleUsuario.Location = new Point(318, 40);
            lblDetalleUsuario.Name = "lblDetalleUsuario";
            lblDetalleUsuario.Size = new Size(19, 15);
            lblDetalleUsuario.TabIndex = 3;
            lblDetalleUsuario.Text = "—";
            // 
            // lblUsuarioTitulo
            // 
            lblUsuarioTitulo.AutoSize = true;
            lblUsuarioTitulo.Location = new Point(262, 40);
            lblUsuarioTitulo.Name = "lblUsuarioTitulo";
            lblUsuarioTitulo.Size = new Size(50, 15);
            lblUsuarioTitulo.TabIndex = 2;
            lblUsuarioTitulo.Text = "Usuario:";
            // 
            // lblDetalleNombre
            // 
            lblDetalleNombre.AutoSize = true;
            lblDetalleNombre.Location = new Point(75, 37);
            lblDetalleNombre.Name = "lblDetalleNombre";
            lblDetalleNombre.Size = new Size(19, 15);
            lblDetalleNombre.TabIndex = 1;
            lblDetalleNombre.Text = "—";
            // 
            // lblNombreTitulo
            // 
            lblNombreTitulo.AutoSize = true;
            lblNombreTitulo.Location = new Point(15, 37);
            lblNombreTitulo.Name = "lblNombreTitulo";
            lblNombreTitulo.Size = new Size(54, 15);
            lblNombreTitulo.TabIndex = 0;
            lblNombreTitulo.Text = "Nombre:";
            //
            // btnActualizarUsuario
            //
            btnActualizarUsuario.Location = new Point(705, 79);
            btnActualizarUsuario.Name = "btnActualizarUsuario";
            btnActualizarUsuario.Size = new Size(130, 28);
            btnActualizarUsuario.TabIndex = 6;
            btnActualizarUsuario.Text = "Actualizar usuario";
            btnActualizarUsuario.UseVisualStyleBackColor = true;
            btnActualizarUsuario.Click += btnActualizarUsuario_Click;
            //
            // FrmConsultaUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 561);
            Controls.Add(btnActualizarUsuario);
            Controls.Add(grpDetalleUsuario);
            Controls.Add(dgvUsuarios);
            Controls.Add(txtBuscarUsuario);
            Controls.Add(lblBuscar);
            Controls.Add(label2);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmConsultaUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "\tBuddy - Consulta de usuarios";
            Load += FrmConsultaUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            grpDetalleUsuario.ResumeLayout(false);
            grpDetalleUsuario.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label label2;
        private Label lblBuscar;
        private TextBox txtBuscarUsuario;
        private DataGridView dgvUsuarios;
        private GroupBox grpDetalleUsuario;
        private Label lblDetalleNombre;
        private Label lblNombreTitulo;
        private Label lblEdadTitulo;
        private Label lblDetalleCorreo;
        private Label lblCorreoTitulo;
        private Label lblDetalleUsuario;
        private Label lblUsuarioTitulo;
        private Label lblIMCTitulo;
        private Label lblDetalleAltura;
        private Label lblAlturaTitulo;
        private Label lblDetallePeso;
        private Label lblPesoTitulo;
        private Label lblDetalleEdad;
        private Label lblDetalleIMC;
        private Button btnActualizarUsuario;
    }
}