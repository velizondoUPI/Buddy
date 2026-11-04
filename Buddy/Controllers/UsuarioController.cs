using System;
using System.Collections.Generic;
using System.Linq;
using Buddy.Models;

namespace Buddy.Controllers
{
    public class UsuarioController
    {
        private readonly List<Usuario> usuarios = new List<Usuario>();
        private int siguienteId = 1;

        public Usuario RegistrarUsuario(
            string nombre,
            string nombreUsuario,
            DateTime fechaNacimiento,
            decimal pesoKg,
            decimal alturaMetros)
        {
            
            if (usuarios.Any(u =>
                u.NombreUsuario.Equals(
                    nombreUsuario,
                    StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException(
                    "El nombre de usuario ya está registrado.");
            }

            
            Usuario nuevoUsuario = new Usuario(
                siguienteId,
                nombre,
                nombreUsuario,
                fechaNacimiento,
                pesoKg,
                alturaMetros
            );

            
            usuarios.Add(nuevoUsuario);

            
            siguienteId++;

            return nuevoUsuario;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return new List<Usuario>(usuarios);
        }
    }
}