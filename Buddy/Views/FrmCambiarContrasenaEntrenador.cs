using System;
using System.IO;
using System.Windows.Forms;
using Buddy.Controllers;
using Buddy.Models;

namespace Buddy.Views
{
    public partial class FrmCambiarContrasenaEntrenador : Form
    {
        // Controlador compartido con el resto de formularios.
        private readonly EntrenadorController entrenadorController;

        private readonly int idEntrenador;

        public FrmCambiarContrasenaEntrenador(
            EntrenadorController entrenadorController,
            int idEntrenador)
        {
            InitializeComponent();

            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));
            this.idEntrenador = idEntrenador;
        }

        private void FrmCambiarContrasenaEntrenador_Load(object sender, EventArgs e)
        {
            Entrenador? entrenador = entrenadorController.ObtenerEntrenadorPorId(idEntrenador);

            if (entrenador == null)
            {
                MessageBox.Show(
                    "El entrenador seleccionado ya no existe.",
                    "Buddy - Cambiar contraseña",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            lblEntrenador.Text =
                $"Entrenador: {entrenador.NombreCompleto} ({entrenador.NombreUsuario})";
        }

        private bool ValidarCampos()
        {
            if (txtContrasenaActual.Text.Length == 0)
                return Advertir("Debe ingresar la contraseña actual.", txtContrasenaActual);

            if (txtContrasenaNueva.Text.Length < EntrenadorController.LongitudMinimaContrasena)
                return Advertir(
                    $"La contraseña debe tener al menos " +
                    $"{EntrenadorController.LongitudMinimaContrasena} caracteres.",
                    txtContrasenaNueva);

            if (txtContrasenaNueva.Text != txtConfirmarContrasena.Text)
                return Advertir(
                    "La confirmación no coincide con la contraseña.", txtConfirmarContrasena);

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                // El controlador verifica la contraseña actual y guarda
                // únicamente el hash de la nueva contraseña.
                entrenadorController.CambiarContrasena(
                    idEntrenador,
                    txtContrasenaActual.Text,
                    txtContrasenaNueva.Text,
                    txtConfirmarContrasena.Text);

                MessageBox.Show(
                    "La contraseña se cambió correctamente.",
                    "Buddy - Contraseña actualizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                if (ex.Message.Contains("actual", StringComparison.OrdinalIgnoreCase) &&
                    !ex.Message.Contains("distinta", StringComparison.OrdinalIgnoreCase))
                {
                    txtContrasenaActual.Clear();
                    Advertir(ex.Message, txtContrasenaActual);
                }
                else if (ex.Message.Contains("confirmación", StringComparison.OrdinalIgnoreCase))
                {
                    Advertir(ex.Message, txtConfirmarContrasena);
                }
                else
                {
                    Advertir(ex.Message, txtContrasenaNueva);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buddy - Protección de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex) when (
                ex is IOException ||
                ex is UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "No se pudo guardar la nueva contraseña. " +
                    "La contraseña anterior sigue vigente.\n\n" +
                    ex.Message,
                    "Buddy - Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Muestra el aviso, enfoca el campo y devuelve false.
        private bool Advertir(string mensaje, Control control)
        {
            MessageBox.Show(
                mensaje,
                "Error al cambiar la contraseña",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control.Focus();
            return false;
        }
    }
}
