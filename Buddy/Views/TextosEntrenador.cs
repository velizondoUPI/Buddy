using System;
using System.Linq;
using System.Windows.Forms;
using Buddy.Models;

namespace Buddy.Views
{
    // Textos en español y utilidades compartidas por los formularios de entrenadores.
    internal static class TextosEntrenador
    {
        public const string OpcionTodos = "Todos";

        public static string Texto(TipoEntrenador tipo) => tipo switch
        {
            TipoEntrenador.EntrenadorPersonal => "Entrenador personal",
            TipoEntrenador.InstructorClasesGrupales => "Instructor de clases grupales",
            _ => tipo.ToString()
        };

        public static string Texto(EspecialidadEntrenador especialidad) => especialidad switch
        {
            EspecialidadEntrenador.EntrenamientoFuerza => "Entrenamiento de fuerza",
            EspecialidadEntrenador.AcondicionamientoFisico => "Acondicionamiento físico",
            EspecialidadEntrenador.Yoga => "Yoga",
            EspecialidadEntrenador.Zumba => "Zumba",
            EspecialidadEntrenador.Spinning => "Spinning",
            EspecialidadEntrenador.Crossfit => "Crossfit",
            _ => especialidad.ToString()
        };

        public static string Texto(EstadoCuenta estado) => estado switch
        {
            EstadoCuenta.Activo => "Activo",
            EstadoCuenta.Inactivo => "Inactivo",
            _ => estado.ToString()
        };

        // Muestra el teléfono guardado (8 dígitos) como 8888-1234.
        public static string FormatearTelefono(string telefono)
        {
            if (telefono != null && telefono.Length == 8 && telefono.All(char.IsAsciiDigit))
                return $"{telefono[..4]}-{telefono[4..]}";

            return telefono ?? string.Empty;
        }

        public static void LlenarTipos(ComboBox combo, bool incluirTodos = false)
        {
            LlenarLista(combo, Enum.GetValues<TipoEntrenador>(), Texto, incluirTodos);
        }

        public static void LlenarEspecialidades(ComboBox combo, bool incluirTodos = false)
        {
            LlenarLista(combo, Enum.GetValues<EspecialidadEntrenador>(), Texto, incluirTodos);
        }

        // Devuelve el valor elegido o null si no hay selección o se eligió "Todos".
        public static T? ValorSeleccionado<T>(ComboBox combo) where T : struct, Enum
        {
            return combo.SelectedItem is OpcionLista<T> opcion ? opcion.Valor : null;
        }

        public static void SeleccionarValor<T>(ComboBox combo, T valor) where T : struct, Enum
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i] is OpcionLista<T> opcion &&
                    opcion.Valor.Equals(valor))
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }

            combo.SelectedIndex = -1;
        }

        private static void LlenarLista<T>(
            ComboBox combo,
            T[] valores,
            Func<T, string> obtenerTexto,
            bool incluirTodos) where T : struct, Enum
        {
            combo.Items.Clear();

            if (incluirTodos)
                combo.Items.Add(OpcionTodos);

            foreach (T valor in valores)
                combo.Items.Add(new OpcionLista<T>(valor, obtenerTexto(valor)));

            combo.SelectedIndex = incluirTodos ? 0 : -1;
        }
    }

    // Elemento de una lista desplegable con su texto en español.
    internal sealed class OpcionLista<T> where T : struct, Enum
    {
        public T Valor { get; }
        public string Texto { get; }

        public OpcionLista(T valor, string texto)
        {
            Valor = valor;
            Texto = texto;
        }

        public override string ToString() => Texto;
    }
}
