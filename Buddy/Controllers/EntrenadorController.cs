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

        // Datos personales y de contacto ya validados y normalizados.
        private sealed record DatosPersonales(
            string Nombre,
            string PrimerApellido,
            string? SegundoApellido,
            DateTime FechaNacimiento,
            string CorreoElectronico,
            string NombreUsuario,
            string Telefono);

        // Datos profesionales ya validados.
        private sealed record DatosProfesionales(
            TipoEntrenador Tipo,
            EspecialidadEntrenador Especialidad,
            string? Certificaciones,
            int AniosExperiencia);

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

            DatosPersonales personales = ValidarDatosPersonales(
                nombre, primerApellido, segundoApellido, fechaNacimiento,
                correoElectronico, nombreUsuario, telefono);

            ValidarContrasenaNueva(contrasena, confirmacionContrasena);

            DatosProfesionales profesionales = ValidarDatosProfesionales(
                tipo, especialidad, certificaciones, aniosExperiencia);

            // Evitar identificaciones duplicadas entre entrenadores.
            string identificacionNormalizada = NormalizarIdentificacion(identificacion);

            if (entrenadores.Any(e =>
                NormalizarIdentificacion(e.Identificacion) == identificacionNormalizada))
                throw new ArgumentException("La identificación ya está registrada.");

            ValidarDuplicados(
                idExcluido: null, personales.NombreUsuario, personales.CorreoElectronico);

            // Guardar la contraseña de forma segura.
            (string hash, string sal) = ServicioContrasenas.GenerarHash(contrasena);

            // Crear el entrenador utilizando el modelo.
            Entrenador nuevoEntrenador = new Entrenador(
                siguienteId,
                identificacion,
                personales.Nombre,
                personales.PrimerApellido,
                personales.SegundoApellido,
                personales.FechaNacimiento,
                personales.CorreoElectronico,
                personales.NombreUsuario,
                personales.Telefono,
                hash,
                sal,
                profesionales.Tipo,
                profesionales.Especialidad,
                profesionales.Certificaciones,
                profesionales.AniosExperiencia,
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

        public Entrenador? ObtenerEntrenadorPorId(int id)
        {
            return entrenadores.FirstOrDefault(e => e.Id == id);
        }

        // Actualiza datos personales, de contacto y profesionales.
        // La identificación, la contraseña, el rol, el estado y la fecha
        // de registro se conservan sin cambios.
        public Entrenador ActualizarEntrenador(
            int id,
            string nombre,
            string primerApellido,
            string? segundoApellido,
            DateTime fechaNacimiento,
            string correoElectronico,
            string nombreUsuario,
            string telefono,
            TipoEntrenador? tipo,
            EspecialidadEntrenador? especialidad,
            string? certificaciones,
            int aniosExperiencia)
        {
            // Buscar al entrenador que se desea actualizar.
            Entrenador actual = ObtenerEntrenadorPorId(id)
                ?? throw new ArgumentException("El entrenador no existe.");

            DatosPersonales personales = ValidarDatosPersonales(
                nombre, primerApellido, segundoApellido, fechaNacimiento,
                correoElectronico, nombreUsuario, telefono);

            DatosProfesionales profesionales = ValidarDatosProfesionales(
                tipo, especialidad, certificaciones, aniosExperiencia);

            // Verificar duplicados, excluyendo al entrenador actual.
            ValidarDuplicados(
                idExcluido: id, personales.NombreUsuario, personales.CorreoElectronico);

            // Crear la versión actualizada sin modificar todavía el original.
            Entrenador actualizado = new Entrenador(
                actual.Id,
                actual.Identificacion,
                personales.Nombre,
                personales.PrimerApellido,
                personales.SegundoApellido,
                personales.FechaNacimiento,
                personales.CorreoElectronico,
                personales.NombreUsuario,
                personales.Telefono,
                actual.ContrasenaHash,
                actual.ContrasenaSalt,
                profesionales.Tipo,
                profesionales.Especialidad,
                profesionales.Certificaciones,
                profesionales.AniosExperiencia,
                actual.Rol,
                actual.Estado,
                actual.FechaRegistro);

            ReemplazarYGuardar(actualizado);

            return actualizado;
        }

        public void CambiarContrasena(
            int id,
            string contrasenaActual,
            string contrasenaNueva,
            string confirmacionContrasena)
        {
            Entrenador actual = ObtenerEntrenadorPorId(id)
                ?? throw new ArgumentException("El entrenador no existe.");

            if (string.IsNullOrEmpty(contrasenaActual))
                throw new ArgumentException("Debe ingresar la contraseña actual.");

            if (!ServicioContrasenas.VerificarContrasena(
                    contrasenaActual, actual.ContrasenaHash, actual.ContrasenaSalt))
                throw new ArgumentException("La contraseña actual no es correcta.");

            ValidarContrasenaNueva(contrasenaNueva, confirmacionContrasena);

            if (string.Equals(contrasenaNueva, contrasenaActual, StringComparison.Ordinal))
                throw new ArgumentException(
                    "La contraseña nueva debe ser distinta de la contraseña actual.");

            // Nuevo hash con una sal nueva.
            (string hash, string sal) = ServicioContrasenas.GenerarHash(contrasenaNueva);

            Entrenador actualizado = new Entrenador(
                actual.Id,
                actual.Identificacion,
                actual.Nombre,
                actual.PrimerApellido,
                actual.SegundoApellido,
                actual.FechaNacimiento,
                actual.CorreoElectronico,
                actual.NombreUsuario,
                actual.Telefono,
                hash,
                sal,
                actual.Tipo,
                actual.Especialidad,
                actual.Certificaciones,
                actual.AniosExperiencia,
                actual.Rol,
                actual.Estado,
                actual.FechaRegistro);

            ReemplazarYGuardar(actualizado);
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
        public static string NormalizarIdentificacion(string identificacion)
        {
            return identificacion
                .Replace("-", string.Empty)
                .Trim()
                .ToUpperInvariant();
        }

        private static DatosPersonales ValidarDatosPersonales(
            string nombre,
            string primerApellido,
            string? segundoApellido,
            DateTime fechaNacimiento,
            string correoElectronico,
            string nombreUsuario,
            string telefono)
        {
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

            // Teléfono.
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("Debe ingresar el número de teléfono.");

            string telefonoNormalizado = NormalizarTelefono(telefono)
                ?? throw new ArgumentException(
                    "El teléfono debe tener 8 dígitos, por ejemplo 8888-1234 " +
                    "o +506 8888-1234.");

            return new DatosPersonales(
                nombre.Trim(),
                primerApellido.Trim(),
                string.IsNullOrWhiteSpace(segundoApellido) ? null : segundoApellido.Trim(),
                fechaNacimiento.Date,
                correoElectronico,
                nombreUsuario.Trim(),
                telefonoNormalizado);
        }

        private static DatosProfesionales ValidarDatosProfesionales(
            TipoEntrenador? tipo,
            EspecialidadEntrenador? especialidad,
            string? certificaciones,
            int aniosExperiencia)
        {
            if (tipo == null || !Enum.IsDefined(tipo.Value))
                throw new ArgumentException("Debe seleccionar el tipo de entrenador.");

            if (especialidad == null || !Enum.IsDefined(especialidad.Value))
                throw new ArgumentException("Debe seleccionar una especialidad.");

            if (aniosExperiencia < 0)
                throw new ArgumentException(
                    "Los años de experiencia deben ser un número entero mayor o igual a cero.");

            return new DatosProfesionales(
                tipo.Value,
                especialidad.Value,
                string.IsNullOrWhiteSpace(certificaciones) ? null : certificaciones.Trim(),
                aniosExperiencia);
        }

        private static void ValidarContrasenaNueva(string contrasena, string confirmacion)
        {
            if (string.IsNullOrEmpty(contrasena) ||
                contrasena.Length < LongitudMinimaContrasena)
                throw new ArgumentException(
                    $"La contraseña debe tener al menos {LongitudMinimaContrasena} caracteres.");

            if (!string.Equals(contrasena, confirmacion, StringComparison.Ordinal))
                throw new ArgumentException(
                    "La confirmación no coincide con la contraseña.");
        }

        // Nombre de usuario y correo únicos entre entrenadores y usuarios.
        private void ValidarDuplicados(int? idExcluido, string nombreUsuario, string correoElectronico)
        {
            if (entrenadores.Any(e =>
                    e.Id != idExcluido &&
                    e.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase)) ||
                cuentasUsuarios.ExisteNombreUsuario(nombreUsuario))
                throw new ArgumentException("El nombre de usuario ya está registrado.");

            if (entrenadores.Any(e =>
                    e.Id != idExcluido &&
                    e.CorreoElectronico.Equals(correoElectronico, StringComparison.OrdinalIgnoreCase)) ||
                cuentasUsuarios.ExisteCorreo(correoElectronico))
                throw new ArgumentException("El correo electrónico ya está registrado.");
        }

        // Guarda primero en JSON y solo después actualiza la lista en memoria.
        private void ReemplazarYGuardar(Entrenador actualizado)
        {
            List<Entrenador> entrenadoresActualizados = entrenadores
                .Select(e => e.Id == actualizado.Id ? actualizado : e)
                .ToList();

            repositorio.GuardarEntrenadores(entrenadoresActualizados);

            int indice = entrenadores.FindIndex(e => e.Id == actualizado.Id);
            entrenadores[indice] = actualizado;
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
