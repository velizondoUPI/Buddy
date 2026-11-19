using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buddy.Controllers;
using Buddy.Models;

namespace Buddy.Views
{
    public partial class FrmConsultaEntrenadores : Form
    {
        // Controlador compartido con el resto de formularios.
        private readonly EntrenadorController entrenadorController;

        // Entrenadores mostrados, por ID. Solo se usan para filtrar y para el
        // detalle; la contraseña, el hash y la sal nunca se muestran.
        private readonly Dictionary<int, Entrenador> entrenadoresPorId = new();

        // Evita aplicar filtros mientras se inicializan los controles.
        private bool inicializado;

        public FrmConsultaEntrenadores(EntrenadorController entrenadorController)
        {
            InitializeComponent();

            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));
        }

        private void FrmConsultaEntrenadores_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();

            TextosEntrenador.LlenarTipos(cmbFiltroTipo, incluirTodos: true);
            TextosEntrenador.LlenarEspecialidades(cmbFiltroEspecialidad, incluirTodos: true);

            inicializado = true;

            CargarEntrenadores();
        }

        private void ConfigurarColumnas()
        {
            dgvEntrenadores.AutoGenerateColumns = false;
            dgvEntrenadores.Columns.Clear();

            dgvEntrenadores.Columns.Add("Id", "ID");
            dgvEntrenadores.Columns.Add("Identificacion", "Identificación");
            dgvEntrenadores.Columns.Add("NombreCompleto", "Nombre completo");
            dgvEntrenadores.Columns.Add("NombreUsuario", "Usuario");
            dgvEntrenadores.Columns.Add("CorreoElectronico", "Correo electrónico");
            dgvEntrenadores.Columns.Add("Telefono", "Teléfono");
            dgvEntrenadores.Columns.Add("Tipo", "Tipo");
            dgvEntrenadores.Columns.Add("Especialidad", "Especialidad");
            dgvEntrenadores.Columns.Add("AniosExperiencia", "Años exp.");
            dgvEntrenadores.Columns.Add("Estado", "Estado");

            // Distribuir el espacio según el contenido de cada columna.
            dgvEntrenadores.Columns["Id"]!.FillWeight = 35;
            dgvEntrenadores.Columns["Identificacion"]!.FillWeight = 95;
            dgvEntrenadores.Columns["NombreCompleto"]!.FillWeight = 160;
            dgvEntrenadores.Columns["NombreUsuario"]!.FillWeight = 95;
            dgvEntrenadores.Columns["CorreoElectronico"]!.FillWeight = 165;
            dgvEntrenadores.Columns["Telefono"]!.FillWeight = 75;
            dgvEntrenadores.Columns["Tipo"]!.FillWeight = 140;
            dgvEntrenadores.Columns["Especialidad"]!.FillWeight = 130;
            dgvEntrenadores.Columns["AniosExperiencia"]!.FillWeight = 60;
            dgvEntrenadores.Columns["Estado"]!.FillWeight = 55;
        }

        private void CargarEntrenadores(int? idSeleccionar = null)
        {
            entrenadoresPorId.Clear();
            dgvEntrenadores.Rows.Clear();

            foreach (Entrenador entrenador in entrenadorController
                .ObtenerEntrenadores()
                .OrderBy(e => e.Id))
            {
                entrenadoresPorId[entrenador.Id] = entrenador;

                dgvEntrenadores.Rows.Add(
                    entrenador.Id,
                    entrenador.Identificacion,
                    entrenador.NombreCompleto,
                    entrenador.NombreUsuario,
                    entrenador.CorreoElectronico,
                    TextosEntrenador.FormatearTelefono(entrenador.Telefono),
                    TextosEntrenador.Texto(entrenador.Tipo),
                    TextosEntrenador.Texto(entrenador.Especialidad),
                    entrenador.AniosExperiencia,
                    TextosEntrenador.Texto(entrenador.Estado));
            }

            AplicarFiltros(idSeleccionar);
        }

        private void Filtros_Changed(object? sender, EventArgs e)
        {
            if (inicializado)
                AplicarFiltros(ObtenerIdSeleccionado());
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            inicializado = false;

            txtBuscar.Clear();
            cmbFiltroTipo.SelectedIndex = 0;
            cmbFiltroEspecialidad.SelectedIndex = 0;

            inicializado = true;

            AplicarFiltros(ObtenerIdSeleccionado());
            txtBuscar.Focus();
        }

        // Muestra solo las filas que cumplen todos los filtros.
        private void AplicarFiltros(int? idSeleccionar)
        {
            string busqueda = txtBuscar.Text.Trim();
            string busquedaIdentificacion = EntrenadorController.NormalizarIdentificacion(busqueda);
            TipoEntrenador? tipo = TextosEntrenador.ValorSeleccionado<TipoEntrenador>(cmbFiltroTipo);
            EspecialidadEntrenador? especialidad =
                TextosEntrenador.ValorSeleccionado<EspecialidadEntrenador>(cmbFiltroEspecialidad);

            // Quitar la celda actual para poder ocultar cualquier fila.
            dgvEntrenadores.CurrentCell = null;

            int visibles = 0;

            foreach (DataGridViewRow fila in dgvEntrenadores.Rows)
            {
                if (fila.Cells["Id"].Value is not int id ||
                    !entrenadoresPorId.TryGetValue(id, out Entrenador? entrenador))
                {
                    fila.Visible = false;
                    continue;
                }

                bool coincideTexto =
                    busqueda.Length == 0 ||
                    entrenador.NombreCompleto.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                    entrenador.NombreUsuario.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                    entrenador.Identificacion.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                    (busquedaIdentificacion.Length > 0 &&
                     EntrenadorController.NormalizarIdentificacion(entrenador.Identificacion)
                        .Contains(busquedaIdentificacion, StringComparison.Ordinal));

                bool visible =
                    coincideTexto &&
                    (tipo == null || entrenador.Tipo == tipo) &&
                    (especialidad == null || entrenador.Especialidad == especialidad);

                fila.Visible = visible;

                if (visible)
                    visibles++;
            }

            if (entrenadoresPorId.Count == 0)
                lblResultados.Text = "No hay entrenadores registrados.";
            else if (visibles == 0)
                lblResultados.Text = "No se encontraron entrenadores con los criterios indicados.";
            else
                lblResultados.Text = visibles == 1
                    ? "1 entrenador encontrado."
                    : $"{visibles} entrenadores encontrados.";

            SeleccionarEntrenador(idSeleccionar);
        }

        private void SeleccionarEntrenador(int? id)
        {
            dgvEntrenadores.ClearSelection();

            DataGridViewRow? filaElegida = null;
            DataGridViewRow? primeraVisible = null;

            foreach (DataGridViewRow fila in dgvEntrenadores.Rows)
            {
                if (!fila.Visible)
                    continue;

                primeraVisible ??= fila;

                if (id != null && fila.Cells["Id"].Value is int idFila && idFila == id)
                {
                    filaElegida = fila;
                    break;
                }
            }

            // Si el entrenador indicado no está visible, usar la primera fila visible.
            filaElegida ??= primeraVisible;

            if (filaElegida != null)
            {
                dgvEntrenadores.CurrentCell = filaElegida.Cells["NombreCompleto"];
                filaElegida.Selected = true;
            }

            MostrarDetalle();
        }

        private int? ObtenerIdSeleccionado()
        {
            if (dgvEntrenadores.SelectedRows.Count == 0)
                return null;

            return dgvEntrenadores.SelectedRows[0].Cells["Id"].Value as int?;
        }

        private void dgvEntrenadores_SelectionChanged(object? sender, EventArgs e)
        {
            MostrarDetalle();
        }

        private void MostrarDetalle()
        {
            int? id = ObtenerIdSeleccionado();
            Entrenador? entrenador = null;

            if (id.HasValue)
                entrenadoresPorId.TryGetValue(id.Value, out entrenador);

            btnCambiarContrasena.Enabled = entrenador != null;

            if (entrenador == null)
            {
                foreach (Label etiqueta in new[]
                {
                    lblDetalleNombre, lblDetalleIdentificacion, lblDetalleUsuario,
                    lblDetalleCorreo, lblDetalleTelefono, lblDetalleFechaNacimiento,
                    lblDetalleEdad, lblDetalleTipo, lblDetalleEspecialidad,
                    lblDetalleExperiencia, lblDetalleCertificaciones, lblDetalleRol,
                    lblDetalleEstado, lblDetalleFechaRegistro
                })
                {
                    etiqueta.Text = "—";
                }

                return;
            }

            lblDetalleNombre.Text = entrenador.NombreCompleto;
            lblDetalleIdentificacion.Text = entrenador.Identificacion;
            lblDetalleUsuario.Text = entrenador.NombreUsuario;
            lblDetalleCorreo.Text = entrenador.CorreoElectronico;
            lblDetalleTelefono.Text = TextosEntrenador.FormatearTelefono(entrenador.Telefono);
            lblDetalleFechaNacimiento.Text = entrenador.FechaNacimiento.ToShortDateString();
            lblDetalleEdad.Text = $"{entrenador.Edad} años";
            lblDetalleTipo.Text = TextosEntrenador.Texto(entrenador.Tipo);
            lblDetalleEspecialidad.Text = TextosEntrenador.Texto(entrenador.Especialidad);
            lblDetalleExperiencia.Text = $"{entrenador.AniosExperiencia} años";
            lblDetalleCertificaciones.Text = entrenador.Certificaciones ?? "No registradas";
            lblDetalleRol.Text = entrenador.Rol;
            lblDetalleEstado.Text = TextosEntrenador.Texto(entrenador.Estado);
            lblDetalleFechaRegistro.Text = entrenador.FechaRegistro.ToString("g");
        }

        private void btnActualizarEntrenador_Click(object sender, EventArgs e)
        {
            int? idSeleccionado = ObtenerIdSeleccionado();

            using var frmActualizar = new FrmActualizarEntrenador(
                entrenadorController,
                idSeleccionado);

            if (frmActualizar.ShowDialog(this) == DialogResult.OK)
            {
                // Mostrar los datos actualizados desde el controlador compartido.
                CargarEntrenadores(frmActualizar.IdEntrenadorActualizado ?? idSeleccionado);
            }
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            int? idSeleccionado = ObtenerIdSeleccionado();

            if (idSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccione un entrenador en la tabla.",
                    "Buddy - Cambiar contraseña",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using var frmContrasena = new FrmCambiarContrasenaEntrenador(
                entrenadorController,
                idSeleccionado.Value);

            frmContrasena.ShowDialog(this);
        }
    }
}
