using System;
using Buddy.Models;

namespace Buddy.Controllers
{
    // Datos de un ejercicio ingresados en el formulario, antes de validarse.
    public sealed record DatosEjercicio(
        string Nombre,
        string Descripcion,
        DiaSemana? Dia,
        int Orden,
        int Series,
        int Repeticiones,
        int DescansoSegundos,
        decimal? PesoRecomendadoKg,
        string? Indicaciones);

    // Error de validación de un ejercicio concreto. Indica su posición
    // (desde 0) en la lista recibida, para poder señalarlo en el formulario.
    public class ValidacionEjercicioException : ArgumentException
    {
        public int IndiceEjercicio { get; }

        public ValidacionEjercicioException(int indiceEjercicio, string mensaje)
            : base(mensaje)
        {
            IndiceEjercicio = indiceEjercicio;
        }
    }
}
