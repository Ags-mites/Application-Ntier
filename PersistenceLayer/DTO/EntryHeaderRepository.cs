using Oracle.ManagedDataAccess.Client;
using ResourceLayer;
using System.Data;

namespace PersistenceLayer.DTO
{
    public class EntryHeaderRepository
    {
        private readonly string _connectionString;

        public EntryHeaderRepository()
        {
            _connectionString = DatabaseConfig.GetConnectionString();
        }

        public int Create(EntryHeader header)
        {
            int headerId = 0;
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO EntryHeader 
                            (entry_date, voucher_type, numeration, notes, created_at, updated_at)
                            VALUES (:entry_date, :voucher_type, :numeration, :notes, :created_at, :updated_at)
                            RETURNING id INTO :id";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("entry_date", header.entry_date));
                        command.Parameters.Add(new OracleParameter("voucher_type", header.voucher_type));
                        command.Parameters.Add(new OracleParameter("numeration", header.numeration));
                        command.Parameters.Add(new OracleParameter("notes", header.notes));
                        command.Parameters.Add(new OracleParameter("created_at", header.created_at));
                        command.Parameters.Add(new OracleParameter("updated_at", header.updated_at));

                        var outputParam = new OracleParameter("id", OracleDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);

                        command.ExecuteNonQuery();
                        headerId = Convert.ToInt32(outputParam.Value); 
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error en EntryHeader: {ex.Message}");
                throw;
            }

            return headerId;
        }


    }
}
