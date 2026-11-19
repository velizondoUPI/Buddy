using System;
using System.Security.Cryptography;

namespace Buddy.Controllers
{
    // Genera y verifica hashes de contraseñas con PBKDF2-SHA256.
    // La contraseña en texto plano nunca se almacena.
    public static class ServicioContrasenas
    {
        private const int TamanoSalBytes = 16;
        private const int TamanoHashBytes = 32;
        private const int Iteraciones = 600_000;

        public static (string Hash, string Sal) GenerarHash(string contrasena)
        {
            ArgumentNullException.ThrowIfNull(contrasena);

            // Una sal aleatoria distinta para cada cuenta.
            byte[] sal = RandomNumberGenerator.GetBytes(TamanoSalBytes);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                contrasena,
                sal,
                Iteraciones,
                HashAlgorithmName.SHA256,
                TamanoHashBytes);

            return (Convert.ToBase64String(hash), Convert.ToBase64String(sal));
        }

        public static bool VerificarContrasena(
            string contrasena,
            string hashGuardado,
            string salGuardada)
        {
            if (contrasena == null ||
                string.IsNullOrWhiteSpace(hashGuardado) ||
                string.IsNullOrWhiteSpace(salGuardada))
                return false;

            byte[] hashEsperado;
            byte[] sal;

            try
            {
                hashEsperado = Convert.FromBase64String(hashGuardado);
                sal = Convert.FromBase64String(salGuardada);
            }
            catch (FormatException)
            {
                return false;
            }

            byte[] hashCalculado = Rfc2898DeriveBytes.Pbkdf2(
                contrasena,
                sal,
                Iteraciones,
                HashAlgorithmName.SHA256,
                hashEsperado.Length);

            // Comparación en tiempo constante.
            return CryptographicOperations.FixedTimeEquals(
                hashCalculado, hashEsperado);
        }
    }
}
