using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Publicaciones.Controllers
{
    using _06Publicaciones.config;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class UsuariosController
    {
        private Conexion conexion = new Conexion();

        // Método para obtener todos los usuarios
        public List<Usuario> GetAllUsers()
        {
            List<Usuario> usuarios = new List<Usuario>();
            SqlCommand command = new SqlCommand("SELECT * FROM Usuarios", conexion.GetConnection());
            conexion.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Usuario usuario = new Usuario()
                {
                    UserID = (int)reader["UserID"],
                    UserName = reader["UserName"].ToString(),
                    RoleID = (int)reader["RoleID"]
                };
                usuarios.Add(usuario);
            }

            reader.Close();
            conexion.CloseConnection();
            return usuarios;
        }

        // Método para actualizar un usuario
        public void UpdateUser(Usuario usuario)
        {
            SqlCommand command = new SqlCommand("UPDATE Usuarios SET UserName = @UserName, RoleID = @RoleID WHERE UserID = @UserID", conexion.GetConnection());
            command.Parameters.AddWithValue("@UserID", usuario.UserID);
            command.Parameters.AddWithValue("@UserName", usuario.UserName);
            command.Parameters.AddWithValue("@RoleID", usuario.RoleID);

            conexion.OpenConnection();
            command.ExecuteNonQuery();
            conexion.CloseConnection();
        }
    }

}
