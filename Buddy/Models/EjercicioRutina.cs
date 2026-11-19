using System;
using System.Text.Json.Serialization;

namespace Buddy.Models
{
    // Ejercicio que forma parte de una rutina, asociado a un día de entrenamiento.
    public class EjercicioRutina
    {
        // Identificador único dentro de la rutina.
        public int Id { get; private set; }

        public string Nombre { get; private set; }

        // Descripción o indicación básica de ejecución.
        public string Descripcion { get; private set; }

        public DiaSemana Dia { get; private set; }

        // Orden de ejecución dentro del día (1, 2, 3...).
        public int Orden { get; private set; }

        public int Series { get; private set; }

        public int Repeticiones { get; private set; }

        public int DescansoSegundos { get; private set; }

        // Peso recomendado en kilogramos, cuando corresponda.
        public decimal? PesoRecomendadoKg { get; private set; }

        public string? Indicaciones { get; private set; }

        [JsonConstructor]
        public EjercicioRutina(
            int id,
            string nombre,
            string descripcion,
            DiaSemana dia,
            int orden,
            int series,
            int repeticiones,
            int descansoSegundos,
            decimal? pesoRecomendadoKg,
            string? indicaciones)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException(
                    "El nombre del ejercicio es obligatorio.", nameof(nombre));

            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException(
                    "La descripción del ejercicio es obligatoria.", nameof(descripcion));

            if (!Enum.IsDefined(dia))
                throw new ArgumentException(
                    "El día del ejercicio no es válido.", nameof(dia));

            if (orden <= 0)
                throw new ArgumentException(
                    "El orden del ejercicio debe ser mayor que cero.", nameof(orden));

            if (series <= 0)
                throw new ArgumentException(
                    "Las series deben ser mayores que cero.", nameof(series));

            if (repeticiones <= 0)
                throw new ArgumentException(
                    "Las repeticiones deben ser mayores que cero.", nameof(repeticiones));

            if (descansoSegundos < 0)
                throw new ArgumentException(
                    "El descanso no puede ser negativo.", nameof(descansoSegundos));

            if (pesoRecomendadoKg < 0)
                throw new ArgumentException(
                    "El peso recomendado no puede ser negativo.", nameof(pesoRecomendadoKg));

            Id = id;
            Nombre = nombre.Trim();
            Descripcion = descripcion.Trim();
            Dia = dia;
            Orden = orden;
            Series = series;
            Repeticiones = repeticiones;
            DescansoSegundos = descansoSegundos;
            PesoRecomendadoKg = pesoRecomendadoKg;
            Indicaciones = string.IsNullOrWhiteSpace(indicaciones)
                ? null
                : indicaciones.Trim();
        }
    }
}
