using System;
using System.Text.Json.Serialization;

namespace Buddy.Models
{
    // Relación entre un usuario, el entrenador que asigna y una rutina.
    public class AsignacionRutina
    {
        public int Id { get; private set; }

        public int IdUsuario { get; private set; }

        public int IdEntrenador { get; private set; }

        public int IdRutina { get; private set; }

        public DateTime FechaInicio { get; private set; }

        public DateTime FechaFin { get; private set; }

        // Cantidad de días de entrenamiento por semana (1 a 7).
        public int FrecuenciaSemanal { get; private set; }

        public string? Indicaciones { get; private set; }

        public DateTime FechaCreacion { get; private set; }

        // El estado no se guarda: se calcula con la fecha actual.
        [JsonIgnore]
        public EstadoAsignacion Estado => CalcularEstado(DateTime.Today);

        [JsonConstructor]
        public AsignacionRutina(
            int id,
            int idUsuario,
            int idEntrenador,
            int idRutina,
            DateTime fechaInicio,
            DateTime fechaFin,
            int frecuenciaSemanal,
            string? indicaciones,
            DateTime fechaCreacion)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (idUsuario <= 0)
                throw new ArgumentException(
                    "La asignación debe tener un usuario.", nameof(idUsuario));

            if (idEntrenador <= 0)
                throw new ArgumentException(
                    "La asignación debe tener un entrenador.", nameof(idEntrenador));

            if (idRutina <= 0)
                throw new ArgumentException(
                    "La asignación debe tener una rutina.", nameof(idRutina));

            if (fechaFin.Date < fechaInicio.Date)
                throw new ArgumentException(
                    "La fecha de finalización no puede ser anterior a la fecha de inicio.",
                    nameof(fechaFin));

            if (frecuenciaSemanal < 1 || frecuenciaSemanal > 7)
                throw new ArgumentException(
                    "La frecuencia semanal debe estar entre 1 y 7 días.",
                    nameof(frecuenciaSemanal));

            if (fechaCreacion == default)
                throw new ArgumentException(
                    "La fecha de creación es obligatoria.", nameof(fechaCreacion));

            Id = id;
            IdUsuario = idUsuario;
            IdEntrenador = idEntrenador;
            IdRutina = idRutina;
            FechaInicio = fechaInicio.Date;
            FechaFin = fechaFin.Date;
            FrecuenciaSemanal = frecuenciaSemanal;
            Indicaciones = string.IsNullOrWhiteSpace(indicaciones)
                ? null
                : indicaciones.Trim();
            FechaCreacion = fechaCreacion;
        }

        public EstadoAsignacion CalcularEstado(DateTime hoy)
        {
            return CalcularEstado(FechaInicio, FechaFin, hoy);
        }

        // Programada antes del inicio, Activa entre el inicio y el fin
        // (ambos incluidos) y Finalizada después del fin.
        public static EstadoAsignacion CalcularEstado(
            DateTime fechaInicio,
            DateTime fechaFin,
            DateTime hoy)
        {
            if (hoy.Date < fechaInicio.Date)
                return EstadoAsignacion.Programada;

            if (hoy.Date > fechaFin.Date)
                return EstadoAsignacion.Finalizada;

            return EstadoAsignacion.Activa;
        }

        // Indica si el período de la asignación coincide con otro período,
        // considerando ambos extremos.
        public bool SeSolapaCon(DateTime fechaInicio, DateTime fechaFin)
        {
            return FechaInicio <= fechaFin.Date && fechaInicio.Date <= FechaFin;
        }
    }
}
