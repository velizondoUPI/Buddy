using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buddy.Controllers;
using Buddy.Models;

namespace Buddy.Views
{
    public partial class FrmAsignarRutina : Form
    {
        // Controladores compartidos con el resto de formularios.
        private readonly AsignacionRutinaController asignacionController;
        private readonly UsuarioController usuarioController;
        private readonly EntrenadorController entrenadorController;
        private readonly RutinaController rutinaController;

        // Usuarios y rutinas mostrados, por ID.
        private readonly Dictionary<int, Usuario> usuariosPorId = new();
        private readonly Dictionary<int, Rutina> rutinasPorId = new();

        public FrmAsignarRutina(
            AsignacionRutinaController asignacionController,
            UsuarioController usuarioController,
            EntrenadorController entrenadorController,
            RutinaController rutinaController)
        {
            InitializeComponent();

            this.asignacionController = asignacionController
                ?? throw new ArgumentNullException(nameof(asignacionController));
            this.usuarioController = usuarioController
                ?? throw new ArgumentNullException(nameof(usuarioController));
            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));
            this.rutinaController = rutinaController
                ?? throw new ArgumentNullException(nameof(rutinaController));
        }

        // Entrenador que se muestra en la lista desplegable.
        private sealed class OpcionEntrenador
        {
            public int Id { get; }
            public string Texto { get; }

            public OpcionEntrenador(Entrenador entrenador)
            {
                Id = entrenador.Id;
                Texto = TextosAsignacion.Describir(entrenador);
            }

            public override string ToString() => Texto;
        }

        private void FrmAsignarRutina_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();
            ReiniciarDatosAsignacion();

            CargarUsuarios();
            CargarEntrenadores();
            CargarRutinas();

            List<string> faltantes = new();

            if (usuariosPorId.Count == 0)
                faltantes.Add("• No hay usuarios registrados.");

            if (cmbEntrenador.Items.Count == 0)
                faltantes.Add("• No hay entrenadores personales activos.");

            if (rutinasPorId.Count == 0)
                faltantes.Add("• No hay rutinas disponibles para asignación.");

            btnAsignar.Enabled = faltantes.Count == 0;

            if (faltantes.Count > 0)
            {
                MessageBox.Show(
                    "No es posible asignar rutinas todavía:\n\n" + string.Join("\n", faltantes),
                    "Buddy - Asignar rutina",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ConfigurarColumnas()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.Columns.Add("Id", "ID");
            dgvUsuarios.Columns.Add("Nombre", "Nombre");
            dgvUsuarios.Columns.Add("NombreUsuario", "Usuario");
            dgvUsuarios.Columns["Id"]!.FillWeight = 30;
            dgvUsuarios.Columns["Nombre"]!.FillWeight = 160;
            dgvUsuarios.Columns["NombreUsuario"]!.FillWeight = 110;

            dgvAsignacionesUsuario.AutoGenerateColumns = false;
            dgvAsignacionesUsuario.Columns.Clear();
            dgvAsignacionesUsuario.Columns.Add("Rutina", "Rutina");
            dgvAsignacionesUsuario.Columns.Add("Entrenador", "Entrenador");
            dgvAsignacionesUsuario.Columns.Add("Inicio", "Inicio");
            dgvAsignacionesUsuario.Columns.Add("Fin", "Fin");
            dgvAsignacionesUsuario.Columns.Add("Frecuencia", "Días/sem.");
            dgvAsignacionesUsuario.Columns.Add("Estado", "Estado");
            dgvAsignacionesUsuario.Columns["Rutina"]!.FillWeight = 150;
            dgvAsignacionesUsuario.Columns["Entrenador"]!.FillWeight = 130;
            dgvAsignacionesUsuario.Columns["Inicio"]!.FillWeight = 75;
            dgvAsignacionesUsuario.Columns["Fin"]!.FillWeight = 75;
            dgvAsignacionesUsuario.Columns["Frecuencia"]!.FillWeight = 60;
            dgvAsignacionesUsuario.Columns["Estado"]!.FillWeight = 75;

            dgvRutinas.AutoGenerateColumns = false;
            dgvRutinas.Columns.Clear();
            dgvRutinas.Columns.Add("Id", "ID");
            dgvRutinas.Columns.Add("Nombre", "Rutina");
            dgvRutinas.Columns.Add("Objetivo", "Objetivo");
            dgvRutinas.Columns.Add("Dificultad", "Dificultad");
            dgvRutinas.Columns.Add("Duracion", "Duración");
            dgvRutinas.Columns.Add("Dias", "Días");
            dgvRutinas.Columns["Id"]!.FillWeight = 30;
            dgvRutinas.Columns["Nombre"]!.FillWeight = 150;
            dgvRutinas.Columns["Objetivo"]!.FillWeight = 120;
            dgvRutinas.Columns["Dificultad"]!.FillWeight = 80;
            dgvRutinas.Columns["Duracion"]!.FillWeight = 60;
            dgvRutinas.Columns["Dias"]!.FillWeight = 120;
        }

        // ---------------- Usuario ----------------

        private void CargarUsuarios()
        {
            usuariosPorId.Clear();
            dgvUsuarios.Rows.Clear();

            foreach (Usuario usuario in usuarioController
                .ObtenerUsuarios()
                .OrderBy(u => u.Nombre, StringComparer.CurrentCultureIgnoreCase))
            {
                usuariosPorId[usuario.Id] = usuario;
                dgvUsuarios.Rows.Add(usuario.Id, usuario.Nombre, usuario.NombreUsuario);
            }

            dgvUsuarios.ClearSelection();
            MostrarUsuario();
        }

        private void txtBuscarUsuario_TextChanged(object? sender, EventArgs e)
        {
            string busqueda = txtBuscarUsuario.Text.Trim();
            int? seleccionado = ObtenerIdUsuarioSeleccionado();

            // Quitar la celda actual para poder ocultar cualquier fila.
            dgvUsuarios.CurrentCell = null;

            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                string nombre = fila.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                string nombreUsuario = fila.Cells["NombreUsuario"].Value?.ToString() ?? string.Empty;

                fila.Visible =
                    busqueda.Length == 0 ||
                    nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                    nombreUsuario.Contains(busqueda, StringComparison.OrdinalIgnoreCase);
            }

            // Conservar la selección si el usuario sigue visible.
            dgvUsuarios.ClearSelection();

            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                if (fila.Visible && fila.Cells["Id"].Value is int id && id == seleccionado)
                {
                    dgvUsuarios.CurrentCell = fila.Cells["Nombre"];
                    fila.Selected = true;
                    break;
                }
            }

            MostrarUsuario();
        }

        private int? ObtenerIdUsuarioSeleccionado()
        {
            return dgvUsuarios.SelectedRows.Count > 0
                ? dgvUsuarios.SelectedRows[0].Cells["Id"].Value as int?
                : null;
        }

        private void dgvUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            MostrarUsuario();
        }

        private void MostrarUsuario()
        {
            int? id = ObtenerIdUsuarioSeleccionado();
            dgvAsignacionesUsuario.Rows.Clear();

            if (id == null || !usuariosPorId.TryGetValue(id.Value, out Usuario? usuario))
            {
                lblInfoUsuario.Text = "Seleccione un usuario.";
                lblAsignacionesUsuario.Text = "Rutinas asignadas al usuario:";
                return;
            }

            // Información física actual del usuario.
            lblInfoUsuario.Text =
                $"{usuario.Nombre} ({usuario.NombreUsuario})   •   Edad: {usuario.Edad} años\n" +
                $"Peso: {usuario.PesoKg} kg   •   Altura: {usuario.AlturaMetros} m   •   IMC: {usuario.IMC:F2}";

            // Rutinas que el usuario ya tiene asignadas.
            List<AsignacionRutina> asignaciones =
                asignacionController.ObtenerAsignacionesPorUsuario(usuario.Id);

            foreach (AsignacionRutina asignacion in asignaciones)
            {
                dgvAsignacionesUsuario.Rows.Add(
                    TextosAsignacion.Describir(rutinaController.ObtenerRutinaPorId(asignacion.IdRutina)),
                    TextosAsignacion.Describir(entrenadorController.ObtenerEntrenadorPorId(asignacion.IdEntrenador)),
                    asignacion.FechaInicio.ToShortDateString(),
                    asignacion.FechaFin.ToShortDateString(),
                    asignacion.FrecuenciaSemanal,
                    TextosAsignacion.Texto(asignacion.Estado));
            }

            dgvAsignacionesUsuario.ClearSelection();

            lblAsignacionesUsuario.Text = asignaciones.Count == 0
                ? "Rutinas asignadas al usuario: ninguna."
                : $"Rutinas asignadas al usuario: {asignaciones.Count}.";
        }

        // ---------------- Entrenador y rutina ----------------

        private void CargarEntrenadores()
        {
            cmbEntrenador.Items.Clear();

            // Solo los entrenadores personales activos pueden asignar rutinas.
            foreach (Entrenador entrenador in entrenadorController
                .ObtenerEntrenadores()
                .Where(e => e.Tipo == TipoEntrenador.EntrenadorPersonal &&
                            e.Estado == EstadoCuenta.Activo)
                .OrderBy(e => e.NombreCompleto, StringComparer.CurrentCultureIgnoreCase))
            {
                cmbEntrenador.Items.Add(new OpcionEntrenador(entrenador));
            }

            if (cmbEntrenador.Items.Count == 1)
                cmbEntrenador.SelectedIndex = 0;
        }

        private void CargarRutinas()
        {
            rutinasPorId.Clear();
            dgvRutinas.Rows.Clear();

            // Solo las rutinas activas están disponibles para asignación.
            foreach (Rutina rutina in rutinaController
                .ObtenerRutinasDisponibles()
                .OrderBy(r => r.Nombre, StringComparer.CurrentCultureIgnoreCase))
            {
                rutinasPorId[rutina.Id] = rutina;

                dgvRutinas.Rows.Add(
                    rutina.Id,
                    rutina.Nombre,
                    TextosRutina.Texto(rutina.Objetivo),
                    TextosRutina.Texto(rutina.Dificultad),
                    $"{rutina.DuracionMinutos} min",
                    TextosAsignacion.DiasRutina(rutina));
            }

            dgvRutinas.ClearSelection();
            MostrarRutina();
        }

        private Rutina? ObtenerRutinaSeleccionada()
        {
            if (dgvRutinas.SelectedRows.Count == 0 ||
                dgvRutinas.SelectedRows[0].Cells["Id"].Value is not int id)
                return null;

            return rutinasPorId.TryGetValue(id, out Rutina? rutina) ? rutina : null;
        }

        private void dgvRutinas_SelectionChanged(object? sender, EventArgs e)
        {
            MostrarRutina();
        }

        private void MostrarRutina()
        {
            Rutina? rutina = ObtenerRutinaSeleccionada();

            if (rutina == null)
            {
                lblDescripcionRutina.Text = rutinasPorId.Count == 0
                    ? "No hay rutinas disponibles para asignación."
                    : "Seleccione una rutina para ver su descripción.";
                return;
            }

            int dias = rutina.DiasEntrenamiento.Count;

            lblDescripcionRutina.Text =
                $"{rutina.Descripcion}\n" +
                $"Días de entrenamiento: {TextosAsignacion.DiasRutina(rutina)} " +
                $"({dias} {(dias == 1 ? "día" : "días")} por semana) • Ejercicios: {rutina.Ejercicios.Count}";
        }

        // ---------------- Datos de la asignación ----------------

        private void ReiniciarDatosAsignacion()
        {
            // La fecha de inicio no puede ser anterior a hoy.
            dtpFechaInicio.MinDate = DateTime.Today;
            dtpFechaInicio.Value = DateTime.Today;

            dtpFechaFin.MinDate = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddDays(27);

            nudFrecuencia.Value = 3;
            txtIndicaciones.Clear();

            ActualizarEstadoInicial();
        }

        private void dtpFechaInicio_ValueChanged(object? sender, EventArgs e)
        {
            // La fecha de finalización no puede ser anterior al inicio.
            dtpFechaFin.MinDate = dtpFechaInicio.Value.Date;
            ActualizarEstadoInicial();
        }

        private void ActualizarEstadoInicial()
        {
            EstadoAsignacion estado = AsignacionRutina.CalcularEstado(
                dtpFechaInicio.Value.Date,
                dtpFechaFin.Value.Date,
                DateTime.Today);

            lblEstadoInicial.Text = $"Estado inicial: {TextosAsignacion.Texto(estado)}";
        }

        // ---------------- Asignar ----------------

        private bool ValidarCampos()
        {
            if (ObtenerIdUsuarioSeleccionado() == null)
                return Advertir("Debe seleccionar un usuario.", dgvUsuarios);

            if (cmbEntrenador.SelectedItem is not OpcionEntrenador)
                return Advertir("Debe seleccionar el entrenador.", cmbEntrenador);

            if (ObtenerRutinaSeleccionada() == null)
                return Advertir("Debe seleccionar una rutina.", dgvRutinas);

            if (dtpFechaInicio.Value.Date < DateTime.Today)
                return Advertir("La fecha de inicio no puede ser anterior a hoy.", dtpFechaInicio);

            if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
                return Advertir(
                    "La fecha de finalización no puede ser anterior a la fecha de inicio.",
                    dtpFechaFin);

            return true;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            int idUsuario = ObtenerIdUsuarioSeleccionado()!.Value;
            Usuario usuario = usuariosPorId[idUsuario];
            var entrenador = (OpcionEntrenador)cmbEntrenador.SelectedItem!;
            Rutina rutina = ObtenerRutinaSeleccionada()!;
            DateTime inicio = dtpFechaInicio.Value.Date;
            DateTime fin = dtpFechaFin.Value.Date;
            int frecuencia = (int)nudFrecuencia.Value;
            string indicaciones = txtIndicaciones.Text.Trim();

            // Advertencia informativa: se permite continuar si se confirma.
            string? advertencia = asignacionController.ObtenerAdvertenciaFrecuencia(rutina.Id, frecuencia);

            if (advertencia != null)
            {
                DialogResult continuar = MessageBox.Show(
                    advertencia + "\n\n¿Desea continuar con la asignación de todos modos?",
                    "Buddy - Frecuencia semanal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (continuar != DialogResult.Yes)
                {
                    nudFrecuencia.Focus();
                    return;
                }
            }

            // Resumen antes de confirmar.
            EstadoAsignacion estadoInicial = AsignacionRutina.CalcularEstado(inicio, fin, DateTime.Today);

            var resumen = new StringBuilder();
            resumen.AppendLine($"Usuario: {TextosAsignacion.Describir(usuario)}");
            resumen.AppendLine($"Entrenador: {entrenador.Texto}");
            resumen.AppendLine($"Rutina: {rutina.Nombre}");
            resumen.AppendLine($"Días de la rutina: {TextosAsignacion.DiasRutina(rutina)}");
            resumen.AppendLine($"Fechas: del {inicio:dd/MM/yyyy} al {fin:dd/MM/yyyy}");
            resumen.AppendLine($"Frecuencia semanal: {frecuencia} {(frecuencia == 1 ? "día" : "días")}");
            resumen.AppendLine($"Estado inicial: {TextosAsignacion.Texto(estadoInicial)}");
            resumen.AppendLine($"Indicaciones: {(indicaciones.Length == 0 ? "ninguna" : indicaciones)}");
            resumen.AppendLine();
            resumen.Append("¿Desea confirmar la asignación?");

            DialogResult confirmar = MessageBox.Show(
                resumen.ToString(),
                "Buddy - Confirmar asignación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                // El controlador valida cuentas, rutina, fechas, frecuencia
                // y duplicados, y guarda la asignación en JSON.
                AsignacionRutina asignacion = asignacionController.AsignarRutina(
                    idUsuario,
                    entrenador.Id,
                    rutina.Id,
                    inicio,
                    fin,
                    frecuencia,
                    indicaciones);

                MessageBox.Show(
                    "Rutina asignada correctamente.\n\n" +
                    $"ID de la asignación: {asignacion.Id}\n" +
                    $"Usuario: {TextosAsignacion.Describir(usuario)}\n" +
                    $"Rutina: {rutina.Nombre}\n" +
                    $"Del {asignacion.FechaInicio:dd/MM/yyyy} al {asignacion.FechaFin:dd/MM/yyyy}\n" +
                    $"Estado: {TextosAsignacion.Texto(asignacion.Estado)}",
                    "Buddy - Asignación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Mostrar la nueva asignación y preparar otra para el mismo usuario.
                MostrarUsuario();
                ReiniciarDatosAsignacion();
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
                    "No se pudo guardar la asignación. " +
                    "Los datos existentes se conservaron sin modificaciones.\n\n" +
                    ex.Message,
                    "Buddy - Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarUsuario.Clear();
            dgvUsuarios.ClearSelection();
            dgvRutinas.ClearSelection();

            if (cmbEntrenador.Items.Count != 1)
                cmbEntrenador.SelectedIndex = -1;

            ReiniciarDatosAsignacion();
            MostrarUsuario();
            MostrarRutina();
            txtBuscarUsuario.Focus();
        }

        // Indica qué campo corregir según el mensaje del controlador.
        private Control? ObtenerControlDelError(string mensaje)
        {
            bool Contiene(string texto) =>
                mensaje.Contains(texto, StringComparison.OrdinalIgnoreCase);

            if (Contiene("ya tiene asignada")) return dtpFechaInicio;
            if (Contiene("entrenador")) return cmbEntrenador;
            if (Contiene("rutina")) return dgvRutinas;
            if (Contiene("usuario")) return dgvUsuarios;
            if (Contiene("finalización")) return dtpFechaFin;
            if (Contiene("fecha de inicio")) return dtpFechaInicio;
            if (Contiene("frecuencia")) return nudFrecuencia;
            if (Contiene("indicaciones")) return txtIndicaciones;

            return null;
        }

        // Muestra el aviso, enfoca el campo y devuelve false.
        private bool Advertir(string mensaje, Control? control)
        {
            MessageBox.Show(
                mensaje,
                "Error de asignación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control?.Focus();
            return false;
        }
    }
}
