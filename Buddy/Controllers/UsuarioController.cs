
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            decimal alturaMetros,
            string correoElectronico)
        {
            // Validar que el correo sea obligatorio.
            if (string.IsNullOrWhiteSpace(correoElectronico))
            {
                throw new ArgumentException(
                    "Debe ingresar un correo electrónico.");
            }

            correoElectronico = correoElectronico.Trim();

            // Validar el formato básico del correo.
            try
            {
                var direccion = new MailAddress(correoElectronico);

                if (!direccion.Address.Equals(
                    correoElectronico,
                    StringComparison.OrdinalIgnoreCase))
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                throw new ArgumentException(
                    "Debe ingresar un correo electrónico válido.");
            }

            // Evitar nombres de usuario duplicados.
            if (usuarios.Any(u =>
                u.NombreUsuario.Equals(
                    nombreUsuario?.Trim(),
                    StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException(
                    "El nombre de usuario ya está registrado.");
            }

            // Evitar correos electrónicos duplicados.
            if (usuarios.Any(u =>
                !string.IsNullOrWhiteSpace(u.CorreoElectronico) &&
                u.CorreoElectronico.Equals(
                    correoElectronico,
                    StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException(
                    "El correo electrónico ya está registrado.");
            }

            // Crear el usuario utilizando el modelo.
            Usuario nuevoUsuario = new Usuario(
                siguienteId,
                nombre,
                nombreUsuario,
                fechaNacimiento,
                pesoKg,
                alturaMetros,
                correoElectronico
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
