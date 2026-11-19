using System;
using System.Collections.Generic;
using System.Linq;
using Buddy.Data;
using Buddy.Models;

namespace Buddy.Controllers
{
    public class RutinaController
    {
        public const int LongitudMaximaNombre = 100;
        public const int LongitudMaximaDescripcion = 1000;
        public const int LongitudMaximaNombreEjercicio = 100;
        public const int LongitudMaximaDescripcionEjercicio = 500;
        public const int LongitudMaximaIndicaciones = 500;

        private readonly List<Rutina> rutinas;
        private readonly RutinaRepository repositorio;

        // Entrenadores registrados, para validar al creador de la rutina.
        private readonly EntrenadorController entrenadorController;

        private int siguienteId;

        public RutinaController(EntrenadorController entrenadorController)
            : this(new RutinaRepository(), entrenadorController)
        {
        }

        public RutinaController(
            RutinaRepository repositorio,
            EntrenadorController entrenadorController)
        {
            this.repositorio = repositorio
                ?? throw new ArgumentNullException(nameof(repositorio));
            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));

            // Recuperar las rutinas guardadas anteriormente.
            rutinas = repositorio.CargarRutinas();

            // Continuar la numeración desde el último ID.
            siguienteId = rutinas.Count > 0
                ? rutinas.Max(r => r.Id) + 1
                : 1;
        }

        public Rutina CrearRutina(
            int? idEntrenadorCreador,
            string nombre,
            ObjetivoRutina? objetivo,
            NivelDificultad? dificultad,
            string descripcion,
            int duracionMinutos,
            IEnumerable<DiaSemana> diasEntrenamiento,
            IReadOnlyList<DatosEjercicio> ejercicios)
        {
            // Entrenador creador: debe existir, ser entrenador personal y estar activo.
            if (idEntrenadorCreador == null)
                throw new ArgumentException("Debe seleccionar el entrenador creador.");

            Entrenador creador = entrenadorController.ObtenerEntrenadorPorId(idEntrenadorCreador.Value)
                ?? throw new ArgumentException("El entrenador creador seleccionado no existe.");

            if (creador.Tipo != TipoEntrenador.EntrenadorPersonal)
                throw new ArgumentException(
                    "Solo un entrenador personal puede crear rutinas de ejercicio.");

            if (creador.Estado != EstadoCuenta.Activo)
                throw new ArgumentException("El entrenador creador no tiene la cuenta activa.");

            // Datos generales.
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Debe ingresar el nombre de la rutina.");

            if (nombre.Trim().Length > LongitudMaximaNombre)
                throw new ArgumentException(
                    $"El nombre de la rutina no puede superar {LongitudMaximaNombre} caracteres.");

            if (objetivo == null || !Enum.IsDefined(objetivo.Value))
                throw new ArgumentException("Debe seleccionar el objetivo de la rutina.");

            if (dificultad == null || !Enum.IsDefined(dificultad.Value))
                throw new ArgumentException("Debe seleccionar el nivel de dificultad.");

            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("Debe ingresar la descripción de la rutina.");

            if (descripcion.Trim().Length > LongitudMaximaDescripcion)
                throw new ArgumentException(
                    $"La descripción de la rutina no puede superar {LongitudMaximaDescripcion} caracteres.");

            if (duracionMinutos <= 0)
                throw new ArgumentException(
                    "La duración estimada debe ser un número entero de minutos mayor que cero.");

            // Días de entrenamiento.
            List<DiaSemana> dias = (diasEntrenamiento ?? Enumerable.Empty<DiaSemana>())
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            if (dias.Count == 0)
                throw new ArgumentException("Debe seleccionar al menos un día de entrenamiento.");

            if (dias.Any(d => !Enum.IsDefined(d)))
                throw new ArgumentException("Los días de entrenamiento seleccionados no son válidos.");

            // Ejercicios.
            if (ejercicios == null || ejercicios.Count == 0)
                throw new ArgumentException("La rutina debe contener al menos un ejercicio.");

            for (int i = 0; i < ejercicios.Count; i++)
                ValidarEjercicio(i, ejercicios[i], dias);

            // Orden de ejecución único dentro de cada día.
            var ordenRepetido = ejercicios
                .Select((e, indice) => new { e, indice })
                .GroupBy(x => new { x.e.Dia, x.e.Orden })
                .FirstOrDefault(g => g.Count() > 1);

            if (ordenRepetido != null)
            {
                var segundo = ordenRepetido.Skip(1).First();
                throw new ValidacionEjercicioException(
                    segundo.indice,
                    $"{DescribirEjercicio(segundo.indice, segundo.e)}: ya existe otro ejercicio " +
                    $"con el orden {segundo.e.Orden} en ese día.");
            }

            // Cada día seleccionado debe tener al menos un ejercicio.
            DiaSemana? diaSinEjercicios = dias
                .Cast<DiaSemana?>()
                .FirstOrDefault(d => ejercicios.All(e => e.Dia != d));

            if (diaSinEjercicios != null)
                throw new ArgumentException(
                    $"El día {NombreDia(diaSinEjercicios.Value)} no tiene ejercicios. " +
                    "Agregue al menos un ejercicio o desmárquelo.");

            // Crear los ejercicios con identificadores únicos dentro de la rutina.
            List<EjercicioRutina> ejerciciosRutina = ejercicios
                .OrderBy(e => e.Dia)
                .ThenBy(e => e.Orden)
                .Select((e, indice) => new EjercicioRutina(
                    indice + 1,
                    e.Nombre,
                    e.Descripcion,
                    e.Dia!.Value,
                    e.Orden,
                    e.Series,
                    e.Repeticiones,
                    e.DescansoSegundos,
                    e.PesoRecomendadoKg,
                    e.Indicaciones))
                .ToList();

            Rutina nuevaRutina = new Rutina(
                siguienteId,
                nombre,
                objetivo.Value,
                dificultad.Value,
                descripcion,
                duracionMinutos,
                dias,
                ejerciciosRutina,
                creador.Id,
                DateTime.Now,
                EstadoRutina.Activa);

            rutinas.Add(nuevaRutina);

            try
            {
                // Guardar la rutina y sus ejercicios en una sola operación.
                repositorio.GuardarRutinas(rutinas);
            }
            catch
            {
                // Revertir la creación si falla el guardado.
                rutinas.Remove(nuevaRutina);
                throw;
            }

            siguienteId++;

            return nuevaRutina;
        }

        public List<Rutina> ObtenerRutinas()
        {
            return new List<Rutina>(rutinas);
        }

        // Rutinas que pueden asignarse a usuarios.
        public List<Rutina> ObtenerRutinasDisponibles()
        {
            return rutinas.Where(r => r.Estado == EstadoRutina.Activa).ToList();
        }

        public Rutina? ObtenerRutinaPorId(int id)
        {
            return rutinas.FirstOrDefault(r => r.Id == id);
        }

        private static void ValidarEjercicio(
            int indice,
            DatosEjercicio ejercicio,
            List<DiaSemana> dias)
        {
            if (ejercicio == null)
                throw new ValidacionEjercicioException(
                    indice, $"Ejercicio {indice + 1}: los datos no son válidos.");

            string descripcion = DescribirEjercicio(indice, ejercicio);

            [System.Diagnostics.CodeAnalysis.DoesNotReturn]
            void Error(string mensaje) =>
                throw new ValidacionEjercicioException(indice, $"{descripcion}: {mensaje}");

            if (string.IsNullOrWhiteSpace(ejercicio.Nombre))
                Error("debe ingresar el nombre del ejercicio.");

            if (ejercicio.Nombre.Trim().Length > LongitudMaximaNombreEjercicio)
                Error($"el nombre no puede superar {LongitudMaximaNombreEjercicio} caracteres.");

            if (string.IsNullOrWhiteSpace(ejercicio.Descripcion))
                Error("debe ingresar la descripción o indicación básica de ejecución.");

            if (ejercicio.Descripcion.Trim().Length > LongitudMaximaDescripcionEjercicio)
                Error($"la descripción no puede superar {LongitudMaximaDescripcionEjercicio} caracteres.");

            if (ejercicio.Dia == null || !Enum.IsDefined(ejercicio.Dia.Value))
                Error("debe seleccionar el día de entrenamiento del ejercicio.");

            if (!dias.Contains(ejercicio.Dia!.Value))
                Error($"el día {NombreDia(ejercicio.Dia.Value)} no está seleccionado como día de entrenamiento.");

            if (ejercicio.Orden <= 0)
                Error("el orden de ejecución debe ser un número entero mayor que cero.");

            if (ejercicio.Series <= 0)
                Error("las series deben ser un número entero mayor que cero.");

            if (ejercicio.Repeticiones <= 0)
                Error("las repeticiones deben ser un número entero mayor que cero.");

            if (ejercicio.DescansoSegundos < 0)
                Error("el tiempo de descanso no puede ser negativo.");

            if (ejercicio.PesoRecomendadoKg < 0)
                Error("el peso recomendado no puede ser negativo.");

            if (ejercicio.Indicaciones?.Trim().Length > LongitudMaximaIndicaciones)
                Error($"las indicaciones no pueden superar {LongitudMaximaIndicaciones} caracteres.");
        }

        private static string DescribirEjercicio(int indice, DatosEjercicio ejercicio)
        {
            return string.IsNullOrWhiteSpace(ejercicio.Nombre)
                ? $"Ejercicio {indice + 1}"
                : $"Ejercicio {indice + 1} ({ejercicio.Nombre.Trim()})";
        }

        public static string NombreDia(DiaSemana dia) => dia switch
        {
            DiaSemana.Lunes => "lunes",
            DiaSemana.Martes => "martes",
            DiaSemana.Miercoles => "miércoles",
            DiaSemana.Jueves => "jueves",
            DiaSemana.Viernes => "viernes",
            DiaSemana.Sabado => "sábado",
            DiaSemana.Domingo => "domingo",
            _ => dia.ToString()
        };
    }
}
