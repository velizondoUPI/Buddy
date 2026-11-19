using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buddy.Controllers;
using Buddy.Models;

namespace Buddy.Views
{
    // Consulta de solo lectura de las rutinas asignadas por usuario o por entrenador.
    public partial class FrmConsultaAsignaciones : Form
    {
        private const int VerPorUsuario = 0;
        private const int VerPorEntrenador = 1;

        // Controladores compartidos con el resto de formularios.
        private readonly AsignacionRutinaController asignacionController;
        private readonly UsuarioController usuarioController;
        private readonly EntrenadorController entrenadorController;
        private readonly RutinaController rutinaController;

        // Asignaciones mostradas en la tabla, por ID.
        private readonly Dictionary<int, AsignacionRutina> asignacionesPorId = new();

        // Evita consultar mientras se llenan las listas.
        private bool inicializado;

        public FrmConsultaAsignaciones(
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

        // Usuario o entrenador que se muestra en la lista de personas.
        private sealed class OpcionPersona
        {
            public int Id { get; }
            public string Texto { get; }

            public OpcionPersona(int id, string texto)
            {
                Id = id;
                Texto = texto;
            }

            public override string ToString() => Texto;
        }

        private void FrmConsultaAsignaciones_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Todas");
            foreach (EstadoAsignacion estado in Enum.GetValues<EstadoAsignacion>())
                cmbEstado.Items.Add(new OpcionLista<EstadoAsignacion>(estado, TextosAsignacion.Texto(estado)));
            cmbEstado.SelectedIndex = 0;

            cmbVerPor.Items.Clear();
            cmbVerPor.Items.Add("Usuario");
            cmbVerPor.Items.Add("Entrenador");

            inicializado = true;

            // Llena la lista de personas y consulta las asignaciones.
            cmbVerPor.SelectedIndex = VerPorUsuario;
        }

        private void ConfigurarColumnas()
        {
            dgvAsignaciones.AutoGenerateColumns = false;
            dgvAsignaciones.Columns.Clear();

            dgvAsignaciones.Columns.Add("Id", "ID");
            dgvAsignaciones.Columns.Add("Rutina", "Rutina");
            dgvAsignaciones.Columns.Add("Persona", "Entrenador");
            dgvAsignaciones.Columns.Add("Inicio", "Inicio");
            dgvAsignaciones.Columns.Add("Fin", "Fin");
            dgvAsignaciones.Columns.Add("Frecuencia", "Días/semana");
            dgvAsignaciones.Columns.Add("Estado", "Estado");
            dgvAsignaciones.Columns.Add("FechaCreacion", "Asignada el");

            dgvAsignaciones.Columns["Id"]!.FillWeight = 35;
            dgvAsignaciones.Columns["Rutina"]!.FillWeight = 170;
            dgvAsignaciones.Columns["Persona"]!.FillWeight = 160;
            dgvAsignaciones.Columns["Inicio"]!.FillWeight = 70;
            dgvAsignaciones.Columns["Fin"]!.FillWeight = 70;
            dgvAsignaciones.Columns["Frecuencia"]!.FillWeight = 70;
            dgvAsignaciones.Columns["Estado"]!.FillWeight = 70;
            dgvAsignaciones.Columns["FechaCreacion"]!.FillWeight = 95;
        }

        private void cmbVerPor_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!inicializado)
                return;

            inicializado = false;
            cmbPersona.Items.Clear();

            if (cmbVerPor.SelectedIndex == VerPorEntrenador)
            {
                lblPersona.Text = "Entrenador:";
                dgvAsignaciones.Columns["Persona"]!.HeaderText = "Usuario";

                foreach (Entrenador entrenador in entrenadorController
                    .ObtenerEntrenadores()
                    .OrderBy(x => x.NombreCompleto, StringComparer.CurrentCultureIgnoreCase))
                {
                    cmbPersona.Items.Add(new OpcionPersona(
                        entrenador.Id, TextosAsignacion.Describir(entrenador)));
                }
            }
            else
            {
                lblPersona.Text = "Usuario:";
                dgvAsignaciones.Columns["Persona"]!.HeaderText = "Entrenador";

                foreach (Usuario usuario in usuarioController
                    .ObtenerUsuarios()
                    .OrderBy(x => x.Nombre, StringComparer.CurrentCultureIgnoreCase))
                {
                    cmbPersona.Items.Add(new OpcionPersona(
                        usuario.Id, TextosAsignacion.Describir(usuario)));
                }
            }

            if (cmbPersona.Items.Count > 0)
                cmbPersona.SelectedIndex = 0;

            inicializado = true;
            CargarAsignaciones();
        }

        private void Filtros_Changed(object? sender, EventArgs e)
        {
            if (inicializado)
                CargarAsignaciones();
        }

        private void CargarAsignaciones()
        {
            asignacionesPorId.Clear();
            dgvAsignaciones.Rows.Clear();

            bool porEntrenador = cmbVerPor.SelectedIndex == VerPorEntrenador;

            if (cmbPersona.SelectedItem is not OpcionPersona persona)
            {
                lblResultados.Text = porEntrenador
                    ? "No hay entrenadores registrados."
                    : "No hay usuarios registrados.";
                MostrarDetalle();
                return;
            }

            EstadoAsignacion? estado = TextosEntrenador.ValorSeleccionado<EstadoAsignacion>(cmbEstado);

            List<AsignacionRutina> todas = porEntrenador
                ? asignacionController.ObtenerAsignacionesPorEntrenador(persona.Id)
                : asignacionController.ObtenerAsignacionesPorUsuario(persona.Id);

            List<AsignacionRutina> filtradas = todas
                .Where(a => estado == null || a.Estado == estado)
                .ToList();

            foreach (AsignacionRutina asignacion in filtradas)
            {
                asignacionesPorId[asignacion.Id] = asignacion;

                string otraPersona = porEntrenador
                    ? TextosAsignacion.Describir(
                        usuarioController.ObtenerUsuarios().FirstOrDefault(u => u.Id == asignacion.IdUsuario))
                    : TextosAsignacion.Describir(
                        entrenadorController.ObtenerEntrenadorPorId(asignacion.IdEntrenador));

                dgvAsignaciones.Rows.Add(
                    asignacion.Id,
                    TextosAsignacion.Describir(rutinaController.ObtenerRutinaPorId(asignacion.IdRutina)),
                    otraPersona,
                    asignacion.FechaInicio.ToShortDateString(),
                    asignacion.FechaFin.ToShortDateString(),
                    asignacion.FrecuenciaSemanal,
                    TextosAsignacion.Texto(asignacion.Estado),
                    asignacion.FechaCreacion.ToString("g"));
            }

            if (todas.Count == 0)
                lblResultados.Text = porEntrenador
                    ? "Este entrenador todavía no ha asignado rutinas."
                    : "Este usuario todavía no tiene rutinas asignadas.";
            else if (filtradas.Count == 0)
                lblResultados.Text = "No hay asignaciones con el estado seleccionado.";
            else
                lblResultados.Text = filtradas.Count == 1
                    ? "1 asignación encontrada."
                    : $"{filtradas.Count} asignaciones encontradas.";

            MostrarDetalle();
        }

        private void dgvAsignaciones_SelectionChanged(object? sender, EventArgs e)
        {
            MostrarDetalle();
        }

        private void MostrarDetalle()
        {
            if (dgvAsignaciones.SelectedRows.Count == 0 ||
                dgvAsignaciones.SelectedRows[0].Cells["Id"].Value is not int id ||
                !asignacionesPorId.TryGetValue(id, out AsignacionRutina? asignacion))
            {
                lblDetalle.Text = "Seleccione una asignación para ver su detalle.";
                return;
            }

            Usuario? usuario = usuarioController.ObtenerUsuarios()
                .FirstOrDefault(u => u.Id == asignacion.IdUsuario);
            Entrenador? entrenador = entrenadorController.ObtenerEntrenadorPorId(asignacion.IdEntrenador);
            Rutina? rutina = rutinaController.ObtenerRutinaPorId(asignacion.IdRutina);

            string datosRutina = rutina == null
                ? "(rutina no disponible)"
                : $"{rutina.Nombre} — {TextosRutina.Texto(rutina.Objetivo)}, " +
                  $"{TextosRutina.Texto(rutina.Dificultad)}, {rutina.DuracionMinutos} min, " +
                  $"días: {TextosAsignacion.DiasRutina(rutina)}";

            lblDetalle.Text =
                $"Rutina: {datosRutina}\n" +
                $"Usuario: {TextosAsignacion.Describir(usuario)}\n" +
                $"Entrenador: {TextosAsignacion.Describir(entrenador)}\n" +
                $"Período: del {asignacion.FechaInicio:dd/MM/yyyy} al {asignacion.FechaFin:dd/MM/yyyy} " +
                $"• Frecuencia: {asignacion.FrecuenciaSemanal} días/semana " +
                $"• Estado: {TextosAsignacion.Texto(asignacion.Estado)}\n" +
                $"Indicaciones: {asignacion.Indicaciones ?? "ninguna"}";
        }
    }
}
