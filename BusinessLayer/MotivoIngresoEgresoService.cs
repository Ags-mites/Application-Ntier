using PersistenceLayer.DTO;
using PersistenceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLayer
{
    public class MotivoIngresoEgresoService
    {
        private readonly MotivoIErepository _repository;


        public MotivoIngresoEgresoService()
        {
            _repository = new MotivoIErepository();
        }

        public void AddMotivo(string motivoData)
        {
            var parts = motivoData.Split(';');
            if (parts.Length != 2) throw new ArgumentException("Datos no válidos: Se esperaban 2 campos separados por ';'.");

            var motivo = new MOTIVO_INGRESO_EGRESO
            {
                Codigo = int.Parse(parts[0]),
                Nombre = parts[1],
            };

            _repository.Create(motivo);

        }

        public void UpdateMotivo(string motivoData)
        {
            var parts = motivoData.Split(';');
            if (parts.Length != 3) throw new ArgumentException("Datos no válidos: Se esperaban 3 campos separados por ';'.");
            var motivo = new MOTIVO_INGRESO_EGRESO
            {
                id = int.Parse(parts[0]),
                Codigo = int.Parse(parts[1]),
                Nombre = parts[2],
            };

            _repository.Update(motivo);
        }

        public void DeleteMotivo(int motivoId)
        {
            _repository.Delete(motivoId);


        }
        public List<MOTIVO_INGRESO_EGRESO> SearchByMotivo(string keyword)
        {
            return _repository.Search(keyword);
        }

        public List<MOTIVO_INGRESO_EGRESO> GetNomina()
        {
            return _repository.GetNomina();
        }


    }
}
