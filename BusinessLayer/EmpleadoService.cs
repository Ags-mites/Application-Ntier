using PersistenceLayer;
using PersistenceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmpleadoService
    {
        private readonly EmpleadoRepository _repository;

        public EmpleadoService()
        {
            _repository = new EmpleadoRepository();
        }

        public void AddEmpleado(string empleadoData)
        {
            var parts = empleadoData.Split(';');
            if (parts.Length != 4) throw new ArgumentException("Datos no válidos: Se esperaban 4 campos separados por ';'.");

            var empleado = new Empleados
            {
                
                cedula = parts[0],
                nombre = parts[1],
                fecha_ingreso = DateTime.Parse(parts[3]),
                sueldo = decimal.Parse(parts[2])
            };

            _repository.Create(empleado);
        }

         public void UpdateEmpleado(string accountData)
        {
            var parts = accountData.Split(';');
            if (parts.Length != 5) throw new ArgumentException("Datos no válidos: Se esperaban 5 campos separados por ';'.");

            var updateEmpleado = new Empleados
            {
                id = int.Parse(parts[0]),
                cedula = parts[2],
                nombre= parts[1],
                fecha_ingreso = DateTime.Parse(parts[4]),
                sueldo = decimal.Parse(parts[3])
            };

            _repository.Update(updateEmpleado);
        }

        public List<Empleados> GetEmpleadosRepository()
        {
            return _repository.GetAll();
        }

        public void DeleteWorkerId(int id)
        {

            _repository.Delete(id);
        }

        public List<Empleados> SearchWorkers(string keyword)
        {
            return _repository.Search(keyword);
        }
    }
}
