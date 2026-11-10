
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Buddy.Models;
using System.Linq;

namespace Buddy.Data
{
    public class UsuarioRepository
    {
        private readonly string rutaArchivo;
        public bool DatosRecuperadosDelRespaldo { get; private set; } = false;


        public UsuarioRepository()
        {
            string carpetaDatos = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "Buddy"
            );

            Directory.CreateDirectory(carpetaDatos);

            rutaArchivo = Path.Combine(carpetaDatos, "usuarios.json");
        }


        public List<Usuario> CargarUsuarios()
        {
            string rutaRespaldo = rutaArchivo + ".bak";

            // Si es una instalación nueva, no existen datos.
            if (!File.Exists(rutaArchivo) &&
                !File.Exists(rutaRespaldo))
            {
                return new List<Usuario>();
            }

            // Intentar recuperar los datos del archivo principal.
            if (File.Exists(rutaArchivo))
            {
                try
                {
                    return LeerUsuarios(rutaArchivo);
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
                    List<Usuario> usuariosRecuperados =
                        LeerUsuarios(rutaRespaldo);

                    DatosRecuperadosDelRespaldo = true;

                    return usuariosRecuperados;
                }

                catch (Exception ex) when (
                    ex is JsonException ||
                    ex is IOException ||
                    ex is UnauthorizedAccessException ||
                    ex is ArgumentException)
                {
                    throw new InvalidOperationException(
                        "No se pudieron recuperar los usuarios. " +
                        "El archivo principal y el respaldo " +
                        "no están disponibles o son inválidos.",
                        ex);
                }
            }

            throw new InvalidOperationException(
                "No se pudieron recuperar los usuarios " +
                "y no existe una copia de respaldo.");
        }

        private List<Usuario> LeerUsuarios(string ruta)
        {
            string contenido = File.ReadAllText(ruta);

            if (string.IsNullOrWhiteSpace(contenido))
            {
                throw new JsonException(
                    "El archivo de usuarios está vacío.");
            }

            List<Usuario>? usuarios =
                JsonSerializer.Deserialize<List<Usuario>>(contenido);

            if (usuarios == null || usuarios.Any(u => u == null))
            {
                throw new JsonException(
                    "El archivo no contiene una lista válida de usuarios.");
            }

            return usuarios;
        }



        public void GuardarUsuarios(List<Usuario> usuarios)
        {

            if (DatosRecuperadosDelRespaldo)
            {
                throw new InvalidOperationException(
                    "Los usuarios fueron recuperados desde una copia de respaldo. " +
                    "Por seguridad, no se permite guardar nuevos registros " +
                    "hasta revisar y restaurar el archivo principal.");
            }

            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Convertir los usuarios a formato JSON.
            string contenido = JsonSerializer.Serialize(usuarios, opciones);

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
