using _06Publicaciones.config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Publicaciones.Controllers
{
    public class RolesController
    {
        private Conexion Conexion = new Conexion();

        // Método para obtener todos los roles
        public List<Rol> GetAllRoles()
        {
            List<Rol> roles = new List<Rol>();
            SqlCommand command = new SqlCommand("SELECT * FROM Roles", conexion.GetConnection());
            conexion.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Rol rol = new Rol()
                {
                    RoleID = (int)reader["RoleID"],
                    RoleName = reader["RoleName"].ToString()
                };
                roles.Add(rol);
            }

            reader.Close();
            conexion.CloseConnection();
            return roles;
        }

        // Método para actualizar un rol
        public void UpdateRole(Rol rol)
        {
            SqlCommand command = new SqlCommand("UPDATE Roles SET RoleName = @RoleName WHERE RoleID = @RoleID", conexion.GetConnection());
            command.Parameters.AddWithValue("@RoleID", rol.RoleID);
            command.Parameters.AddWithValue("@RoleName", rol.RoleName);

            conexion.OpenConnection();
            command.ExecuteNonQuery();
            conexion.CloseConnection();
        }
    }
}
