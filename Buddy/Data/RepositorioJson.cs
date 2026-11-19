using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Buddy.Data
{
    // Base para los repositorios JSON de Buddy. Mantiene el mismo esquema que
    // UsuarioRepository y EntrenadorRepository: escritura en un archivo temporal,
    // reemplazo con respaldo (.bak) y recuperación desde el respaldo si el
    // archivo principal falla (bloqueando el guardado en ese caso).
    public abstract class RepositorioJson<T> where T : class
    {
        private readonly string rutaArchivo;

        // Nombre de los registros en plural, para los mensajes ("rutinas").
        private readonly string nombreRegistros;

        private static readonly JsonSerializerOptions opcionesJson = new()
        {
            WriteIndented = true,
            // Guardar las enumeraciones como texto legible.
            Converters = { new JsonStringEnumConverter() }
        };

        public bool DatosRecuperadosDelRespaldo { get; private set; } = false;

        // Por defecto se usa la carpeta de datos de Buddy.
        // La carpeta puede indicarse para trabajar con datos temporales.
        protected RepositorioJson(
            string nombreArchivo,
            string nombreRegistros,
            string? carpetaDatos = null)
        {
            this.nombreRegistros = nombreRegistros;

            carpetaDatos ??= Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "Buddy"
            );

            Directory.CreateDirectory(carpetaDatos);

            rutaArchivo = Path.Combine(carpetaDatos, nombreArchivo);
        }

        protected List<T> Cargar()
        {
            string rutaRespaldo = rutaArchivo + ".bak";

            // Si todavía no existe ningún registro, no hay datos.
            if (!File.Exists(rutaArchivo) &&
                !File.Exists(rutaRespaldo))
            {
                return new List<T>();
            }

            // Intentar recuperar los datos del archivo principal.
            if (File.Exists(rutaArchivo))
            {
                try
                {
                    return Leer(rutaArchivo);
                }
                catch (Exception ex) when (EsErrorDeLectura(ex))
                {
                    // Intentaremos recuperar desde el respaldo.
                }
            }

            // Si el archivo principal falla, utilizar el respaldo.
            if (File.Exists(rutaRespaldo))
            {
                try
                {
                    List<T> recuperados = Leer(rutaRespaldo);

                    DatosRecuperadosDelRespaldo = true;

                    return recuperados;
                }
                catch (Exception ex) when (EsErrorDeLectura(ex))
                {
                    throw new InvalidOperationException(
                        $"No se pudieron recuperar las {nombreRegistros}. " +
                        "El archivo principal y el respaldo " +
                        "no están disponibles o son inválidos.",
                        ex);
                }
            }

            throw new InvalidOperationException(
                $"No se pudieron recuperar las {nombreRegistros} " +
                "y no existe una copia de respaldo.");
        }

        protected void Guardar(List<T> registros)
        {
            if (DatosRecuperadosDelRespaldo)
            {
                throw new InvalidOperationException(
                    $"Las {nombreRegistros} fueron recuperadas desde una copia de respaldo. " +
                    "Por seguridad, no se permite guardar nuevos registros " +
                    "hasta revisar y restaurar el archivo principal.");
            }

            // Convertir los registros a formato JSON.
            string contenido = JsonSerializer.Serialize(registros, opcionesJson);

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
                    File.Replace(
                        rutaTemporal,
                        rutaArchivo,
                        rutaArchivo + ".bak"
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

        private List<T> Leer(string ruta)
        {
            string contenido = File.ReadAllText(ruta);

            if (string.IsNullOrWhiteSpace(contenido))
            {
                throw new JsonException(
                    $"El archivo de {nombreRegistros} está vacío.");
            }

            List<T>? registros = JsonSerializer.Deserialize<List<T>>(contenido, opcionesJson);

            if (registros == null || registros.Any(r => r == null))
            {
                throw new JsonException(
                    $"El archivo no contiene una lista válida de {nombreRegistros}.");
            }

            return registros;
        }

        private static bool EsErrorDeLectura(Exception ex) =>
            ex is JsonException ||
            ex is IOException ||
            ex is UnauthorizedAccessException ||
            ex is ArgumentException ||
            ex is NotSupportedException;
    }
}
