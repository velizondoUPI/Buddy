using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Buddy.Controllers;
using Buddy.Models;

namespace Buddy.Views
{
    public partial class FrmActualizarEntrenador : Form
    {
        // Controlador compartido con el resto de formularios.
        private readonly EntrenadorController entrenadorController;

        // Entrenador que debe quedar seleccionado al abrir el formulario.
        private readonly int? idEntrenadorInicial;

        // Identificador del entrenador guardado correctamente.
        public int? IdEntrenadorActualizado { get; private set; }

        public FrmActualizarEntrenador(
            EntrenadorController entrenadorController,
            int? idEntrenadorInicial = null)
        {
            InitializeComponent();

            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));
            this.idEntrenadorInicial = idEntrenadorInicial;
        }

        // Elemento que se muestra en la lista de entrenadores.
        private sealed class OpcionEntrenador
        {
            public int Id { get; }
            public string Texto { get; }

            public OpcionEntrenador(Entrenador entrenador)
            {
                Id = entrenador.Id;
                Texto = $"{entrenador.NombreCompleto} ({entrenador.NombreUsuario})";
            }

            public override string ToString() => Texto;
        }

        private void FrmActualizarEntrenador_Load(object sender, EventArgs e)
        {
            // La fecha de nacimiento debe ser anterior a hoy.
            dtpFechaNacimiento.MaxDate = DateTime.Today.AddDays(-1);

            TextosEntrenador.LlenarTipos(cmbTipo);
            TextosEntrenador.LlenarEspecialidades(cmbEspecialidad);

            CargarListaEntrenadores();
        }

        private void CargarListaEntrenadores()
        {
            cmbEntrenadores.Items.Clear();

            foreach (Entrenador entrenador in entrenadorController
                .ObtenerEntrenadores()
                .OrderBy(e => e.NombreCompleto, StringComparer.CurrentCultureIgnoreCase))
            {
                cmbEntrenadores.Items.Add(new OpcionEntrenador(entrenador));
            }

            if (cmbEntrenadores.Items.Count == 0)
            {
                HabilitarEdicion(false);

                MessageBox.Show(
                    "No hay entrenadores registrados para actualizar.",
                    "Buddy - Actualizar entrenador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Seleccionar el entrenador indicado o, si no existe, el primero.
            int indice = 0;

            if (idEntrenadorInicial.HasValue)
            {
                for (int i = 0; i < cmbEntrenadores.Items.Count; i++)
                {
                    if (cmbEntrenadores.Items[i] is OpcionEntrenador opcion &&
                        opcion.Id == idEntrenadorInicial.Value)
                    {
                        indice = i;
                        break;
                    }
                }
            }

            cmbEntrenadores.SelectedIndex = indice;
        }

        private void cmbEntrenadores_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Entrenador? entrenador = ObtenerEntrenadorSeleccionado();

            if (entrenador == null)
            {
                HabilitarEdicion(false);
                return;
            }

            MostrarDatosEntrenador(entrenador);
            HabilitarEdicion(true);
        }

        private Entrenador? ObtenerEntrenadorSeleccionado()
        {
            if (cmbEntrenadores.SelectedItem is not OpcionEntrenador opcion)
                return null;

            // Consultar siempre los datos actuales del controlador.
            return entrenadorController.ObtenerEntrenadorPorId(opcion.Id);
        }

        private void MostrarDatosEntrenador(Entrenador entrenador)
        {
            txtIdentificacion.Text = entrenador.Identificacion;
            txtNombre.Text = entrenador.Nombre;
            txtPrimerApellido.Text = entrenador.PrimerApellido;
            txtSegundoApellido.Text = entrenador.SegundoApellido ?? string.Empty;
            txtTelefono.Text = TextosEntrenador.FormatearTelefono(entrenador.Telefono);
            txtCorreo.Text = entrenador.CorreoElectronico;
            txtNombreUsuario.Text = entrenador.NombreUsuario;
            txtCertificaciones.Text = entrenador.Certificaciones ?? string.Empty;

            DateTime fecha = entrenador.FechaNacimiento.Date;
            if (fecha < dtpFechaNacimiento.MinDate) fecha = dtpFechaNacimiento.MinDate;
            if (fecha > dtpFechaNacimiento.MaxDate) fecha = dtpFechaNacimiento.MaxDate;
            dtpFechaNacimiento.Value = fecha;
            ActualizarEdad();

            TextosEntrenador.SeleccionarValor(cmbTipo, entrenador.Tipo);
            TextosEntrenador.SeleccionarValor(cmbEspecialidad, entrenador.Especialidad);

            nudAniosExperiencia.Value = Math.Clamp(
                entrenador.AniosExperiencia,
                (int)nudAniosExperiencia.Minimum,
                (int)nudAniosExperiencia.Maximum);

            // Datos que no se pueden modificar desde este formulario.
            lblRol.Text = $"Rol: {entrenador.Rol}";
            lblEstado.Text = $"Estado: {TextosEntrenador.Texto(entrenador.Estado)}";
            lblFechaRegistro.Text = $"Registrado: {entrenador.FechaRegistro:g}";
        }

        private void HabilitarEdicion(bool habilitar)
        {
            foreach (Control control in new Control[]
            {
                txtNombre, txtPrimerApellido, txtSegundoApellido, dtpFechaNacimiento,
                txtTelefono, txtCorreo, txtNombreUsuario, cmbTipo, cmbEspecialidad,
                nudAniosExperiencia, txtCertificaciones, btnGuardar
            })
            {
                control.Enabled = habilitar;
            }
        }

        private void dtpFechaNacimiento_ValueChanged(object? sender, EventArgs e)
        {
            ActualizarEdad();
        }

        // Recalcula la edad con la fecha de nacimiento editada.
        private void ActualizarEdad()
        {
            DateTime fecha = dtpFechaNacimiento.Value.Date;
            int edad = DateTime.Today.Year - fecha.Year;

            if (fecha > DateTime.Today.AddYears(-edad))
                edad--;

            lblEdad.Text = $"Edad: {edad} años";
        }

        private bool ValidarCampos()
        {
            if (cmbEntrenadores.SelectedItem is not OpcionEntrenador)
                return Advertir("Debe seleccionar un entrenador.", cmbEntrenadores);

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                return Advertir("Debe ingresar el nombre.", txtNombre);

            if (string.IsNullOrWhiteSpace(txtPrimerApellido.Text))
                return Advertir("Debe ingresar el primer apellido.", txtPrimerApellido);

            if (dtpFechaNacimiento.Value.Date >= DateTime.Today)
                return Advertir(
                    "La fecha de nacimiento debe ser anterior a hoy.", dtpFechaNacimiento);

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                return Advertir("Debe ingresar el número de teléfono.", txtTelefono);

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                return Advertir("Debe ingresar un correo electrónico.", txtCorreo);

            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
                return Advertir("Debe ingresar un nombre de usuario.", txtNombreUsuario);

            if (TextosEntrenador.ValorSeleccionado<TipoEntrenador>(cmbTipo) == null)
                return Advertir("Debe seleccionar el tipo de entrenador.", cmbTipo);

            if (TextosEntrenador.ValorSeleccionado<EspecialidadEntrenador>(cmbEspecialidad) == null)
                return Advertir("Debe seleccionar una especialidad.", cmbEspecialidad);

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            int id = ((OpcionEntrenador)cmbEntrenadores.SelectedItem!).Id;

            try
            {
                // El controlador valida formatos y duplicados (entre entrenadores
                // y usuarios) y guarda los cambios en el archivo JSON.
                Entrenador actualizado = entrenadorController.ActualizarEntrenador(
                    id: id,
                    nombre: txtNombre.Text,
                    primerApellido: txtPrimerApellido.Text,
                    segundoApellido: txtSegundoApellido.Text,
                    fechaNacimiento: dtpFechaNacimiento.Value.Date,
                    correoElectronico: txtCorreo.Text,
                    nombreUsuario: txtNombreUsuario.Text,
                    telefono: txtTelefono.Text,
                    tipo: TextosEntrenador.ValorSeleccionado<TipoEntrenador>(cmbTipo),
                    especialidad: TextosEntrenador.ValorSeleccionado<EspecialidadEntrenador>(cmbEspecialidad),
                    certificaciones: txtCertificaciones.Text,
                    aniosExperiencia: (int)nudAniosExperiencia.Value);

                IdEntrenadorActualizado = id;

                MessageBox.Show(
                    "Los datos del entrenador se actualizaron correctamente.\n\n" +
                    $"Nombre: {actualizado.NombreCompleto}\n" +
                    $"Usuario: {actualizado.NombreUsuario}\n" +
                    $"Correo: {actualizado.CorreoElectronico}\n" +
                    $"Teléfono: {TextosEntrenador.FormatearTelefono(actualizado.Telefono)}\n" +
                    $"Edad: {actualizado.Edad} años\n" +
                    $"Tipo: {TextosEntrenador.Texto(actualizado.Tipo)}\n" +
                    $"Especialidad: {TextosEntrenador.Texto(actualizado.Especialidad)}\n" +
                    $"Experiencia: {actualizado.AniosExperiencia} años",
                    "Buddy - Actualización exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
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
            bool Contiene(string texto) =>
                mensaje.Contains(texto, StringComparison.OrdinalIgnoreCase);

            if (Contiene("correo")) return txtCorreo;
            if (Contiene("nombre de usuario")) return txtNombreUsuario;
            if (Contiene("teléfono")) return txtTelefono;
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
                "Error de actualización",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control?.Focus();
            return false;
        }
    }
}
