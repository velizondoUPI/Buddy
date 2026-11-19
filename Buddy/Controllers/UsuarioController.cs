
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Buddy.Models;
using Buddy.Data;

namespace Buddy.Controllers
{
    public class UsuarioController : ICuentasRegistradas
    {
        private readonly List<Usuario> usuarios;
        private readonly UsuarioRepository repositorio;
        private int siguienteId;

        // Cuentas de otro tipo (entrenadores) que también deben ser únicas.
        private ICuentasRegistradas? cuentasExternas;

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

        // Conecta las cuentas de entrenadores para evitar duplicados
        // de nombre de usuario y correo entre ambos tipos de cuenta.
        public void ConfigurarCuentasExternas(ICuentasRegistradas cuentas)
        {
            cuentasExternas = cuentas
                ?? throw new ArgumentNullException(nameof(cuentas));
        }

        public bool ExisteNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                return false;

            string buscado = nombreUsuario.Trim();

            return usuarios.Any(u =>
                u.NombreUsuario.Equals(buscado, StringComparison.OrdinalIgnoreCase));
        }

        public bool ExisteCorreo(string correoElectronico)
        {
            if (string.IsNullOrWhiteSpace(correoElectronico))
                return false;

            string buscado = correoElectronico.Trim();

            return usuarios.Any(u =>
                !string.IsNullOrWhiteSpace(u.CorreoElectronico) &&
                u.CorreoElectronico.Equals(buscado, StringComparison.OrdinalIgnoreCase));
        }

        // Comprueba si el nombre de usuario o el correo pertenecen a un entrenador.
        private void ValidarCuentasExternas(string? nombreUsuario, string correoElectronico)
        {
            if (cuentasExternas == null)
                return;

            if (cuentasExternas.ExisteNombreUsuario(nombreUsuario ?? string.Empty))
                throw new ArgumentException(
                    "El nombre de usuario ya está registrado.");

            if (cuentasExternas.ExisteCorreo(correoElectronico))
                throw new ArgumentException(
                    "El correo electrónico ya está registrado.");
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

            // Evitar duplicados con las cuentas de entrenadores.
            ValidarCuentasExternas(nombreUsuario, correoElectronico);

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

        public void ActualizarUsuario(
            int id,
            string nombre,
            string nombreUsuario,
            DateTime fechaNacimiento,
            decimal pesoKg,
            decimal alturaMetros,
            string correoElectronico)
        {
            // Buscar al usuario que se desea actualizar.
            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id)
                ?? throw new ArgumentException("El usuario no existe.");

            // Validar el correo electrónico.
            if (string.IsNullOrWhiteSpace(correoElectronico))
                throw new ArgumentException("El correo es obligatorio.");

            correoElectronico = correoElectronico.Trim();

            try
            {
                var direccion = new MailAddress(correoElectronico);

                if (!direccion.Address.Equals(
                    correoElectronico,
                    StringComparison.OrdinalIgnoreCase))
                    throw new FormatException();
            }
            catch (FormatException)
            {
                throw new ArgumentException("El correo electrónico no es válido.");
            }

            // Verificar duplicados, excluyendo al usuario actual.
            if (usuarios.Any(u =>
                u.Id != id &&
                u.NombreUsuario.Equals(
                    nombreUsuario?.Trim(),
                    StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException(
                    "El nombre de usuario ya está registrado.");

            if (usuarios.Any(u =>
                u.Id != id &&
                !string.IsNullOrWhiteSpace(u.CorreoElectronico) &&
                u.CorreoElectronico.Equals(
                    correoElectronico,
                    StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException(
                    "El correo electrónico ya está registrado.");

            // Evitar duplicados con las cuentas de entrenadores.
            ValidarCuentasExternas(nombreUsuario, correoElectronico);

            // Crear la versión actualizada sin modificar todavía el original.
            Usuario actualizado = new Usuario(
                id,
                nombre,
                nombreUsuario,
                fechaNacimiento,
                pesoKg,
                alturaMetros,
                correoElectronico);

            // Preparar una lista nueva para guardar los cambios.
            List<Usuario> usuariosActualizados = usuarios
                .Select(u => u.Id == id ? actualizado : u)
                .ToList();

            // Guardar primero en JSON.
            repositorio.GuardarUsuarios(usuariosActualizados);

            // Actualizar la lista en memoria solo si se guardó correctamente.
            int indice = usuarios.FindIndex(u => u.Id == id);
            usuarios[indice] = actualizado;
        }

    }
}
