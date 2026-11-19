using System.Collections.Generic;
using Buddy.Models;

namespace Buddy.Data
{
    // Guarda las asignaciones de rutinas en asignaciones_rutinas.json.
    public class AsignacionRutinaRepository : RepositorioJson<AsignacionRutina>
    {
        public AsignacionRutinaRepository(string? carpetaDatos = null)
            : base("asignaciones_rutinas.json", "asignaciones de rutinas", carpetaDatos)
        {
        }

        public List<AsignacionRutina> CargarAsignaciones() => Cargar();

        public void GuardarAsignaciones(List<AsignacionRutina> asignaciones) => Guardar(asignaciones);
    }
}
