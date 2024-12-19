using Oracle.ManagedDataAccess.Client;
using ResourceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.DTO
{
    public class LogRepositoryMMRM

    {
        private readonly string _connectionString;

        public LogRepositoryMMRM()
        {
            _connectionString = DatabaseConfig.GetConnectionString();

        }
        public void AddLog(LogMotivo log)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Log_MMRM (ACTIVIDAD_MMRM, FECHA_MMRM, HORA_MMRM ) " +
                                   "VALUES (:ACTIVIDAD_MMRM, :FECHA_MMRM, :HORA_MMRM)";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("ACTIVIDAD_MMRM", log.ACTIVIDAD_MMRM));
                        command.Parameters.Add(new OracleParameter("FECHA_MMRM", log.FECHA_MMRM));
                        command.Parameters.Add(new OracleParameter("HORA_MMRM", log.HORA_MMRM));

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de Oracle: {ex.Message}");
                
                throw;
            }
        }
    }
}
