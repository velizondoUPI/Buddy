using System;
using System.Windows.Forms;
using Buddy.Models;

namespace Buddy.Views
{
    // Textos en español y utilidades compartidas por los formularios de rutinas.
    // Reutiliza OpcionLista<T> y las utilidades genéricas de TextosEntrenador.
    internal static class TextosRutina
    {
        public static string Texto(ObjetivoRutina objetivo) => objetivo switch
        {
            ObjetivoRutina.AumentoMasaMuscular => "Aumento de masa muscular",
            ObjetivoRutina.PerdidaGrasa => "Pérdida de grasa",
            ObjetivoRutina.MejoraResistencia => "Mejora de resistencia",
            ObjetivoRutina.DesarrolloFuerza => "Desarrollo de fuerza",
            ObjetivoRutina.AcondicionamientoGeneral => "Acondicionamiento general",
            _ => objetivo.ToString()
        };

        public static string Texto(NivelDificultad dificultad) => dificultad switch
        {
            NivelDificultad.Principiante => "Principiante",
            NivelDificultad.Intermedio => "Intermedio",
            NivelDificultad.Avanzado => "Avanzado",
            _ => dificultad.ToString()
        };

        public static string Texto(DiaSemana dia) => dia switch
        {
            DiaSemana.Lunes => "Lunes",
            DiaSemana.Martes => "Martes",
            DiaSemana.Miercoles => "Miércoles",
            DiaSemana.Jueves => "Jueves",
            DiaSemana.Viernes => "Viernes",
            DiaSemana.Sabado => "Sábado",
            DiaSemana.Domingo => "Domingo",
            _ => dia.ToString()
        };

        public static void LlenarObjetivos(ComboBox combo)
        {
            combo.Items.Clear();
            foreach (ObjetivoRutina objetivo in Enum.GetValues<ObjetivoRutina>())
                combo.Items.Add(new OpcionLista<ObjetivoRutina>(objetivo, Texto(objetivo)));
            combo.SelectedIndex = -1;
        }

        public static void LlenarDificultades(ComboBox combo)
        {
            combo.Items.Clear();
            foreach (NivelDificultad dificultad in Enum.GetValues<NivelDificultad>())
                combo.Items.Add(new OpcionLista<NivelDificultad>(dificultad, Texto(dificultad)));
            combo.SelectedIndex = -1;
        }

        public static void LlenarDias(CheckedListBox lista)
        {
            lista.Items.Clear();
            foreach (DiaSemana dia in Enum.GetValues<DiaSemana>())
                lista.Items.Add(new OpcionLista<DiaSemana>(dia, Texto(dia)));
        }

        // Peso en kilogramos o "—" cuando no se indicó.
        public static string FormatearPeso(decimal? pesoKg) =>
            pesoKg.HasValue ? $"{pesoKg.Value:0.##} kg" : "—";
    }
}
