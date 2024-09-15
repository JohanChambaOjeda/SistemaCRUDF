using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06Publicaciones.Models;
using System.Data;
namespace _06Publicaciones.Controllers
{
    class PaisesController
    {
        private PaisModel _paisModel = new PaisModel();

        // Método para obtener todos los registros
        public DataTable Todos()
        {
            return _paisModel.Todos();
        }

        // Método para obtener un país por ID
        public DataRow ObtenerPorId(int id)
        {
            return _paisModel.ObtenerPorId(id);
        }

        // Método para agregar un nuevo país
        public void AgregarPais(string nombre, string continente)
        {
            _paisModel.AgregarPais(nombre, continente);
        }

        // Método para actualizar un país existente
        public void ActualizarPais(int id, string nombre, string continente)
        {
            _paisModel.ActualizarPais(id, nombre, continente);
        }

        // Método para eliminar un país
        public void EliminarPais(int id)
        {
            _paisModel.EliminarPais(id);
        }
    }
}