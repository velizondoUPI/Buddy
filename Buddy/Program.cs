using System.IO;
using Buddy.Controllers;
using Buddy.Views;

namespace Buddy
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            UsuarioController usuarioController;
            EntrenadorController entrenadorController;
            RutinaController rutinaController;
            AsignacionRutinaController asignacionController;

            try
            {
                // Controladores únicos compartidos por todos los formularios.
                usuarioController = new UsuarioController();
                entrenadorController = new EntrenadorController(usuarioController);

                // Validar duplicados de usuario y correo en ambos sentidos.
                usuarioController.ConfigurarCuentasExternas(entrenadorController);

                // Rutinas de ejercicio, validadas contra los entrenadores registrados.
                rutinaController = new RutinaController(entrenadorController);

                // Asignaciones de rutinas a usuarios.
                asignacionController = new AsignacionRutinaController(
                    usuarioController, entrenadorController, rutinaController);
            }
            catch (Exception ex) when (
                ex is InvalidOperationException ||
                ex is IOException ||
                ex is UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos de Buddy.\n\n" + ex.Message,
                    "Buddy - Error al iniciar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmPrincipal(
                usuarioController, entrenadorController, rutinaController, asignacionController));
        }
    }
}
