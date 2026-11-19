namespace Buddy.Controllers
{
    // Permite comprobar nombres de usuario y correos entre
    // distintos tipos de cuenta (usuarios y entrenadores).
    public interface ICuentasRegistradas
    {
        bool ExisteNombreUsuario(string nombreUsuario);

        bool ExisteCorreo(string correoElectronico);
    }
}
