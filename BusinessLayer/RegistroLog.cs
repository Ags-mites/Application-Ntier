using PersistenceLayer.DTO;
using PersistenceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RegistroLog
    {
        private readonly LogRepositoryMMRM _repository;

        public RegistroLog()
        {
            _repository = new LogRepositoryMMRM();
        }

        public void RegistrarLogs(string log)
        {
            
            var LogMMRM = new LogMotivo
            {

                ACTIVIDAD_MMRM = log,
                FECHA_MMRM = DateTime.Now,
                HORA_MMRM = DateTime.Now
            };

            /*Console.WriteLine($"{LogMMRM.ACTIVIDAD_MMRM}");
            Console.WriteLine($"{LogMMRM.FECHA_MMRM}");
            Console.WriteLine($"{LogMMRM.HORA_MMRM}");*/
            _repository.AddLog(LogMMRM);
        }
    }
}
