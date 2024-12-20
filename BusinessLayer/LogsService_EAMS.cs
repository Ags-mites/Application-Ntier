using PersistenceLayer;
using PersistenceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LogsService_EAMS
    {
        private readonly LogsRepository_EAMS _repository;

        public LogsService_EAMS()
        {
            _repository = new LogsRepository_EAMS();
        }

        public void RegisterLogs_EAMS(string data)
        {

            var logs_EAMS = new Logs_EAMS
            {
                activity_eams = data,
                created_at_eams = DateTime.Now,
                time_eams = DateTime.Now
            };

            _repository.RegisterLogs_EAMS(logs_EAMS);
        }
    }
}
