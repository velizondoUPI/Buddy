using System;
using System.Windows.Forms;
using Buddy.Controllers;

namespace Buddy.Views
{
    public partial class FrmPrincipal : Form
    {
        // Controladores compartidos por todos los formularios.
        private readonly UsuarioController usuarioController;
        private readonly EntrenadorController entrenadorController;

        public FrmPrincipal(
            UsuarioController usuarioController,
            EntrenadorController entrenadorController)
        {
            InitializeComponent();

            this.usuarioController = usuarioController
                ?? throw new ArgumentNullException(nameof(usuarioController));
            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));
        }

        private void btnConsultarUsuarios_Click(object sender, EventArgs e)
        {
            using var frmConsulta = new FrmConsultaUsuarios(usuarioController);
            frmConsulta.ShowDialog(this);
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            using var frmRegistro = new FrmRegistroUsuario(usuarioController);
            frmRegistro.ShowDialog(this);
        }

        private void btnConsultarEntrenadores_Click(object sender, EventArgs e)
        {
            using var frmConsulta = new FrmConsultaEntrenadores(entrenadorController);
            frmConsulta.ShowDialog(this);
        }

        private void btnRegistrarEntrenador_Click(object sender, EventArgs e)
        {
            using var frmRegistro = new FrmRegistroEntrenador(entrenadorController);
            frmRegistro.ShowDialog(this);
        }
    }
}
