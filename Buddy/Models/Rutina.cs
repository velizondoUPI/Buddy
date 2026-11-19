using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Buddy.Models
{
    public class Rutina
    {
        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public ObjetivoRutina Objetivo { get; private set; }

        public NivelDificultad Dificultad { get; private set; }

        public string Descripcion { get; private set; }

        public int DuracionMinutos { get; private set; }

        // Días de entrenamiento ordenados de lunes a domingo.
        public IReadOnlyList<DiaSemana> DiasEntrenamiento { get; private set; }

        // Ejercicios ordenados por día y por orden de ejecución.
        public IReadOnlyList<EjercicioRutina> Ejercicios { get; private set; }

        public int IdEntrenadorCreador { get; private set; }

        public DateTime FechaCreacion { get; private set; }

        public EstadoRutina Estado { get; private set; }

        [JsonConstructor]
        public Rutina(
            int id,
            string nombre,
            ObjetivoRutina objetivo,
            NivelDificultad dificultad,
            string descripcion,
            int duracionMinutos,
            IReadOnlyList<DiaSemana> diasEntrenamiento,
            IReadOnlyList<EjercicioRutina> ejercicios,
            int idEntrenadorCreador,
            DateTime fechaCreacion,
            EstadoRutina estado)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException(
                    "El nombre de la rutina es obligatorio.", nameof(nombre));

            if (!Enum.IsDefined(objetivo))
                throw new ArgumentException(
                    "El objetivo de la rutina no es válido.", nameof(objetivo));

            if (!Enum.IsDefined(dificultad))
                throw new ArgumentException(
                    "El nivel de dificultad no es válido.", nameof(dificultad));

            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException(
                    "La descripción de la rutina es obligatoria.", nameof(descripcion));

            if (duracionMinutos <= 0)
                throw new ArgumentException(
                    "La duración estimada debe ser mayor que cero.", nameof(duracionMinutos));

            if (diasEntrenamiento == null || diasEntrenamiento.Count == 0)
                throw new ArgumentException(
                    "La rutina debe tener al menos un día de entrenamiento.",
                    nameof(diasEntrenamiento));

            if (diasEntrenamiento.Any(d => !Enum.IsDefined(d)) ||
                diasEntrenamiento.Distinct().Count() != diasEntrenamiento.Count)
                throw new ArgumentException(
                    "Los días de entrenamiento no son válidos.", nameof(diasEntrenamiento));

            if (ejercicios == null || ejercicios.Count == 0 || ejercicios.Any(e => e == null))
                throw new ArgumentException(
                    "La rutina debe contener al menos un ejercicio.", nameof(ejercicios));

            if (ejercicios.Any(e => !diasEntrenamiento.Contains(e.Dia)))
                throw new ArgumentException(
                    "Todos los ejercicios deben pertenecer a un día de entrenamiento de la rutina.",
                    nameof(ejercicios));

            if (diasEntrenamiento.Any(d => ejercicios.All(e => e.Dia != d)))
                throw new ArgumentException(
                    "Cada día de entrenamiento debe tener al menos un ejercicio.",
                    nameof(ejercicios));

            if (ejercicios.GroupBy(e => new { e.Dia, e.Orden }).Any(g => g.Count() > 1))
                throw new ArgumentException(
                    "No puede haber dos ejercicios con el mismo orden en un mismo día.",
                    nameof(ejercicios));

            if (ejercicios.Select(e => e.Id).Distinct().Count() != ejercicios.Count)
                throw new ArgumentException(
                    "Los identificadores de los ejercicios no pueden repetirse.",
                    nameof(ejercicios));

            if (idEntrenadorCreador <= 0)
                throw new ArgumentException(
                    "La rutina debe tener un entrenador creador.", nameof(idEntrenadorCreador));

            if (fechaCreacion == default)
                throw new ArgumentException(
                    "La fecha de creación es obligatoria.", nameof(fechaCreacion));

            if (!Enum.IsDefined(estado))
                throw new ArgumentException(
                    "El estado de la rutina no es válido.", nameof(estado));

            Id = id;
            Nombre = nombre.Trim();
            Objetivo = objetivo;
            Dificultad = dificultad;
            Descripcion = descripcion.Trim();
            DuracionMinutos = duracionMinutos;
            DiasEntrenamiento = diasEntrenamiento.OrderBy(d => d).ToList().AsReadOnly();
            Ejercicios = ejercicios
                .OrderBy(e => e.Dia)
                .ThenBy(e => e.Orden)
                .ToList()
                .AsReadOnly();
            IdEntrenadorCreador = idEntrenadorCreador;
            FechaCreacion = fechaCreacion;
            Estado = estado;
        }

        // Ejercicios de un día concreto, en su orden de ejecución.
        public IEnumerable<EjercicioRutina> ObtenerEjerciciosDelDia(DiaSemana dia)
        {
            return Ejercicios.Where(e => e.Dia == dia).OrderBy(e => e.Orden);
        }
    }
}
