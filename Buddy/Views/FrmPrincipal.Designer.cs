namespace Buddy.Views
{
    partial class FrmPrincipal
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
            lblSubtitulo = new Label();
            grpUsuarios = new GroupBox();
            btnConsultarUsuarios = new Button();
            btnRegistrarUsuario = new Button();
            grpEntrenadores = new GroupBox();
            btnRegistrarEntrenador = new Button();
            btnConsultarEntrenadores = new Button();
            grpUsuarios.SuspendLayout();
            grpEntrenadores.SuspendLayout();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(162, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(96, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Buddy";
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.Location = new Point(123, 67);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(174, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema de Gestión Fitness";
            //
            // grpUsuarios
            //
            grpUsuarios.Controls.Add(btnConsultarUsuarios);
            grpUsuarios.Controls.Add(btnRegistrarUsuario);
            grpUsuarios.Location = new Point(40, 105);
            grpUsuarios.Name = "grpUsuarios";
            grpUsuarios.Size = new Size(340, 120);
            grpUsuarios.TabIndex = 2;
            grpUsuarios.TabStop = false;
            grpUsuarios.Text = "Usuarios";
            //
            // btnConsultarUsuarios
            //
            btnConsultarUsuarios.Location = new Point(20, 30);
            btnConsultarUsuarios.Name = "btnConsultarUsuarios";
            btnConsultarUsuarios.Size = new Size(300, 35);
            btnConsultarUsuarios.TabIndex = 0;
            btnConsultarUsuarios.Text = "Consultar y actualizar usuarios";
            btnConsultarUsuarios.UseVisualStyleBackColor = true;
            btnConsultarUsuarios.Click += btnConsultarUsuarios_Click;
            //
            // btnRegistrarUsuario
            //
            btnRegistrarUsuario.Location = new Point(20, 72);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(300, 35);
            btnRegistrarUsuario.TabIndex = 1;
            btnRegistrarUsuario.Text = "Registrar usuario";
            btnRegistrarUsuario.UseVisualStyleBackColor = true;
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            //
            // grpEntrenadores
            //
            grpEntrenadores.Controls.Add(btnConsultarEntrenadores);
            grpEntrenadores.Controls.Add(btnRegistrarEntrenador);
            grpEntrenadores.Location = new Point(40, 240);
            grpEntrenadores.Name = "grpEntrenadores";
            grpEntrenadores.Size = new Size(340, 120);
            grpEntrenadores.TabIndex = 3;
            grpEntrenadores.TabStop = false;
            grpEntrenadores.Text = "Entrenadores";
            //
            // btnRegistrarEntrenador
            //
            btnRegistrarEntrenador.Location = new Point(20, 72);
            btnRegistrarEntrenador.Name = "btnRegistrarEntrenador";
            btnRegistrarEntrenador.Size = new Size(300, 35);
            btnRegistrarEntrenador.TabIndex = 1;
            btnRegistrarEntrenador.Text = "Registrar entrenador";
            btnRegistrarEntrenador.UseVisualStyleBackColor = true;
            btnRegistrarEntrenador.Click += btnRegistrarEntrenador_Click;
            //
            // btnConsultarEntrenadores
            //
            btnConsultarEntrenadores.Location = new Point(20, 30);
            btnConsultarEntrenadores.Name = "btnConsultarEntrenadores";
            btnConsultarEntrenadores.Size = new Size(300, 35);
            btnConsultarEntrenadores.TabIndex = 0;
            btnConsultarEntrenadores.Text = "Consultar y actualizar entrenadores";
            btnConsultarEntrenadores.UseVisualStyleBackColor = true;
            btnConsultarEntrenadores.Click += btnConsultarEntrenadores_Click;
            //
            // FrmPrincipal
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 390);
            Controls.Add(grpEntrenadores);
            Controls.Add(grpUsuarios);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buddy - Menú principal";
            grpUsuarios.ResumeLayout(false);
            grpEntrenadores.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private GroupBox grpUsuarios;
        private Button btnConsultarUsuarios;
        private Button btnRegistrarUsuario;
        private GroupBox grpEntrenadores;
        private Button btnRegistrarEntrenador;
        private Button btnConsultarEntrenadores;
    }
}
