using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Buddy.Controllers;
using Buddy.Models;

namespace Buddy.Views
{
    public partial class FrmConsultaUsuarios : Form
    {
        private readonly UsuarioController usuarioController;

        public FrmConsultaUsuarios(UsuarioController usuarioController)
        {
            InitializeComponent();

            // Usar el controlador compartido para mantener los datos coherentes.
            this.usuarioController = usuarioController
                ?? throw new ArgumentNullException(nameof(usuarioController));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmConsultaUsuarios_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();
            CargarUsuarios();
        }

        private void ConfigurarColumnas()
        {
            // Configurar las columnas de la tabla.
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add("Id", "ID");
            dgvUsuarios.Columns.Add("Nombre", "Nombre");
            dgvUsuarios.Columns.Add("NombreUsuario", "Usuario");
            dgvUsuarios.Columns.Add("CorreoElectronico", "Correo electrónico");
            dgvUsuarios.Columns.Add("Edad", "Edad");
            dgvUsuarios.Columns.Add("PesoKg", "Peso (kg)");
            dgvUsuarios.Columns.Add("AlturaMetros", "Altura (m)");
            dgvUsuarios.Columns.Add("IMC", "IMC");
            // Distribuir el espacio según el contenido de cada columna.
            dgvUsuarios.Columns["Id"].FillWeight = 35;
            dgvUsuarios.Columns["Nombre"].FillWeight = 160;
            dgvUsuarios.Columns["NombreUsuario"].FillWeight = 120;
            dgvUsuarios.Columns["CorreoElectronico"].FillWeight = 200;
            dgvUsuarios.Columns["Edad"].FillWeight = 45;
            dgvUsuarios.Columns["PesoKg"].FillWeight = 65;
            dgvUsuarios.Columns["AlturaMetros"].FillWeight = 65;
            dgvUsuarios.Columns["IMC"].FillWeight = 55;
        }

        private void CargarUsuarios(int? idSeleccionar = null)
        {
            // Obtener los usuarios registrados.
            var usuarios = usuarioController.ObtenerUsuarios();

            dgvUsuarios.Rows.Clear();

            // Mostrar cada usuario en la tabla.
            foreach (var usuario in usuarios)
            {
                dgvUsuarios.Rows.Add(
                    usuario.Id,
                    usuario.Nombre,
                    usuario.NombreUsuario,
                    usuario.CorreoElectronico,
                    usuario.Edad,
                    usuario.PesoKg,
                    usuario.AlturaMetros,
                    usuario.IMC
                );
            }

            // Mantener la búsqueda que el usuario tenía escrita.
            AplicarFiltro();

            if (idSeleccionar.HasValue)
                SeleccionarUsuario(idSeleccionar.Value);
        }

        private void SeleccionarUsuario(int id)
        {
            dgvUsuarios.ClearSelection();

            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                if (fila.Visible && fila.Cells["Id"].Value is int idFila && idFila == id)
                {
                    dgvUsuarios.CurrentCell = fila.Cells["Nombre"];
                    fila.Selected = true;
                    return;
                }
            }
        }

        private int? ObtenerIdSeleccionado()
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
                return null;

            return dgvUsuarios.SelectedRows[0].Cells["Id"].Value as int?;
        }

        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            int? idSeleccionado = ObtenerIdSeleccionado();

            using var frmActualizar = new FrmActualizarUsuario(
                usuarioController,
                idSeleccionado);

            if (frmActualizar.ShowDialog(this) == DialogResult.OK)
            {
                // Mostrar los datos actualizados desde el controlador compartido.
                CargarUsuarios(frmActualizar.IdUsuarioActualizado ?? idSeleccionado);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            // Obtener el texto ingresado en el buscador.
            string busqueda = txtBuscarUsuario.Text.Trim();

            // Recorrer las filas de la tabla.
            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                string nombreUsuario = fila.Cells["NombreUsuario"].Value?.ToString() ?? "";

                // Comprobar si coincide el nombre o nombre de usuario.
                bool coincide =
                    nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                    nombreUsuario.Contains(busqueda, StringComparison.OrdinalIgnoreCase);

                // Mostrar únicamente las filas coincidentes.
                fila.Visible = coincide;
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar que exista una fila seleccionada.
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                lblDetalleNombre.Text = "—";
                lblDetalleUsuario.Text = "—";
                lblDetalleCorreo.Text = "—";
                lblDetalleEdad.Text = "—";
                lblDetallePeso.Text = "—";
                lblDetalleAltura.Text = "—";
                lblDetalleIMC.Text = "—";
                return;
            }

            // Obtener la fila seleccionada.
            DataGridViewRow fila = dgvUsuarios.SelectedRows[0];

            // Mostrar la información del usuario.
            lblDetalleNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "—";
            lblDetalleUsuario.Text = fila.Cells["NombreUsuario"].Value?.ToString() ?? "—";
            lblDetalleCorreo.Text = fila.Cells["CorreoElectronico"].Value?.ToString() ?? "—";
            lblDetalleEdad.Text = fila.Cells["Edad"].Value?.ToString() ?? "—";
            lblDetallePeso.Text = $"{fila.Cells["PesoKg"].Value} kg";
            lblDetalleAltura.Text = $"{fila.Cells["AlturaMetros"].Value} m";
            lblDetalleIMC.Text = fila.Cells["IMC"].Value?.ToString() ?? "—";
        }
    }
}
