using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Buddy.Models;

namespace Buddy.Data
{
    // Sigue el mismo esquema de almacenamiento que UsuarioRepository:
    // escritura en un archivo temporal, reemplazo con respaldo (.bak)
    // y recuperación desde el respaldo si el archivo principal falla.
    public class EntrenadorRepository
    {
        private readonly string rutaArchivo;

        private static readonly JsonSerializerOptions opcionesJson = new()
        {
            WriteIndented = true,
            // Guardar tipos, especialidades y estados como texto legible.
            Converters = { new JsonStringEnumConverter() }
        };

        public bool DatosRecuperadosDelRespaldo { get; private set; } = false;

        // Por defecto se usa la misma carpeta de datos que los usuarios.
        // La carpeta puede indicarse para trabajar con datos temporales.
        public EntrenadorRepository(string? carpetaDatos = null)
        {
            carpetaDatos ??= Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "Buddy"
            );

            Directory.CreateDirectory(carpetaDatos);

            rutaArchivo = Path.Combine(carpetaDatos, "entrenadores.json");
        }

        public List<Entrenador> CargarEntrenadores()
        {
            string rutaRespaldo = rutaArchivo + ".bak";

            // Si todavía no se ha registrado ningún entrenador, no hay datos.
            if (!File.Exists(rutaArchivo) &&
                !File.Exists(rutaRespaldo))
            {
                return new List<Entrenador>();
            }

            // Intentar recuperar los datos del archivo principal.
            if (File.Exists(rutaArchivo))
            {
                try
                {
                    return LeerEntrenadores(rutaArchivo);
                }
                catch (Exception ex) when (
                    ex is JsonException ||
                    ex is IOException ||
                    ex is UnauthorizedAccessException ||
                    ex is ArgumentException)
                {
                    // Intentaremos recuperar desde el respaldo.
                }
            }

            // Si el archivo principal falla, utilizar el respaldo.
            if (File.Exists(rutaRespaldo))
            {
                try
                {
                    List<Entrenador> entrenadoresRecuperados =
                        LeerEntrenadores(rutaRespaldo);

                    DatosRecuperadosDelRespaldo = true;

                    return entrenadoresRecuperados;
                }
                catch (Exception ex) when (
                    ex is JsonException ||
                    ex is IOException ||
                    ex is UnauthorizedAccessException ||
                    ex is ArgumentException)
                {
                    throw new InvalidOperationException(
                        "No se pudieron recuperar los entrenadores. " +
                        "El archivo principal y el respaldo " +
                        "no están disponibles o son inválidos.",
                        ex);
                }
            }

            throw new InvalidOperationException(
                "No se pudieron recuperar los entrenadores " +
                "y no existe una copia de respaldo.");
        }

        private List<Entrenador> LeerEntrenadores(string ruta)
        {
            string contenido = File.ReadAllText(ruta);

            if (string.IsNullOrWhiteSpace(contenido))
            {
                throw new JsonException(
                    "El archivo de entrenadores está vacío.");
            }

            List<Entrenador>? entrenadores =
                JsonSerializer.Deserialize<List<Entrenador>>(contenido, opcionesJson);

            if (entrenadores == null || entrenadores.Any(e => e == null))
            {
                throw new JsonException(
                    "El archivo no contiene una lista válida de entrenadores.");
            }

            return entrenadores;
        }

        public void GuardarEntrenadores(List<Entrenador> entrenadores)
        {
            if (DatosRecuperadosDelRespaldo)
            {
                throw new InvalidOperationException(
                    "Los entrenadores fueron recuperados desde una copia de respaldo. " +
                    "Por seguridad, no se permite guardar nuevos registros " +
                    "hasta revisar y restaurar el archivo principal.");
            }

            // Convertir los entrenadores a formato JSON.
            string contenido = JsonSerializer.Serialize(entrenadores, opcionesJson);

            // Crear un archivo temporal en la misma carpeta.
            string rutaTemporal = rutaArchivo + ".tmp";

            try
            {
                // Escribir primero los datos en el archivo temporal.
                File.WriteAllText(rutaTemporal, contenido);

                if (File.Exists(rutaArchivo))
                {
                    // Reemplazar el archivo principal y conservar
                    // una copia de respaldo de la versión anterior.
                    string rutaRespaldo = rutaArchivo + ".bak";

                    File.Replace(
                        rutaTemporal,
                        rutaArchivo,
                        rutaRespaldo
                    );
                }
                else
                {
                    // Crear el archivo definitivo por primera vez.
                    File.Move(rutaTemporal, rutaArchivo);
                }
            }
            finally
            {
                // Eliminar el temporal si todavía existe.
                if (File.Exists(rutaTemporal))
                {
                    File.Delete(rutaTemporal);
                }
            }
        }
    }
}
