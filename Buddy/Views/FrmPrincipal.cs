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
        private readonly RutinaController rutinaController;
        private readonly AsignacionRutinaController asignacionController;

        public FrmPrincipal(
            UsuarioController usuarioController,
            EntrenadorController entrenadorController,
            RutinaController rutinaController,
            AsignacionRutinaController asignacionController)
        {
            InitializeComponent();

            this.usuarioController = usuarioController
                ?? throw new ArgumentNullException(nameof(usuarioController));
            this.entrenadorController = entrenadorController
                ?? throw new ArgumentNullException(nameof(entrenadorController));
            this.rutinaController = rutinaController
                ?? throw new ArgumentNullException(nameof(rutinaController));
            this.asignacionController = asignacionController
                ?? throw new ArgumentNullException(nameof(asignacionController));
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

        private void btnCrearRutina_Click(object sender, EventArgs e)
        {
            using var frmCrear = new FrmCrearRutina(rutinaController, entrenadorController);
            frmCrear.ShowDialog(this);
        }

        private void btnAsignarRutina_Click(object sender, EventArgs e)
        {
            using var frmAsignar = new FrmAsignarRutina(
                asignacionController, usuarioController, entrenadorController, rutinaController);
            frmAsignar.ShowDialog(this);
        }

        private void btnConsultarAsignaciones_Click(object sender, EventArgs e)
        {
            using var frmConsulta = new FrmConsultaAsignaciones(
                asignacionController, usuarioController, entrenadorController, rutinaController);
            frmConsulta.ShowDialog(this);
        }
    }
}
