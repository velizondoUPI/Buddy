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

            try
            {
                // Un único controlador compartido por todos los formularios.
                usuarioController = new UsuarioController();
            }
            catch (Exception ex) when (
                ex is InvalidOperationException ||
                ex is IOException ||
                ex is UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "No se pudieron cargar los usuarios de Buddy.\n\n" + ex.Message,
                    "Buddy - Error al iniciar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmConsultaUsuarios(usuarioController));
        }
    }
}
