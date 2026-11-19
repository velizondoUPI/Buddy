using System.Collections.Generic;
using Buddy.Models;

namespace Buddy.Data
{
    // Guarda las rutinas junto con sus ejercicios en rutinas.json,
    // de modo que ambos se guardan en una sola operación.
    public class RutinaRepository : RepositorioJson<Rutina>
    {
        public RutinaRepository(string? carpetaDatos = null)
            : base("rutinas.json", "rutinas", carpetaDatos)
        {
        }

        public List<Rutina> CargarRutinas() => Cargar();

        public void GuardarRutinas(List<Rutina> rutinas) => Guardar(rutinas);
    }
}
