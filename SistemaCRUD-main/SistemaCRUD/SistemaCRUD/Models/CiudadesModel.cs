using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _06Publicaciones.config;
using System.Data.SqlClient;

namespace _06Publicaciones.Models
{

    public class CiudadesModel
    {
        private string _connectionString = "Your Connection String Here";

        // Método para obtener todas las ciudades con relación
        public DataTable TodosConRelacion()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Ciudades INNER JOIN Paises ON Ciudades.PaisId = Paises.Id", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        // Método para obtener una ciudad por ID
        public DataRow ObtenerPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Ciudades WHERE Id = @Id", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
        }

        // Método para agregar una nueva ciudad
        public void AgregarCiudad(string nombre, int paisId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Ciudades (Nombre, PaisId) VALUES (@Nombre, @PaisId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@PaisId", paisId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para actualizar una ciudad existente
        public void ActualizarCiudad(int id, string nombre, int paisId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Ciudades SET Nombre = @Nombre, PaisId = @PaisId WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@PaisId", paisId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para eliminar una ciudad
        public void EliminarCiudad(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Ciudades WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
