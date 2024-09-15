using _06Publicaciones.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06Publicaciones.Views.Usuarios
{
    public partial class UsuariosForm : Form
    {
        private UsuariosController usuariosController = new UsuariosController();

        public UsuariosForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        // Método para cargar los usuarios en el DataGridView
        private void LoadUsers()
        {
            List<Usuario> usuarios = usuariosController.GetAllUsers();
            dataGridViewUsuarios.DataSource = usuarios;
        }

        // Evento del botón para actualizar un usuario
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario()
            {
                UserID = int.Parse(txtUserID.Text),
                UserName = txtUserName.Text,
                RoleID = int.Parse(txtRoleID.Text)
            };

            usuariosController.UpdateUser(usuario);
            MessageBox.Show("Usuario actualizado correctamente.");
            LoadUsers();  // Recargar los usuarios después de la actualización
        }

        // Evento cuando se selecciona una fila en el DataGridView
        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUsuarios.Rows[e.RowIndex];
                txtUserID.Text = row.Cells["UserID"].Value.ToString();
                txtUserName.Text = row.Cells["UserName"].Value.ToString();
                txtRoleID.Text = row.Cells["RoleID"].Value.ToString();
            }
        }
    }
}
