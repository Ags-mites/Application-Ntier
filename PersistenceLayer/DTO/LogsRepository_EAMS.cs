using Oracle.ManagedDataAccess.Client;
using ResourceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.DTO
{
    public class LogsRepository_EAMS
    {
        private readonly string _connectionString;

        public LogsRepository_EAMS()
        {
            _connectionString = DatabaseConfig.GetConnectionString();
        }

        public void RegisterLogs_EAMS(Logs_EAMS logs_EAMS) {
            try {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Log_EAMS (activity_EAMS, created_at_EAMS, time_EAMS) " +
                                   "VALUES (:activity_EAMS, :created_at_EAMS, :time_EAMS)";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("activity_EAMS", logs_EAMS.activity_eams));
                        command.Parameters.Add(new OracleParameter("created_at_EAMS", logs_EAMS.created_at_eams));
                        command.Parameters.Add(new OracleParameter("time_EAMS", logs_EAMS.time_eams));

                        command.ExecuteNonQuery();
                    }
                }
            } catch(OracleException ex) {

            }

        }
    }
}
