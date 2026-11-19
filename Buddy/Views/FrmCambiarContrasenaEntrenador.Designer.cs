namespace Buddy.Views
{
    partial class FrmCambiarContrasenaEntrenador
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
            lblEntrenador = new Label();
            lblContrasenaActual = new Label();
            txtContrasenaActual = new TextBox();
            lblContrasenaNueva = new Label();
            txtContrasenaNueva = new TextBox();
            lblConfirmarContrasena = new Label();
            txtConfirmarContrasena = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(130, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(206, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cambiar contraseña";
            //
            // lblEntrenador
            //
            lblEntrenador.AutoEllipsis = true;
            lblEntrenador.Location = new Point(25, 55);
            lblEntrenador.Name = "lblEntrenador";
            lblEntrenador.Size = new Size(415, 15);
            lblEntrenador.TabIndex = 1;
            lblEntrenador.Text = "Entrenador: —";
            //
            // lblContrasenaActual
            //
            lblContrasenaActual.AutoSize = true;
            lblContrasenaActual.Location = new Point(25, 90);
            lblContrasenaActual.Name = "lblContrasenaActual";
            lblContrasenaActual.Size = new Size(109, 15);
            lblContrasenaActual.TabIndex = 2;
            lblContrasenaActual.Text = "Contraseña actual: *";
            //
            // txtContrasenaActual
            //
            txtContrasenaActual.Location = new Point(185, 87);
            txtContrasenaActual.MaxLength = 100;
            txtContrasenaActual.Name = "txtContrasenaActual";
            txtContrasenaActual.Size = new Size(255, 23);
            txtContrasenaActual.TabIndex = 3;
            txtContrasenaActual.UseSystemPasswordChar = true;
            //
            // lblContrasenaNueva
            //
            lblContrasenaNueva.AutoSize = true;
            lblContrasenaNueva.Location = new Point(25, 125);
            lblContrasenaNueva.Name = "lblContrasenaNueva";
            lblContrasenaNueva.Size = new Size(108, 15);
            lblContrasenaNueva.TabIndex = 4;
            lblContrasenaNueva.Text = "Contraseña nueva: *";
            //
            // txtContrasenaNueva
            //
            txtContrasenaNueva.Location = new Point(185, 122);
            txtContrasenaNueva.MaxLength = 100;
            txtContrasenaNueva.Name = "txtContrasenaNueva";
            txtContrasenaNueva.PlaceholderText = "Mínimo 8 caracteres";
            txtContrasenaNueva.Size = new Size(255, 23);
            txtContrasenaNueva.TabIndex = 5;
            txtContrasenaNueva.UseSystemPasswordChar = true;
            //
            // lblConfirmarContrasena
            //
            lblConfirmarContrasena.AutoSize = true;
            lblConfirmarContrasena.Location = new Point(25, 160);
            lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            lblConfirmarContrasena.Size = new Size(134, 15);
            lblConfirmarContrasena.TabIndex = 6;
            lblConfirmarContrasena.Text = "Confirmar contraseña: *";
            //
            // txtConfirmarContrasena
            //
            txtConfirmarContrasena.Location = new Point(185, 157);
            txtConfirmarContrasena.MaxLength = 100;
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.Size = new Size(255, 23);
            txtConfirmarContrasena.TabIndex = 7;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(185, 200);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 32);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(315, 200);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(125, 32);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            //
            // FrmCambiarContrasenaEntrenador
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(465, 250);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtConfirmarContrasena);
            Controls.Add(lblConfirmarContrasena);
            Controls.Add(txtContrasenaNueva);
            Controls.Add(lblContrasenaNueva);
            Controls.Add(txtContrasenaActual);
            Controls.Add(lblContrasenaActual);
            Controls.Add(lblEntrenador);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCambiarContrasenaEntrenador";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buddy - Cambiar contraseña";
            Load += FrmCambiarContrasenaEntrenador_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblEntrenador;
        private Label lblContrasenaActual;
        private TextBox txtContrasenaActual;
        private Label lblContrasenaNueva;
        private TextBox txtContrasenaNueva;
        private Label lblConfirmarContrasena;
        private TextBox txtConfirmarContrasena;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
