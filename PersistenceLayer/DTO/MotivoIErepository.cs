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
    public class MotivoIErepository
    {
        private readonly string _connectionString;

        public MotivoIErepository()
        {
            _connectionString = DatabaseConfig.GetConnectionString();

        }

        public void Create(MOTIVO_INGRESO_EGRESO motivo) {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO MOTIVO_INGRESO_EGRESO (codigo, nombre) " +
                                   "VALUES (:codigo, :nombre)";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("codigo", motivo.Codigo));
                        command.Parameters.Add(new OracleParameter("nombre", motivo.Nombre));

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
        public void Update(MOTIVO_INGRESO_EGRESO motivo)
        {
         try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE MOTIVO_INGRESO_EGRESO SET nombre = :nombre WHERE id = :id";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("nombre", motivo.Nombre));
                        command.Parameters.Add(new OracleParameter("id", motivo.id));

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
        public List<MOTIVO_INGRESO_EGRESO> GetNomina()
        {
            try
            {
                var nomina = new List<MOTIVO_INGRESO_EGRESO>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, codigo, nombre FROM MOTIVO_INGRESO_EGRESO";
                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nomina.Add(new MOTIVO_INGRESO_EGRESO
                            {
                                id = reader.GetInt32(0),
                                Codigo = reader.GetInt32(1),
                                Nombre = reader.GetString(2),
                            });
                        }
                    }
                }
                return nomina;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de Oracle: {ex.Message}");
                throw;
            }
        }
        public void Delete(int motivoId)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM MOTIVO_INGRESO_EGRESO WHERE id = :id";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("id", motivoId));
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

        public List<MOTIVO_INGRESO_EGRESO> Search(string keyword)
        {
            try
            {
                var accounts = new List<MOTIVO_INGRESO_EGRESO>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, codigo, nombre " +
                                   "FROM MOTIVO_INGRESO_EGRESO WHERE nombre LIKE :keyword OR codigo LIKE :keyword";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("keyword", $"%{keyword}%"));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                accounts.Add(new MOTIVO_INGRESO_EGRESO
                                {
                                    id = reader.GetInt32(0),
                                    Codigo = reader.GetInt32(1),
                                    Nombre = reader.GetString(2),
                                });
                            }
                        }
                    }
                }
                return accounts;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de Oracle: {ex.Message}");
                throw;
            }
        }
        
    }
}
