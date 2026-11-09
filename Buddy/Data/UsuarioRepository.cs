
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Buddy.Models;

namespace Buddy.Data
{
    public class UsuarioRepository
    {
        private readonly string rutaArchivo;

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
            if (!File.Exists(rutaArchivo))
            {
                return new List<Usuario>();
            }

            string contenido = File.ReadAllText(rutaArchivo);

            if (string.IsNullOrWhiteSpace(contenido))
            {
                return new List<Usuario>();
            }

            return JsonSerializer.Deserialize<List<Usuario>>(contenido)
                ?? new List<Usuario>();
        }

        public void GuardarUsuarios(List<Usuario> usuarios)
        {
            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string contenido = JsonSerializer.Serialize(usuarios, opciones);

            File.WriteAllText(rutaArchivo, contenido);
        }
    }
}
