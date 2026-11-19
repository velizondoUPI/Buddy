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
    public partial class FrmCrearRutina : Form
    {
        // Controladores compartidos con el resto de formularios.
        private readonly RutinaController rutinaController;
        private readonly EntrenadorController entrenadorController;

        // Ejercicios agregados en el formulario y todavía no guardados.
        // El orden dentro de cada día es el orden en esta lista.
        private readonly List<EjercicioEnEdicion> ejercicios = new();

        // Evita cargar el editor mientras se reconstruye la tabla.
        private bool actualizandoTabla;

        public FrmCrearRutina(
            RutinaController rutinaController,
            EntrenadorController entrenadorController)
        {
            InitializeComponent();

            this.rutinaController = rutinaController
                ?? throw new ArgumentNullException(nameof(rutinaController));
            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));
        }

        private sealed class EjercicioEnEdicion
        {
            public DiaSemana Dia { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Descripcion { get; set; } = string.Empty;
            public int Series { get; set; }
            public int Repeticiones { get; set; }
            public int DescansoSegundos { get; set; }
            public decimal? PesoRecomendadoKg { get; set; }
            public string? Indicaciones { get; set; }
        }

        // Entrenador que se muestra en la lista de creadores.
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

        private void FrmCrearRutina_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();

            TextosRutina.LlenarObjetivos(cmbObjetivo);
            TextosRutina.LlenarDificultades(cmbDificultad);
            TextosRutina.LlenarDias(clbDias);

            CargarEntrenadores();
            ActualizarDiasEditor();
            ActualizarBotonesEjercicio();
        }

        private void CargarEntrenadores()
        {
            cmbEntrenador.Items.Clear();

            // Solo los entrenadores personales con cuenta activa pueden crear rutinas.
            foreach (Entrenador entrenador in entrenadorController
                .ObtenerEntrenadores()
                .Where(e => e.Tipo == TipoEntrenador.EntrenadorPersonal &&
                            e.Estado == EstadoCuenta.Activo)
                .OrderBy(e => e.NombreCompleto, StringComparer.CurrentCultureIgnoreCase))
            {
                cmbEntrenador.Items.Add(new OpcionEntrenador(entrenador));
            }

            bool hayEntrenadores = cmbEntrenador.Items.Count > 0;

            btnGuardar.Enabled = hayEntrenadores;

            if (!hayEntrenadores)
            {
                MessageBox.Show(
                    "No hay entrenadores personales activos registrados.\n\n" +
                    "Registre un entrenador de tipo \"Entrenador personal\" " +
                    "para poder crear rutinas.",
                    "Buddy - Crear rutina",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (cmbEntrenador.Items.Count == 1)
            {
                cmbEntrenador.SelectedIndex = 0;
            }
        }

        private void ConfigurarColumnas()
        {
            dgvEjercicios.AutoGenerateColumns = false;
            dgvEjercicios.Columns.Clear();

            dgvEjercicios.Columns.Add("Dia", "Día");
            dgvEjercicios.Columns.Add("Orden", "Orden");
            dgvEjercicios.Columns.Add("Nombre", "Ejercicio");
            dgvEjercicios.Columns.Add("Series", "Series");
            dgvEjercicios.Columns.Add("Repeticiones", "Reps.");
            dgvEjercicios.Columns.Add("Descanso", "Descanso");
            dgvEjercicios.Columns.Add("Peso", "Peso rec.");

            dgvEjercicios.Columns["Dia"]!.FillWeight = 75;
            dgvEjercicios.Columns["Orden"]!.FillWeight = 45;
            dgvEjercicios.Columns["Nombre"]!.FillWeight = 180;
            dgvEjercicios.Columns["Series"]!.FillWeight = 50;
            dgvEjercicios.Columns["Repeticiones"]!.FillWeight = 50;
            dgvEjercicios.Columns["Descanso"]!.FillWeight = 65;
            dgvEjercicios.Columns["Peso"]!.FillWeight = 65;

            foreach (DataGridViewColumn columna in dgvEjercicios.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        // ---------------- Días de entrenamiento ----------------

        private List<DiaSemana> ObtenerDiasSeleccionados()
        {
            return clbDias.CheckedItems
                .OfType<OpcionLista<DiaSemana>>()
                .Select(o => o.Valor)
                .OrderBy(d => d)
                .ToList();
        }

        private void clbDias_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked &&
                clbDias.Items[e.Index] is OpcionLista<DiaSemana> opcion)
            {
                int cantidad = ejercicios.Count(x => x.Dia == opcion.Valor);

                if (cantidad > 0)
                {
                    DialogResult respuesta = MessageBox.Show(
                        $"El {opcion.Texto.ToLower()} tiene {cantidad} ejercicio(s).\n\n" +
                        "¿Desea eliminar esos ejercicios y desmarcar el día?",
                        "Buddy - Quitar día de entrenamiento",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        ejercicios.RemoveAll(x => x.Dia == opcion.Valor);
                        RefrescarTabla(null);
                    }
                    else
                    {
                        e.NewValue = CheckState.Checked;
                    }
                }
            }

            // La lista marcada se actualiza después de este evento.
            BeginInvoke(new Action(ActualizarDiasEditor));
        }

        private void ActualizarDiasEditor()
        {
            DiaSemana? diaActual = TextosEntrenador.ValorSeleccionado<DiaSemana>(cmbDiaEjercicio);

            cmbDiaEjercicio.Items.Clear();

            foreach (DiaSemana dia in ObtenerDiasSeleccionados())
                cmbDiaEjercicio.Items.Add(new OpcionLista<DiaSemana>(dia, TextosRutina.Texto(dia)));

            if (diaActual.HasValue)
                TextosEntrenador.SeleccionarValor(cmbDiaEjercicio, diaActual.Value);

            if (cmbDiaEjercicio.SelectedIndex < 0 && cmbDiaEjercicio.Items.Count > 0)
                cmbDiaEjercicio.SelectedIndex = 0;
        }

        // ---------------- Editor de ejercicios ----------------

        private void chkPesoRecomendado_CheckedChanged(object? sender, EventArgs e)
        {
            nudPesoRecomendado.Enabled = chkPesoRecomendado.Checked;
        }

        private EjercicioEnEdicion? LeerEditor()
        {
            DiaSemana? dia = TextosEntrenador.ValorSeleccionado<DiaSemana>(cmbDiaEjercicio);

            if (dia == null)
            {
                Advertir(
                    cmbDiaEjercicio.Items.Count == 0
                        ? "Primero marque al menos un día de entrenamiento."
                        : "Seleccione el día del ejercicio.",
                    cmbDiaEjercicio.Items.Count == 0 ? clbDias : cmbDiaEjercicio);
                return null;
            }

            if (string.IsNullOrWhiteSpace(txtNombreEjercicio.Text))
            {
                Advertir("Debe ingresar el nombre del ejercicio.", txtNombreEjercicio);
                return null;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcionEjercicio.Text))
            {
                Advertir(
                    "Debe ingresar la descripción o indicación básica de ejecución del ejercicio.",
                    txtDescripcionEjercicio);
                return null;
            }

            return new EjercicioEnEdicion
            {
                Dia = dia.Value,
                Nombre = txtNombreEjercicio.Text.Trim(),
                Descripcion = txtDescripcionEjercicio.Text.Trim(),
                Series = (int)nudSeries.Value,
                Repeticiones = (int)nudRepeticiones.Value,
                DescansoSegundos = (int)nudDescanso.Value,
                PesoRecomendadoKg = chkPesoRecomendado.Checked ? nudPesoRecomendado.Value : null,
                Indicaciones = string.IsNullOrWhiteSpace(txtIndicaciones.Text)
                    ? null
                    : txtIndicaciones.Text.Trim()
            };
        }

        private void CargarEditor(EjercicioEnEdicion ejercicio)
        {
            TextosEntrenador.SeleccionarValor(cmbDiaEjercicio, ejercicio.Dia);
            txtNombreEjercicio.Text = ejercicio.Nombre;
            txtDescripcionEjercicio.Text = ejercicio.Descripcion;
            nudSeries.Value = Math.Clamp(ejercicio.Series, (int)nudSeries.Minimum, (int)nudSeries.Maximum);
            nudRepeticiones.Value = Math.Clamp(ejercicio.Repeticiones, (int)nudRepeticiones.Minimum, (int)nudRepeticiones.Maximum);
            nudDescanso.Value = Math.Clamp(ejercicio.DescansoSegundos, (int)nudDescanso.Minimum, (int)nudDescanso.Maximum);
            chkPesoRecomendado.Checked = ejercicio.PesoRecomendadoKg.HasValue;
            nudPesoRecomendado.Value = Math.Clamp(
                ejercicio.PesoRecomendadoKg ?? 0, nudPesoRecomendado.Minimum, nudPesoRecomendado.Maximum);
            txtIndicaciones.Text = ejercicio.Indicaciones ?? string.Empty;
        }

        private void LimpiarEditor()
        {
            // Se conserva el día elegido para agregar varios ejercicios seguidos.
            txtNombreEjercicio.Clear();
            txtDescripcionEjercicio.Clear();
            nudSeries.Value = 3;
            nudRepeticiones.Value = 10;
            nudDescanso.Value = 60;
            chkPesoRecomendado.Checked = false;
            nudPesoRecomendado.Value = 0;
            txtIndicaciones.Clear();
            txtNombreEjercicio.Focus();
        }

        private void btnAgregarEjercicio_Click(object sender, EventArgs e)
        {
            EjercicioEnEdicion? nuevo = LeerEditor();

            if (nuevo == null)
                return;

            ejercicios.Add(nuevo);
            RefrescarTabla(nuevo);
            LimpiarEditor();
        }

        private void btnModificarEjercicio_Click(object sender, EventArgs e)
        {
            EjercicioEnEdicion? seleccionado = ObtenerEjercicioSeleccionado();

            if (seleccionado == null)
            {
                Advertir("Seleccione en la tabla el ejercicio que desea modificar.", dgvEjercicios);
                return;
            }

            EjercicioEnEdicion? datos = LeerEditor();

            if (datos == null)
                return;

            int indice = ejercicios.IndexOf(seleccionado);

            if (datos.Dia == seleccionado.Dia)
            {
                // Mismo día: se conserva su posición.
                ejercicios[indice] = datos;
            }
            else
            {
                // Otro día: pasa al final de los ejercicios de ese día.
                ejercicios.RemoveAt(indice);
                ejercicios.Add(datos);
            }

            RefrescarTabla(datos);
        }

        private void btnEliminarEjercicio_Click(object sender, EventArgs e)
        {
            EjercicioEnEdicion? seleccionado = ObtenerEjercicioSeleccionado();

            if (seleccionado == null)
            {
                Advertir("Seleccione en la tabla el ejercicio que desea eliminar.", dgvEjercicios);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Desea quitar el ejercicio \"{seleccionado.Nombre}\" de la rutina?",
                "Buddy - Eliminar ejercicio",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            ejercicios.Remove(seleccionado);
            RefrescarTabla(null);
            LimpiarEditor();
        }

        private void btnSubirEjercicio_Click(object sender, EventArgs e)
        {
            MoverEjercicio(-1);
        }

        private void btnBajarEjercicio_Click(object sender, EventArgs e)
        {
            MoverEjercicio(+1);
        }

        // Intercambia el ejercicio con el anterior o el siguiente del mismo día.
        private void MoverEjercicio(int direccion)
        {
            EjercicioEnEdicion? seleccionado = ObtenerEjercicioSeleccionado();

            if (seleccionado == null)
            {
                Advertir("Seleccione en la tabla el ejercicio que desea mover.", dgvEjercicios);
                return;
            }

            int indice = ejercicios.IndexOf(seleccionado);
            int vecino = indice + direccion;

            while (vecino >= 0 && vecino < ejercicios.Count &&
                   ejercicios[vecino].Dia != seleccionado.Dia)
            {
                vecino += direccion;
            }

            if (vecino < 0 || vecino >= ejercicios.Count)
                return;

            (ejercicios[indice], ejercicios[vecino]) = (ejercicios[vecino], ejercicios[indice]);
            RefrescarTabla(seleccionado);
        }

        // ---------------- Tabla de ejercicios ----------------

        // Ejercicios agrupados por día con su orden de ejecución (1, 2, 3...).
        private List<(EjercicioEnEdicion Ejercicio, int Orden)> ObtenerEjerciciosOrdenados()
        {
            var resultado = new List<(EjercicioEnEdicion, int)>();

            foreach (var grupo in ejercicios.GroupBy(x => x.Dia).OrderBy(g => g.Key))
            {
                int orden = 1;
                foreach (EjercicioEnEdicion ejercicio in grupo)
                    resultado.Add((ejercicio, orden++));
            }

            return resultado;
        }

        private void RefrescarTabla(EjercicioEnEdicion? seleccionar)
        {
            actualizandoTabla = true;

            dgvEjercicios.Rows.Clear();

            foreach (var (ejercicio, orden) in ObtenerEjerciciosOrdenados())
            {
                int fila = dgvEjercicios.Rows.Add(
                    TextosRutina.Texto(ejercicio.Dia),
                    orden,
                    ejercicio.Nombre,
                    ejercicio.Series,
                    ejercicio.Repeticiones,
                    $"{ejercicio.DescansoSegundos} s",
                    TextosRutina.FormatearPeso(ejercicio.PesoRecomendadoKg));

                dgvEjercicios.Rows[fila].Tag = ejercicio;
            }

            dgvEjercicios.ClearSelection();

            foreach (DataGridViewRow fila in dgvEjercicios.Rows)
            {
                if (seleccionar != null && ReferenceEquals(fila.Tag, seleccionar))
                {
                    dgvEjercicios.CurrentCell = fila.Cells["Nombre"];
                    fila.Selected = true;
                    break;
                }
            }

            actualizandoTabla = false;

            ActualizarBotonesEjercicio();
        }

        private EjercicioEnEdicion? ObtenerEjercicioSeleccionado()
        {
            return dgvEjercicios.SelectedRows.Count > 0
                ? dgvEjercicios.SelectedRows[0].Tag as EjercicioEnEdicion
                : null;
        }

        private void dgvEjercicios_SelectionChanged(object? sender, EventArgs e)
        {
            if (actualizandoTabla)
                return;

            EjercicioEnEdicion? seleccionado = ObtenerEjercicioSeleccionado();

            if (seleccionado != null)
                CargarEditor(seleccionado);

            ActualizarBotonesEjercicio();
        }

        private void ActualizarBotonesEjercicio()
        {
            bool haySeleccion = ObtenerEjercicioSeleccionado() != null;

            btnModificarEjercicio.Enabled = haySeleccion;
            btnEliminarEjercicio.Enabled = haySeleccion;
            btnSubirEjercicio.Enabled = haySeleccion;
            btnBajarEjercicio.Enabled = haySeleccion;
        }

        // ---------------- Guardar ----------------

        private bool ValidarDatosGenerales()
        {
            if (cmbEntrenador.SelectedItem is not OpcionEntrenador)
                return Advertir("Debe seleccionar el entrenador creador.", cmbEntrenador);

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                return Advertir("Debe ingresar el nombre de la rutina.", txtNombre);

            if (TextosEntrenador.ValorSeleccionado<ObjetivoRutina>(cmbObjetivo) == null)
                return Advertir("Debe seleccionar el objetivo de la rutina.", cmbObjetivo);

            if (TextosEntrenador.ValorSeleccionado<NivelDificultad>(cmbDificultad) == null)
                return Advertir("Debe seleccionar el nivel de dificultad.", cmbDificultad);

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                return Advertir("Debe ingresar la descripción de la rutina.", txtDescripcion);

            if (ObtenerDiasSeleccionados().Count == 0)
                return Advertir("Debe seleccionar al menos un día de entrenamiento.", clbDias);

            if (ejercicios.Count == 0)
                return Advertir("La rutina debe contener al menos un ejercicio.", txtNombreEjercicio);

            return true;
        }

        private string ConstruirResumen(List<(EjercicioEnEdicion Ejercicio, int Orden)> ordenados)
        {
            var resumen = new StringBuilder();

            resumen.AppendLine($"Entrenador creador: {cmbEntrenador.SelectedItem}");
            resumen.AppendLine($"Rutina: {txtNombre.Text.Trim()}");
            resumen.AppendLine($"Objetivo: {cmbObjetivo.SelectedItem}");
            resumen.AppendLine($"Dificultad: {cmbDificultad.SelectedItem}");
            resumen.AppendLine($"Duración estimada: {nudDuracion.Value} minutos");
            resumen.AppendLine(
                "Días: " + string.Join(", ", ObtenerDiasSeleccionados().Select(TextosRutina.Texto)));
            resumen.AppendLine();

            foreach (var grupo in ordenados.GroupBy(x => x.Ejercicio.Dia))
            {
                resumen.AppendLine($"{TextosRutina.Texto(grupo.Key)}:");

                foreach (var (ejercicio, orden) in grupo)
                {
                    string peso = ejercicio.PesoRecomendadoKg.HasValue
                        ? $", {TextosRutina.FormatearPeso(ejercicio.PesoRecomendadoKg)}"
                        : string.Empty;

                    resumen.AppendLine(
                        $"   {orden}. {ejercicio.Nombre} — {ejercicio.Series} x {ejercicio.Repeticiones}, " +
                        $"descanso {ejercicio.DescansoSegundos} s{peso}");
                }
            }

            resumen.AppendLine();
            resumen.Append("¿Desea guardar la rutina?");

            return resumen.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosGenerales())
                return;

            List<(EjercicioEnEdicion Ejercicio, int Orden)> ordenados = ObtenerEjerciciosOrdenados();

            DialogResult confirmar = MessageBox.Show(
                ConstruirResumen(ordenados),
                "Buddy - Confirmar rutina",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            List<DatosEjercicio> datosEjercicios = ordenados
                .Select(x => new DatosEjercicio(
                    x.Ejercicio.Nombre,
                    x.Ejercicio.Descripcion,
                    x.Ejercicio.Dia,
                    x.Orden,
                    x.Ejercicio.Series,
                    x.Ejercicio.Repeticiones,
                    x.Ejercicio.DescansoSegundos,
                    x.Ejercicio.PesoRecomendadoKg,
                    x.Ejercicio.Indicaciones))
                .ToList();

            try
            {
                // El controlador valida todos los datos y guarda la rutina
                // junto con sus ejercicios en una sola operación.
                Rutina rutina = rutinaController.CrearRutina(
                    idEntrenadorCreador: ((OpcionEntrenador)cmbEntrenador.SelectedItem!).Id,
                    nombre: txtNombre.Text,
                    objetivo: TextosEntrenador.ValorSeleccionado<ObjetivoRutina>(cmbObjetivo),
                    dificultad: TextosEntrenador.ValorSeleccionado<NivelDificultad>(cmbDificultad),
                    descripcion: txtDescripcion.Text,
                    duracionMinutos: (int)nudDuracion.Value,
                    diasEntrenamiento: ObtenerDiasSeleccionados(),
                    ejercicios: datosEjercicios);

                MessageBox.Show(
                    "Rutina creada correctamente.\n\n" +
                    $"ID: {rutina.Id}\n" +
                    $"Nombre: {rutina.Nombre}\n" +
                    $"Días: {string.Join(", ", rutina.DiasEntrenamiento.Select(TextosRutina.Texto))}\n" +
                    $"Ejercicios: {rutina.Ejercicios.Count}\n" +
                    $"Fecha de creación: {rutina.FechaCreacion:g}",
                    "Buddy - Rutina creada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarTodo();
            }
            catch (ValidacionEjercicioException ex)
            {
                // Señalar el ejercicio con el error en la tabla.
                if (ex.IndiceEjercicio >= 0 && ex.IndiceEjercicio < ordenados.Count)
                    RefrescarTabla(ordenados[ex.IndiceEjercicio].Ejercicio);

                Advertir(ex.Message, dgvEjercicios);
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
                    "No se pudo guardar la rutina. " +
                    "Los datos existentes se conservaron sin modificaciones.\n\n" +
                    ex.Message,
                    "Buddy - Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            bool hayDatos =
                ejercicios.Count > 0 ||
                !string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtDescripcion.Text);

            if (hayDatos)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Se borrarán todos los datos y ejercicios ingresados. ¿Desea continuar?",
                    "Buddy - Limpiar formulario",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;
            }

            LimpiarTodo();
        }

        private void LimpiarTodo()
        {
            // El entrenador creador se conserva para crear varias rutinas seguidas.
            txtNombre.Clear();
            cmbObjetivo.SelectedIndex = -1;
            cmbDificultad.SelectedIndex = -1;
            nudDuracion.Value = 60;
            txtDescripcion.Clear();

            ejercicios.Clear();

            for (int i = 0; i < clbDias.Items.Count; i++)
                clbDias.SetItemChecked(i, false);

            RefrescarTabla(null);
            LimpiarEditor();
            ActualizarDiasEditor();

            txtNombre.Focus();
        }

        // Indica qué campo corregir según el mensaje del controlador.
        private Control? ObtenerControlDelError(string mensaje)
        {
            bool Contiene(string texto) =>
                mensaje.Contains(texto, StringComparison.OrdinalIgnoreCase);

            if (Contiene("entrenador")) return cmbEntrenador;
            if (Contiene("nombre de la rutina")) return txtNombre;
            if (Contiene("objetivo")) return cmbObjetivo;
            if (Contiene("dificultad")) return cmbDificultad;
            if (Contiene("descripción de la rutina")) return txtDescripcion;
            if (Contiene("duración")) return nudDuracion;
            if (Contiene("día")) return clbDias;
            if (Contiene("ejercicio")) return dgvEjercicios;

            return null;
        }

        // Muestra el aviso, enfoca el campo y devuelve false.
        private bool Advertir(string mensaje, Control? control)
        {
            MessageBox.Show(
                mensaje,
                "Error en la rutina",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control?.Focus();
            return false;
        }

        private void txtNombreEjercicio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
