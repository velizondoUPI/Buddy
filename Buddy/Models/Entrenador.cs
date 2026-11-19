using System;
using System.Text.Json.Serialization;

namespace Buddy.Models
{
    public class Entrenador
    {
        public const string RolEntrenador = "Entrenador";

        public int Id { get; private set; }

        public string Identificacion { get; private set; }

        public string Nombre { get; private set; }

        public string PrimerApellido { get; private set; }

        public string? SegundoApellido { get; private set; }

        public DateTime FechaNacimiento { get; private set; }

        public string CorreoElectronico { get; private set; }

        public string NombreUsuario { get; private set; }

        public string Telefono { get; private set; }

        // La contraseña nunca se almacena; solo su hash y la sal utilizada.
        public string ContrasenaHash { get; private set; }

        public string ContrasenaSalt { get; private set; }

        public TipoEntrenador Tipo { get; private set; }

        public EspecialidadEntrenador Especialidad { get; private set; }

        public string? Certificaciones { get; private set; }

        public int AniosExperiencia { get; private set; }

        public string Rol { get; private set; }

        public EstadoCuenta Estado { get; private set; }

        public DateTime FechaRegistro { get; private set; }

        [JsonIgnore]
        public int Edad
        {
            get
            {
                int edad = DateTime.Today.Year - FechaNacimiento.Year;

                if (FechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }

                return edad;
            }
        }

        [JsonIgnore]
        public string NombreCompleto =>
            string.IsNullOrWhiteSpace(SegundoApellido)
                ? $"{Nombre} {PrimerApellido}"
                : $"{Nombre} {PrimerApellido} {SegundoApellido}";

        [JsonConstructor]
        public Entrenador(
            int id,
            string identificacion,
            string nombre,
            string primerApellido,
            string? segundoApellido,
            DateTime fechaNacimiento,
            string correoElectronico,
            string nombreUsuario,
            string telefono,
            string contrasenaHash,
            string contrasenaSalt,
            TipoEntrenador tipo,
            EspecialidadEntrenador especialidad,
            string? certificaciones,
            int aniosExperiencia,
            string rol,
            EstadoCuenta estado,
            DateTime fechaRegistro)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (string.IsNullOrWhiteSpace(identificacion))
                throw new ArgumentException(
                    "La identificación es obligatoria.", nameof(identificacion));

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException(
                    "El nombre es obligatorio.", nameof(nombre));

            if (string.IsNullOrWhiteSpace(primerApellido))
                throw new ArgumentException(
                    "El primer apellido es obligatorio.", nameof(primerApellido));

            if (fechaNacimiento.Date >= DateTime.Today)
                throw new ArgumentException(
                    "La fecha de nacimiento debe ser anterior a hoy.",
                    nameof(fechaNacimiento));

            if (string.IsNullOrWhiteSpace(correoElectronico))
                throw new ArgumentException(
                    "El correo electrónico es obligatorio.",
                    nameof(correoElectronico));

            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException(
                    "El nombre de usuario es obligatorio.", nameof(nombreUsuario));

            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException(
                    "El teléfono es obligatorio.", nameof(telefono));

            if (string.IsNullOrWhiteSpace(contrasenaHash) ||
                string.IsNullOrWhiteSpace(contrasenaSalt))
                throw new ArgumentException(
                    "La contraseña del entrenador no es válida.",
                    nameof(contrasenaHash));

            if (!Enum.IsDefined(tipo))
                throw new ArgumentException(
                    "El tipo de entrenador no es válido.", nameof(tipo));

            if (!Enum.IsDefined(especialidad))
                throw new ArgumentException(
                    "La especialidad no es válida.", nameof(especialidad));

            if (aniosExperiencia < 0)
                throw new ArgumentException(
                    "Los años de experiencia no pueden ser negativos.",
                    nameof(aniosExperiencia));

            if (string.IsNullOrWhiteSpace(rol))
                throw new ArgumentException(
                    "El rol es obligatorio.", nameof(rol));

            if (!Enum.IsDefined(estado))
                throw new ArgumentException(
                    "El estado de la cuenta no es válido.", nameof(estado));

            if (fechaRegistro == default)
                throw new ArgumentException(
                    "La fecha de registro es obligatoria.", nameof(fechaRegistro));

            Id = id;
            Identificacion = identificacion.Trim();
            Nombre = nombre.Trim();
            PrimerApellido = primerApellido.Trim();
            SegundoApellido = string.IsNullOrWhiteSpace(segundoApellido)
                ? null
                : segundoApellido.Trim();
            FechaNacimiento = fechaNacimiento.Date;
            CorreoElectronico = correoElectronico.Trim();
            NombreUsuario = nombreUsuario.Trim();
            Telefono = telefono.Trim();
            ContrasenaHash = contrasenaHash;
            ContrasenaSalt = contrasenaSalt;
            Tipo = tipo;
            Especialidad = especialidad;
            Certificaciones = string.IsNullOrWhiteSpace(certificaciones)
                ? null
                : certificaciones.Trim();
            AniosExperiencia = aniosExperiencia;
            Rol = rol.Trim();
            Estado = estado;
            FechaRegistro = fechaRegistro;
        }
    }
}
