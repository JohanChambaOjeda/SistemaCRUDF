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

namespace _06Publicaciones.Views.Roles
{
    public partial class RolesForm : Form
    {
        private RolesController rolesController = new RolesController();

        public RolesForm()
        {
            InitializeComponent();
            LoadRoles();
        }

        // Método para cargar los roles en el DataGridView
        private void LoadRoles()
        {
            List<Rol> roles = rolesController.GetAllRoles();
            dataGridViewRoles.DataSource = roles;
        }

        // Evento del botón para actualizar un rol
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol()
            {
                RoleID = int.Parse(txtRoleID.Text),
                RoleName = txtRoleName.Text
            };

            rolesController.UpdateRole(rol);
            MessageBox.Show("Rol actualizado correctamente.");
            LoadRoles();  // Recargar los roles después de la actualización
        }

        // Evento cuando se selecciona una fila en el DataGridView
        private void dataGridViewRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewRoles.Rows[e.RowIndex];
                txtRoleID.Text = row.Cells["RoleID"].Value.ToString();
                txtRoleName.Text = row.Cells["RoleName"].Value.ToString();
            }
        }
    }
}
