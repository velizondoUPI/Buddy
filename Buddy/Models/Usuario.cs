
using System;
using System.Text.Json.Serialization;

namespace Buddy.Models
{
    public class Usuario
    {
        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public string NombreUsuario { get; private set; }

        public string? CorreoElectronico { get; private set; }

        public DateTime FechaNacimiento { get; private set; }

        public decimal PesoKg { get; private set; }

        public decimal AlturaMetros { get; private set; }

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

        public decimal IMC
        {
            get
            {
                return Math.Round(
                    PesoKg / (AlturaMetros * AlturaMetros),
                    2
                );
            }
        }


        [JsonConstructor]
        public Usuario(
            int id,
            string nombre,
            string nombreUsuario,
            DateTime fechaNacimiento,
            decimal pesoKg,
            decimal alturaMetros,
            string? correoElectronico = null)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException(
                    "El nombre es obligatorio.", nameof(nombre));

            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException(
                    "El nombre de usuario es obligatorio.",
                    nameof(nombreUsuario));

            if (correoElectronico != null &&
                string.IsNullOrWhiteSpace(correoElectronico))
                throw new ArgumentException(
                    "El correo electrónico no puede estar vacío.",
                    nameof(correoElectronico));

            if (fechaNacimiento.Date >= DateTime.Today)
                throw new ArgumentException(
                    "La fecha de nacimiento debe ser anterior a hoy.",
                    nameof(fechaNacimiento));

            if (pesoKg <= 0)
                throw new ArgumentOutOfRangeException(nameof(pesoKg));

            if (alturaMetros <= 0)
                throw new ArgumentOutOfRangeException(nameof(alturaMetros));

            Id = id;
            Nombre = nombre.Trim();
            NombreUsuario = nombreUsuario.Trim();
            CorreoElectronico = correoElectronico?.Trim();
            FechaNacimiento = fechaNacimiento;
            PesoKg = pesoKg;
            AlturaMetros = alturaMetros;
        }
    }
}
