using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Buddy.Models;
using Buddy.Controllers;

namespace Buddy.Views
{
    public partial class FrmRegistroUsuario : Form
    {

        private readonly UsuarioController usuarioController = new UsuarioController();
        public FrmRegistroUsuario()
        {

            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtNombreUsuario.Clear();
            txtCorreoElectronico.Clear();

            dtpFechaNacimiento.Value = dtpFechaNacimiento.MaxDate;

            nudPesoKg.Value = 0;
            nudAlturaMetros.Value = 0;

            txtNombre.Focus();
        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre completo.");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.");
                txtNombreUsuario.Focus();
                return;
            }

            if (dtpFechaNacimiento.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento debe ser anterior a hoy.");
                dtpFechaNacimiento.Focus();
                return;
            }

            if (nudPesoKg.Value <= 0)
            {
                MessageBox.Show("Debe ingresar un peso mayor a cero.");
                nudPesoKg.Focus();
                return;
            }

            if (nudAlturaMetros.Value <= 0)
            {
                MessageBox.Show("Debe ingresar una altura mayor a cero.");
                nudAlturaMetros.Focus();
                return;
            }

            try
            {

                Usuario nuevoUsuario = usuarioController.RegistrarUsuario(
                    txtNombre.Text,
                    txtNombreUsuario.Text,
                    dtpFechaNacimiento.Value.Date,
                    nudPesoKg.Value,
                    nudAlturaMetros.Value,
                    txtCorreoElectronico.Text
                );



                MessageBox.Show(
                    $"Usuario registrado correctamente.\n\n" +
                    $"ID: {nuevoUsuario.Id}\n" +
                    $"Nombre: {nuevoUsuario.Nombre}\n" +
                    $"Usuario: {nuevoUsuario.NombreUsuario}\n" +
                    $"Correo: {nuevoUsuario.CorreoElectronico}\n" +
                    $"Edad: {nuevoUsuario.Edad} años\n" +
                    $"Peso: {nuevoUsuario.PesoKg} kg\n" +
                    $"Altura: {nuevoUsuario.AlturaMetros} m\n" +
                    $"IMC: {nuevoUsuario.IMC:F2}",
                    "Buddy - Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );



                LimpiarCampos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error de registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }


            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buddy - Protección de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }
    }
}
