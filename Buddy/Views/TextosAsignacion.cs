using System.Linq;
using Buddy.Models;

namespace Buddy.Views
{
    // Textos en español compartidos por los formularios de asignación de rutinas.
    internal static class TextosAsignacion
    {
        public static string Texto(EstadoAsignacion estado) => estado switch
        {
            EstadoAsignacion.Programada => "Programada",
            EstadoAsignacion.Activa => "Activa",
            EstadoAsignacion.Finalizada => "Finalizada",
            _ => estado.ToString()
        };

        public static string Describir(Usuario? usuario) =>
            usuario == null ? "(usuario no disponible)" : $"{usuario.Nombre} ({usuario.NombreUsuario})";

        public static string Describir(Entrenador? entrenador) =>
            entrenador == null ? "(entrenador no disponible)" : $"{entrenador.NombreCompleto} ({entrenador.NombreUsuario})";

        public static string Describir(Rutina? rutina) =>
            rutina == null ? "(rutina no disponible)" : rutina.Nombre;

        public static string DiasRutina(Rutina rutina) =>
            string.Join(", ", rutina.DiasEntrenamiento.Select(TextosRutina.Texto));
    }
}
