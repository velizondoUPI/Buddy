using System;

namespace Buddy.Models
{
    public class Usuario
    {
        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public string NombreUsuario { get; private set; }

        public DateTime FechaNacimiento { get; private set; }

        public decimal PesoKg { get; private set; }

        public decimal AlturaMetros { get; private set; }

        public Usuario(
            int id,
            string nombre,
            string nombreUsuario,
            DateTime fechaNacimiento,
            decimal pesoKg,
            decimal alturaMetros)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));

            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.", nameof(nombreUsuario));

            if (fechaNacimiento.Date > DateTime.Today)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura.", nameof(fechaNacimiento));

            if (pesoKg <= 0)
                throw new ArgumentOutOfRangeException(nameof(pesoKg));

            if (alturaMetros <= 0)
                throw new ArgumentOutOfRangeException(nameof(alturaMetros));

            Id = id;
            Nombre = nombre.Trim();
            NombreUsuario = nombreUsuario.Trim();
            FechaNacimiento = fechaNacimiento;
            PesoKg = pesoKg;
            AlturaMetros = alturaMetros;
        }
    }
}
