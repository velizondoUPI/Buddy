using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buddy.Controllers;
using Buddy.Models;

namespace Buddy.Views
{
    public partial class FrmActualizarUsuario : Form
    {
        // Controlador compartido con el resto de formularios.
        private readonly UsuarioController usuarioController;

        // Usuario que debe quedar seleccionado al abrir el formulario.
        private readonly int? idUsuarioInicial;

        // Identificador del usuario guardado correctamente.
        public int? IdUsuarioActualizado { get; private set; }

        public FrmActualizarUsuario(
            UsuarioController usuarioController,
            int? idUsuarioInicial = null)
        {
            InitializeComponent();

            this.usuarioController = usuarioController
                ?? throw new ArgumentNullException(nameof(usuarioController));
            this.idUsuarioInicial = idUsuarioInicial;
        }

        // Elemento que se muestra en la lista de usuarios.
        private sealed class OpcionUsuario
        {
            public int Id { get; }
            public string Texto { get; }

            public OpcionUsuario(Usuario usuario)
            {
                Id = usuario.Id;
                Texto = $"{usuario.Nombre} ({usuario.NombreUsuario})";
            }

            public override string ToString() => Texto;
        }

        private void FrmActualizarUsuario_Load(object sender, EventArgs e)
        {
            // La fecha de nacimiento debe ser anterior a hoy.
            dtpFechaNacimiento.MaxDate = DateTime.Today.AddDays(-1);

            CargarListaUsuarios();
        }

        private void CargarListaUsuarios()
        {
            List<Usuario> usuarios = usuarioController
                .ObtenerUsuarios()
                .OrderBy(u => u.Nombre, StringComparer.CurrentCultureIgnoreCase)
                .ToList();

            cmbUsuarios.Items.Clear();

            foreach (Usuario usuario in usuarios)
            {
                cmbUsuarios.Items.Add(new OpcionUsuario(usuario));
            }

            if (cmbUsuarios.Items.Count == 0)
            {
                HabilitarEdicion(false);

                MessageBox.Show(
                    "No hay usuarios registrados para actualizar.",
                    "Buddy - Actualizar usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Seleccionar el usuario indicado o, si no existe, el primero.
            int indice = 0;

            if (idUsuarioInicial.HasValue)
            {
                for (int i = 0; i < cmbUsuarios.Items.Count; i++)
                {
                    if (cmbUsuarios.Items[i] is OpcionUsuario opcion &&
                        opcion.Id == idUsuarioInicial.Value)
                    {
                        indice = i;
                        break;
                    }
                }
            }

            cmbUsuarios.SelectedIndex = indice;
        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario? usuario = ObtenerUsuarioSeleccionado();

            if (usuario == null)
            {
                HabilitarEdicion(false);
                return;
            }

            MostrarDatosUsuario(usuario);
            HabilitarEdicion(true);
        }

        private Usuario? ObtenerUsuarioSeleccionado()
        {
            if (cmbUsuarios.SelectedItem is not OpcionUsuario opcion)
                return null;

            // Consultar siempre los datos actuales del controlador.
            return usuarioController
                .ObtenerUsuarios()
                .FirstOrDefault(u => u.Id == opcion.Id);
        }

        private void MostrarDatosUsuario(Usuario usuario)
        {
            txtNombre.Text = usuario.Nombre;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtCorreo.Text = usuario.CorreoElectronico ?? string.Empty;

            dtpFechaNacimiento.Value = Limitar(
                usuario.FechaNacimiento.Date,
                dtpFechaNacimiento.MinDate,
                dtpFechaNacimiento.MaxDate);

            nudPesoKg.Value = Limitar(
                usuario.PesoKg, nudPesoKg.Minimum, nudPesoKg.Maximum);

            nudAlturaMetros.Value = Limitar(
                usuario.AlturaMetros, nudAlturaMetros.Minimum, nudAlturaMetros.Maximum);

            ActualizarIMC();
        }

        private void HabilitarEdicion(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtNombreUsuario.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;
            dtpFechaNacimiento.Enabled = habilitar;
            nudPesoKg.Enabled = habilitar;
            nudAlturaMetros.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;

            if (!habilitar)
                lblIMC.Text = "—";
        }

        private void nudDatosFisicos_ValueChanged(object sender, EventArgs e)
        {
            ActualizarIMC();
        }

        private void ActualizarIMC()
        {
            // Misma fórmula que Usuario.IMC, aplicada a los valores editados.
            if (nudPesoKg.Value <= 0 || nudAlturaMetros.Value <= 0)
            {
                lblIMC.Text = "—";
                return;
            }

            decimal imc = Math.Round(
                nudPesoKg.Value / (nudAlturaMetros.Value * nudAlturaMetros.Value),
                2);

            lblIMC.Text = imc.ToString("F2");
        }

        private bool ValidarCampos()
        {
            if (cmbUsuarios.SelectedItem is not OpcionUsuario)
            {
                MostrarAdvertencia("Debe seleccionar un usuario.", cmbUsuarios);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarAdvertencia("Debe ingresar el nombre completo.", txtNombre);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MostrarAdvertencia("Debe ingresar un nombre de usuario.", txtNombreUsuario);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MostrarAdvertencia("Debe ingresar un correo electrónico.", txtCorreo);
                return false;
            }

            if (dtpFechaNacimiento.Value.Date >= DateTime.Today)
            {
                MostrarAdvertencia(
                    "La fecha de nacimiento debe ser anterior a hoy.",
                    dtpFechaNacimiento);
                return false;
            }

            if (nudPesoKg.Value <= 0)
            {
                MostrarAdvertencia("Debe ingresar un peso mayor a cero.", nudPesoKg);
                return false;
            }

            if (nudAlturaMetros.Value <= 0)
            {
                MostrarAdvertencia("Debe ingresar una altura mayor a cero.", nudAlturaMetros);
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            int id = ((OpcionUsuario)cmbUsuarios.SelectedItem!).Id;

            try
            {
                // El controlador valida el formato del correo y los duplicados,
                // y guarda los cambios en el archivo JSON.
                usuarioController.ActualizarUsuario(
                    id,
                    txtNombre.Text,
                    txtNombreUsuario.Text,
                    dtpFechaNacimiento.Value.Date,
                    nudPesoKg.Value,
                    nudAlturaMetros.Value,
                    txtCorreo.Text);

                IdUsuarioActualizado = id;

                Usuario? actualizado = usuarioController
                    .ObtenerUsuarios()
                    .FirstOrDefault(u => u.Id == id);

                string resumen = actualizado == null
                    ? string.Empty
                    : $"\n\nNombre: {actualizado.Nombre}\n" +
                      $"Usuario: {actualizado.NombreUsuario}\n" +
                      $"Correo: {actualizado.CorreoElectronico}\n" +
                      $"Edad: {actualizado.Edad} años\n" +
                      $"Peso: {actualizado.PesoKg} kg\n" +
                      $"Altura: {actualizado.AlturaMetros} m\n" +
                      $"IMC: {actualizado.IMC:F2}";

                MessageBox.Show(
                    "Los datos del usuario se actualizaron correctamente." + resumen,
                    "Buddy - Actualización exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MostrarAdvertencia(ex.Message, ObtenerControlDelError(ex.Message));
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
                    "No se pudieron guardar los cambios. " +
                    "Los datos anteriores se conservaron sin modificaciones.\n\n" +
                    ex.Message,
                    "Buddy - Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Indica qué campo corregir según el mensaje del controlador.
        private Control? ObtenerControlDelError(string mensaje)
        {
            if (mensaje.Contains("correo", StringComparison.OrdinalIgnoreCase))
                return txtCorreo;

            if (mensaje.Contains("nombre de usuario", StringComparison.OrdinalIgnoreCase))
                return txtNombreUsuario;

            if (mensaje.Contains("nombre", StringComparison.OrdinalIgnoreCase))
                return txtNombre;

            return null;
        }

        private void MostrarAdvertencia(string mensaje, Control? control)
        {
            MessageBox.Show(
                mensaje,
                "Error de actualización",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control?.Focus();
        }

        private static T Limitar<T>(T valor, T minimo, T maximo)
            where T : IComparable<T>
        {
            if (valor.CompareTo(minimo) < 0)
                return minimo;

            if (valor.CompareTo(maximo) > 0)
                return maximo;

            return valor;
        }
    }
}
