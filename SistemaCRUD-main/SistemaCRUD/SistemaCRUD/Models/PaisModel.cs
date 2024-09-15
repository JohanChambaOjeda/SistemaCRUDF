using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using _06Publicaciones.config;

namespace _06Publicaciones.Models
{
    public class PaisModel
    {
        private string _connectionString = "Your Connection String Here";

        // Método para obtener todos los países
        public DataTable Todos()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Paises", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        // Método para obtener un país por ID
        public DataRow ObtenerPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Paises WHERE Id = @Id", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
        }

        // Método para agregar un nuevo país
        public void AgregarPais(string nombre, string continente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Paises (Nombre, Continente) VALUES (@Nombre, @Continente)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Continente", continente);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para actualizar un país existente
        public void ActualizarPais(int id, string nombre, string continente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Paises SET Nombre = @Nombre, Continente = @Continente WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Continente", continente);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para eliminar un país
        public void EliminarPais(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Paises WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}