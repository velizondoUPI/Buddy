using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Buddy.Data;
using Buddy.Models;

namespace Buddy.Controllers
{
    public class EntrenadorController : ICuentasRegistradas
    {
        public const int LongitudMinimaContrasena = 8;
        public const int LongitudMaximaIdentificacion = 20;

        // Letras, números y guiones (cédula, DIMEX o pasaporte).
        private static readonly Regex formatoIdentificacion =
            new(@"^[A-Za-z0-9-]+$");

        // 8 dígitos con guion opcional y prefijo +506 opcional.
        // Ejemplos: 88881234, 8888-1234, +506 88881234, +506 8888-1234.
        private static readonly Regex formatoTelefono =
            new(@"^(\+506 ?)?([0-9]{4})-?([0-9]{4})$");

        private readonly List<Entrenador> entrenadores;
        private readonly EntrenadorRepository repositorio;

        // Cuentas de usuarios regulares, para evitar duplicados entre ambos.
        private readonly ICuentasRegistradas cuentasUsuarios;

        private int siguienteId;

        public EntrenadorController(ICuentasRegistradas cuentasUsuarios)
            : this(new EntrenadorRepository(), cuentasUsuarios)
        {
        }

        public EntrenadorController(
            EntrenadorRepository repositorio,
            ICuentasRegistradas cuentasUsuarios)
        {
            this.repositorio = repositorio
                ?? throw new ArgumentNullException(nameof(repositorio));
            this.cuentasUsuarios = cuentasUsuarios
                ?? throw new ArgumentNullException(nameof(cuentasUsuarios));

            // Recuperar los entrenadores guardados anteriormente.
            entrenadores = repositorio.CargarEntrenadores();

            // Continuar la numeración desde el último ID.
            siguienteId = entrenadores.Count > 0
                ? entrenadores.Max(e => e.Id) + 1
                : 1;
        }

        public Entrenador RegistrarEntrenador(
            string identificacion,
            string nombre,
            string primerApellido,
            string? segundoApellido,
            DateTime fechaNacimiento,
            string correoElectronico,
            string nombreUsuario,
            string telefono,
            string contrasena,
            string confirmacionContrasena,
            TipoEntrenador? tipo,
            EspecialidadEntrenador? especialidad,
            string? certificaciones,
            int aniosExperiencia)
        {
            // Identificación.
            if (string.IsNullOrWhiteSpace(identificacion))
                throw new ArgumentException("Debe ingresar la identificación.");

            identificacion = identificacion.Trim();

            if (identificacion.Length > LongitudMaximaIdentificacion ||
                !formatoIdentificacion.IsMatch(identificacion))
                throw new ArgumentException(
                    "La identificación solo puede contener letras, números y " +
                    $"guiones, con un máximo de {LongitudMaximaIdentificacion} caracteres.");

            // Datos personales.
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Debe ingresar el nombre.");

            if (string.IsNullOrWhiteSpace(primerApellido))
                throw new ArgumentException("Debe ingresar el primer apellido.");

            if (fechaNacimiento.Date >= DateTime.Today)
                throw new ArgumentException(
                    "La fecha de nacimiento debe ser anterior a hoy.");

            // Correo electrónico.
            if (string.IsNullOrWhiteSpace(correoElectronico))
                throw new ArgumentException("Debe ingresar un correo electrónico.");

            correoElectronico = correoElectronico.Trim();

            if (!EsCorreoValido(correoElectronico))
                throw new ArgumentException(
                    "Debe ingresar un correo electrónico válido.");

            // Nombre de usuario.
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("Debe ingresar un nombre de usuario.");

            nombreUsuario = nombreUsuario.Trim();

            // Teléfono.
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("Debe ingresar el número de teléfono.");

            string telefonoNormalizado = NormalizarTelefono(telefono)
                ?? throw new ArgumentException(
                    "El teléfono debe tener 8 dígitos, por ejemplo 8888-1234 " +
                    "o +506 8888-1234.");

            // Contraseña.
            if (string.IsNullOrEmpty(contrasena) ||
                contrasena.Length < LongitudMinimaContrasena)
                throw new ArgumentException(
                    $"La contraseña debe tener al menos {LongitudMinimaContrasena} caracteres.");

            if (!string.Equals(contrasena, confirmacionContrasena, StringComparison.Ordinal))
                throw new ArgumentException(
                    "La confirmación no coincide con la contraseña.");

            // Datos profesionales.
            if (tipo == null || !Enum.IsDefined(tipo.Value))
                throw new ArgumentException("Debe seleccionar el tipo de entrenador.");

            if (especialidad == null || !Enum.IsDefined(especialidad.Value))
                throw new ArgumentException("Debe seleccionar una especialidad.");

            if (aniosExperiencia < 0)
                throw new ArgumentException(
                    "Los años de experiencia deben ser un número entero mayor o igual a cero.");

            // Evitar identificaciones duplicadas entre entrenadores.
            string identificacionNormalizada = NormalizarIdentificacion(identificacion);

            if (entrenadores.Any(e =>
                NormalizarIdentificacion(e.Identificacion) == identificacionNormalizada))
                throw new ArgumentException("La identificación ya está registrada.");

            // Evitar nombres de usuario duplicados entre entrenadores y usuarios.
            if (ExisteNombreUsuario(nombreUsuario) ||
                cuentasUsuarios.ExisteNombreUsuario(nombreUsuario))
                throw new ArgumentException("El nombre de usuario ya está registrado.");

            // Evitar correos duplicados entre entrenadores y usuarios.
            if (ExisteCorreo(correoElectronico) ||
                cuentasUsuarios.ExisteCorreo(correoElectronico))
                throw new ArgumentException("El correo electrónico ya está registrado.");

            // Guardar la contraseña de forma segura.
            (string hash, string sal) = ServicioContrasenas.GenerarHash(contrasena);

            // Crear el entrenador utilizando el modelo.
            Entrenador nuevoEntrenador = new Entrenador(
                siguienteId,
                identificacion,
                nombre,
                primerApellido,
                segundoApellido,
                fechaNacimiento.Date,
                correoElectronico,
                nombreUsuario,
                telefonoNormalizado,
                hash,
                sal,
                tipo.Value,
                especialidad.Value,
                certificaciones,
                aniosExperiencia,
                Entrenador.RolEntrenador,
                EstadoCuenta.Activo,
                DateTime.Now);

            entrenadores.Add(nuevoEntrenador);

            try
            {
                // Guardar la lista actualizada en JSON.
                repositorio.GuardarEntrenadores(entrenadores);
            }
            catch
            {
                // Revertir el registro si falla el guardado.
                entrenadores.Remove(nuevoEntrenador);
                throw;
            }

            siguienteId++;

            return nuevoEntrenador;
        }

        public List<Entrenador> ObtenerEntrenadores()
        {
            return new List<Entrenador>(entrenadores);
        }

        public bool ExisteNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                return false;

            string buscado = nombreUsuario.Trim();

            return entrenadores.Any(e =>
                e.NombreUsuario.Equals(buscado, StringComparison.OrdinalIgnoreCase));
        }

        public bool ExisteCorreo(string correoElectronico)
        {
            if (string.IsNullOrWhiteSpace(correoElectronico))
                return false;

            string buscado = correoElectronico.Trim();

            return entrenadores.Any(e =>
                e.CorreoElectronico.Equals(buscado, StringComparison.OrdinalIgnoreCase));
        }

        // Devuelve los 8 dígitos del teléfono o null si el formato es inválido.
        public static string? NormalizarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return null;

            Match coincidencia = formatoTelefono.Match(telefono.Trim());

            return coincidencia.Success
                ? coincidencia.Groups[2].Value + coincidencia.Groups[3].Value
                : null;
        }

        // Compara identificaciones sin tener en cuenta guiones ni mayúsculas.
        private static string NormalizarIdentificacion(string identificacion)
        {
            return identificacion
                .Replace("-", string.Empty)
                .Trim()
                .ToUpperInvariant();
        }

        // Misma validación de correo que se usa en UsuarioController.
        private static bool EsCorreoValido(string correoElectronico)
        {
            try
            {
                var direccion = new MailAddress(correoElectronico);

                return direccion.Address.Equals(
                    correoElectronico,
                    StringComparison.OrdinalIgnoreCase);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
