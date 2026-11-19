using System;
using System.IO;
using System.Windows.Forms;
using Buddy.Controllers;
using Buddy.Models;

namespace Buddy.Views
{
    public partial class FrmRegistroEntrenador : Form
    {
        // Controlador compartido con el resto de formularios.
        private readonly EntrenadorController entrenadorController;

        public FrmRegistroEntrenador(EntrenadorController entrenadorController)
        {
            InitializeComponent();

            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));
        }

        // Elemento de las listas desplegables con su texto en español.
        private sealed class OpcionLista<T> where T : struct, Enum
        {
            public T Valor { get; }
            public string Texto { get; }

            public OpcionLista(T valor, string texto)
            {
                Valor = valor;
                Texto = texto;
            }

            public override string ToString() => Texto;
        }

        public static string ObtenerTexto(TipoEntrenador tipo) => tipo switch
        {
            TipoEntrenador.EntrenadorPersonal => "Entrenador personal",
            TipoEntrenador.InstructorClasesGrupales => "Instructor de clases grupales",
            _ => tipo.ToString()
        };

        public static string ObtenerTexto(EspecialidadEntrenador especialidad) => especialidad switch
        {
            EspecialidadEntrenador.EntrenamientoFuerza => "Entrenamiento de fuerza",
            EspecialidadEntrenador.AcondicionamientoFisico => "Acondicionamiento físico",
            EspecialidadEntrenador.Yoga => "Yoga",
            EspecialidadEntrenador.Zumba => "Zumba",
            EspecialidadEntrenador.Spinning => "Spinning",
            EspecialidadEntrenador.Crossfit => "Crossfit",
            _ => especialidad.ToString()
        };

        private void FrmRegistroEntrenador_Load(object sender, EventArgs e)
        {
            // La fecha de nacimiento debe ser anterior a hoy.
            dtpFechaNacimiento.MaxDate = DateTime.Today.AddDays(-1);

            cmbTipo.Items.Clear();
            foreach (TipoEntrenador tipo in Enum.GetValues<TipoEntrenador>())
                cmbTipo.Items.Add(new OpcionLista<TipoEntrenador>(tipo, ObtenerTexto(tipo)));

            cmbEspecialidad.Items.Clear();
            foreach (EspecialidadEntrenador especialidad in Enum.GetValues<EspecialidadEntrenador>())
                cmbEspecialidad.Items.Add(
                    new OpcionLista<EspecialidadEntrenador>(especialidad, ObtenerTexto(especialidad)));

            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();
            txtCertificaciones.Clear();

            // Sin fecha seleccionada hasta que se marque la casilla.
            dtpFechaNacimiento.Value = dtpFechaNacimiento.MaxDate;
            dtpFechaNacimiento.Checked = false;

            cmbTipo.SelectedIndex = -1;
            cmbEspecialidad.SelectedIndex = -1;
            nudAniosExperiencia.Value = 0;

            txtIdentificacion.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                return Advertir("Debe ingresar la identificación.", txtIdentificacion);

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                return Advertir("Debe ingresar el nombre.", txtNombre);

            if (string.IsNullOrWhiteSpace(txtPrimerApellido.Text))
                return Advertir("Debe ingresar el primer apellido.", txtPrimerApellido);

            if (!dtpFechaNacimiento.Checked)
                return Advertir(
                    "Debe seleccionar la fecha de nacimiento (marque la casilla de la fecha).",
                    dtpFechaNacimiento);

            if (dtpFechaNacimiento.Value.Date >= DateTime.Today)
                return Advertir(
                    "La fecha de nacimiento debe ser anterior a hoy.", dtpFechaNacimiento);

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                return Advertir("Debe ingresar el número de teléfono.", txtTelefono);

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                return Advertir("Debe ingresar un correo electrónico.", txtCorreo);

            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
                return Advertir("Debe ingresar un nombre de usuario.", txtNombreUsuario);

            if (txtContrasena.Text.Length < EntrenadorController.LongitudMinimaContrasena)
                return Advertir(
                    $"La contraseña debe tener al menos " +
                    $"{EntrenadorController.LongitudMinimaContrasena} caracteres.",
                    txtContrasena);

            if (txtContrasena.Text != txtConfirmarContrasena.Text)
                return Advertir(
                    "La confirmación no coincide con la contraseña.", txtConfirmarContrasena);

            if (cmbTipo.SelectedItem is not OpcionLista<TipoEntrenador>)
                return Advertir("Debe seleccionar el tipo de entrenador.", cmbTipo);

            if (cmbEspecialidad.SelectedItem is not OpcionLista<EspecialidadEntrenador>)
                return Advertir("Debe seleccionar una especialidad.", cmbEspecialidad);

            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            var tipo = (OpcionLista<TipoEntrenador>)cmbTipo.SelectedItem!;
            var especialidad = (OpcionLista<EspecialidadEntrenador>)cmbEspecialidad.SelectedItem!;

            try
            {
                // El controlador valida formatos y duplicados,
                // protege la contraseña y guarda en JSON.
                Entrenador nuevo = entrenadorController.RegistrarEntrenador(
                    identificacion: txtIdentificacion.Text,
                    nombre: txtNombre.Text,
                    primerApellido: txtPrimerApellido.Text,
                    segundoApellido: txtSegundoApellido.Text,
                    fechaNacimiento: dtpFechaNacimiento.Value.Date,
                    correoElectronico: txtCorreo.Text,
                    nombreUsuario: txtNombreUsuario.Text,
                    telefono: txtTelefono.Text,
                    contrasena: txtContrasena.Text,
                    confirmacionContrasena: txtConfirmarContrasena.Text,
                    tipo: tipo.Valor,
                    especialidad: especialidad.Valor,
                    certificaciones: txtCertificaciones.Text,
                    aniosExperiencia: (int)nudAniosExperiencia.Value);

                MessageBox.Show(
                    "Entrenador registrado correctamente.\n\n" +
                    $"ID: {nuevo.Id}\n" +
                    $"Identificación: {nuevo.Identificacion}\n" +
                    $"Nombre: {nuevo.NombreCompleto}\n" +
                    $"Usuario: {nuevo.NombreUsuario}\n" +
                    $"Correo: {nuevo.CorreoElectronico}\n" +
                    $"Teléfono: {nuevo.Telefono}\n" +
                    $"Edad: {nuevo.Edad} años\n" +
                    $"Tipo: {ObtenerTexto(nuevo.Tipo)}\n" +
                    $"Especialidad: {ObtenerTexto(nuevo.Especialidad)}\n" +
                    $"Experiencia: {nuevo.AniosExperiencia} años\n" +
                    $"Rol: {nuevo.Rol}\n" +
                    $"Estado: {nuevo.Estado}\n" +
                    $"Fecha de registro: {nuevo.FechaRegistro:g}",
                    "Buddy - Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (ArgumentException ex)
            {
                Advertir(ex.Message, ObtenerControlDelError(ex.Message));
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
                    "No se pudo guardar el entrenador. " +
                    "Los datos existentes se conservaron sin modificaciones.\n\n" +
                    ex.Message,
                    "Buddy - Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Indica qué campo corregir según el mensaje del controlador.
        private Control? ObtenerControlDelError(string mensaje)
        {
            bool Contiene(string texto) =>
                mensaje.Contains(texto, StringComparison.OrdinalIgnoreCase);

            if (Contiene("identificación")) return txtIdentificacion;
            if (Contiene("correo")) return txtCorreo;
            if (Contiene("nombre de usuario")) return txtNombreUsuario;
            if (Contiene("teléfono")) return txtTelefono;
            if (Contiene("confirmación")) return txtConfirmarContrasena;
            if (Contiene("contraseña")) return txtContrasena;
            if (Contiene("primer apellido")) return txtPrimerApellido;
            if (Contiene("nombre")) return txtNombre;
            if (Contiene("fecha")) return dtpFechaNacimiento;
            if (Contiene("tipo")) return cmbTipo;
            if (Contiene("especialidad")) return cmbEspecialidad;
            if (Contiene("experiencia")) return nudAniosExperiencia;

            return null;
        }

        // Muestra el aviso, enfoca el campo y devuelve false.
        private bool Advertir(string mensaje, Control? control)
        {
            MessageBox.Show(
                mensaje,
                "Error de registro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control?.Focus();
            return false;
        }
    }
}
