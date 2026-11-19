using System;
using System.Collections.Generic;
using System.Linq;
using Buddy.Data;
using Buddy.Models;

namespace Buddy.Controllers
{
    public class AsignacionRutinaController
    {
        public const int FrecuenciaMinima = 1;
        public const int FrecuenciaMaxima = 7;
        public const int LongitudMaximaIndicaciones = 500;

        private readonly List<AsignacionRutina> asignaciones;
        private readonly AsignacionRutinaRepository repositorio;

        // Búsqueda de usuarios registrados por ID.
        private readonly Func<int, Usuario?> buscarUsuario;

        private readonly EntrenadorController entrenadorController;
        private readonly RutinaController rutinaController;

        private int siguienteId;

        public AsignacionRutinaController(
            UsuarioController usuarioController,
            EntrenadorController entrenadorController,
            RutinaController rutinaController)
            : this(
                new AsignacionRutinaRepository(),
                CrearBusquedaUsuarios(usuarioController),
                entrenadorController,
                rutinaController)
        {
        }

        // Permite indicar cómo se buscan los usuarios (por ejemplo, en pruebas).
        public AsignacionRutinaController(
            AsignacionRutinaRepository repositorio,
            Func<int, Usuario?> buscarUsuario,
            EntrenadorController entrenadorController,
            RutinaController rutinaController)
        {
            this.repositorio = repositorio
                ?? throw new ArgumentNullException(nameof(repositorio));
            this.buscarUsuario = buscarUsuario
                ?? throw new ArgumentNullException(nameof(buscarUsuario));
            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));
            this.rutinaController = rutinaController
                ?? throw new ArgumentNullException(nameof(rutinaController));

            // Recuperar las asignaciones guardadas anteriormente.
            asignaciones = repositorio.CargarAsignaciones();

            // Continuar la numeración desde el último ID.
            siguienteId = asignaciones.Count > 0
                ? asignaciones.Max(a => a.Id) + 1
                : 1;
        }

        private static Func<int, Usuario?> CrearBusquedaUsuarios(UsuarioController usuarioController)
        {
            ArgumentNullException.ThrowIfNull(usuarioController);

            return id => usuarioController.ObtenerUsuarios().FirstOrDefault(u => u.Id == id);
        }

        public AsignacionRutina AsignarRutina(
            int? idUsuario,
            int? idEntrenador,
            int? idRutina,
            DateTime fechaInicio,
            DateTime fechaFin,
            int frecuenciaSemanal,
            string? indicaciones)
        {
            // Usuario. El modelo de usuario todavía no tiene estado de cuenta,
            // por lo que todo usuario registrado se considera activo.
            if (idUsuario == null)
                throw new ArgumentException("Debe seleccionar un usuario.");

            Usuario usuario = buscarUsuario(idUsuario.Value)
                ?? throw new ArgumentException("El usuario seleccionado no existe.");

            // Entrenador: debe ser entrenador personal con la cuenta activa.
            if (idEntrenador == null)
                throw new ArgumentException("Debe seleccionar el entrenador.");

            Entrenador entrenador = entrenadorController.ObtenerEntrenadorPorId(idEntrenador.Value)
                ?? throw new ArgumentException("El entrenador seleccionado no existe.");

            if (entrenador.Tipo != TipoEntrenador.EntrenadorPersonal)
                throw new ArgumentException(
                    "Solo un entrenador personal puede realizar asignaciones individuales de rutinas.");

            if (entrenador.Estado != EstadoCuenta.Activo)
                throw new ArgumentException("El entrenador seleccionado no tiene la cuenta activa.");

            // Rutina: debe existir y estar disponible.
            if (idRutina == null)
                throw new ArgumentException("Debe seleccionar una rutina.");

            Rutina rutina = rutinaController.ObtenerRutinaPorId(idRutina.Value)
                ?? throw new ArgumentException("La rutina seleccionada no existe.");

            if (rutina.Estado != EstadoRutina.Activa)
                throw new ArgumentException(
                    "La rutina seleccionada no está disponible para asignación.");

            // Fechas.
            DateTime inicio = fechaInicio.Date;
            DateTime fin = fechaFin.Date;

            if (inicio < DateTime.Today)
                throw new ArgumentException("La fecha de inicio no puede ser anterior a hoy.");

            if (fin < inicio)
                throw new ArgumentException(
                    "La fecha de finalización no puede ser anterior a la fecha de inicio.");

            // Frecuencia semanal.
            if (frecuenciaSemanal < FrecuenciaMinima || frecuenciaSemanal > FrecuenciaMaxima)
                throw new ArgumentException(
                    $"La frecuencia semanal debe ser un número entero entre " +
                    $"{FrecuenciaMinima} y {FrecuenciaMaxima} días.");

            // Indicaciones opcionales.
            if (indicaciones?.Trim().Length > LongitudMaximaIndicaciones)
                throw new ArgumentException(
                    $"Las indicaciones no pueden superar {LongitudMaximaIndicaciones} caracteres.");

            // No asignar la misma rutina al mismo usuario en fechas que coinciden.
            AsignacionRutina? coincidente = asignaciones.FirstOrDefault(a =>
                a.IdUsuario == usuario.Id &&
                a.IdRutina == rutina.Id &&
                a.SeSolapaCon(inicio, fin));

            if (coincidente != null)
                throw new ArgumentException(
                    "El usuario ya tiene asignada esta rutina del " +
                    $"{coincidente.FechaInicio:dd/MM/yyyy} al {coincidente.FechaFin:dd/MM/yyyy}. " +
                    "Las fechas no pueden coincidir.");

            AsignacionRutina nuevaAsignacion = new AsignacionRutina(
                siguienteId,
                usuario.Id,
                entrenador.Id,
                rutina.Id,
                inicio,
                fin,
                frecuenciaSemanal,
                indicaciones,
                DateTime.Now);

            asignaciones.Add(nuevaAsignacion);

            try
            {
                // Guardar la lista actualizada en JSON.
                repositorio.GuardarAsignaciones(asignaciones);
            }
            catch
            {
                // Revertir la asignación si falla el guardado.
                asignaciones.Remove(nuevaAsignacion);
                throw;
            }

            siguienteId++;

            return nuevaAsignacion;
        }

        // Advertencia informativa cuando la frecuencia semanal no coincide con
        // la cantidad de días de entrenamiento de la rutina. Devuelve null si coinciden.
        public string? ObtenerAdvertenciaFrecuencia(int idRutina, int frecuenciaSemanal)
        {
            Rutina? rutina = rutinaController.ObtenerRutinaPorId(idRutina);

            if (rutina == null)
                return null;

            int diasRutina = rutina.DiasEntrenamiento.Count;

            if (diasRutina == frecuenciaSemanal)
                return null;

            string textoDias = diasRutina == 1 ? "1 día" : $"{diasRutina} días";
            string textoFrecuencia = frecuenciaSemanal == 1 ? "1 día" : $"{frecuenciaSemanal} días";

            return $"La rutina \"{rutina.Nombre}\" tiene {textoDias} de entrenamiento por semana, " +
                   $"pero la frecuencia indicada es de {textoFrecuencia}.";
        }

        public List<AsignacionRutina> ObtenerAsignaciones()
        {
            return new List<AsignacionRutina>(asignaciones);
        }

        public AsignacionRutina? ObtenerAsignacionPorId(int id)
        {
            return asignaciones.FirstOrDefault(a => a.Id == id);
        }

        // Asignaciones de un usuario, de la más reciente a la más antigua.
        public List<AsignacionRutina> ObtenerAsignacionesPorUsuario(int idUsuario)
        {
            return asignaciones
                .Where(a => a.IdUsuario == idUsuario)
                .OrderByDescending(a => a.FechaInicio)
                .ThenByDescending(a => a.Id)
                .ToList();
        }

        // Asignaciones realizadas por un entrenador, de la más reciente a la más antigua.
        public List<AsignacionRutina> ObtenerAsignacionesPorEntrenador(int idEntrenador)
        {
            return asignaciones
                .Where(a => a.IdEntrenador == idEntrenador)
                .OrderByDescending(a => a.FechaInicio)
                .ThenByDescending(a => a.Id)
                .ToList();
        }
    }
}
