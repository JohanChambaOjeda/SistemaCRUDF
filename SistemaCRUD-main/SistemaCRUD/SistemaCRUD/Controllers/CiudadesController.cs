using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06Publicaciones.Models;
using System.Data;
namespace _06Publicaciones.Controllers
{
    class CiudadesController
    {
        private CiudadesModel _ciudadesModel = new CiudadesModel();

        // Método para obtener todas las ciudades con relación
        public DataTable TodosConRelacion()
        {
            return _ciudadesModel.TodosConRelacion();
        }

        // Método para obtener una ciudad por ID
        public DataRow ObtenerPorId(int id)
        {
            return _ciudadesModel.ObtenerPorId(id);
        }

        // Método para agregar una nueva ciudad
        public void AgregarCiudad(string nombre, int paisId)
        {
            _ciudadesModel.AgregarCiudad(nombre, paisId);
        }

        // Método para actualizar una ciudad existente
        public void ActualizarCiudad(int id, string nombre, int paisId)
        {
            _ciudadesModel.ActualizarCiudad(id, nombre, paisId);
        }

        // Método para eliminar una ciudad
        public void EliminarCiudad(int id)
        {
            _ciudadesModel.EliminarCiudad(id);
        }
    }
}