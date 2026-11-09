
using System;
using System.Collections.Generic;
using System.Linq;
using Buddy.Models;
using Buddy.Data;

namespace Buddy.Controllers
{
    public class UsuarioController
    {
        private readonly List<Usuario> usuarios;
        private readonly UsuarioRepository repositorio;
        private int siguienteId;

        public UsuarioController()
        {
            repositorio = new UsuarioRepository();

            // Recuperar los usuarios guardados anteriormente.
            usuarios = repositorio.CargarUsuarios();

            // Continuar la numeración desde el último ID.
            siguienteId = usuarios.Count > 0
                ? usuarios.Max(u => u.Id) + 1
                : 1;
        }

        public Usuario RegistrarUsuario(
            string nombre,
            string nombreUsuario,
            DateTime fechaNacimiento,
            decimal pesoKg,
            decimal alturaMetros)
        {
            // Evitar nombres de usuario duplicados.
            if (usuarios.Any(u =>
                u.NombreUsuario.Equals(
                    nombreUsuario?.Trim(),
                    StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException(
                    "El nombre de usuario ya está registrado.");
            }

            // Crear el usuario utilizando el modelo.
            Usuario nuevoUsuario = new Usuario(
                siguienteId,
                nombre,
                nombreUsuario,
                fechaNacimiento,
                pesoKg,
                alturaMetros
            );

            // Agregar el usuario a la lista.
            usuarios.Add(nuevoUsuario);

            try
            {
                // Guardar la lista actualizada en JSON.
                repositorio.GuardarUsuarios(usuarios);
            }
            catch
            {
                // Revertir el registro si falla el guardado.
                usuarios.Remove(nuevoUsuario);
                throw;
            }

            siguienteId++;

            return nuevoUsuario;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return new List<Usuario>(usuarios);
        }
    }
}
