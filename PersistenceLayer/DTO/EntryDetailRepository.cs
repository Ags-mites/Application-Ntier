using Oracle.ManagedDataAccess.Client;
using ResourceLayer;

namespace PersistenceLayer.DTO
{
    public class EntryDetailRepository
    {
        private readonly string _connectionString;

        public EntryDetailRepository()
        {
            _connectionString = DatabaseConfig.GetConnectionString();
        }

        public void CreateMultiple(List<EntryDetail> details)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO EntryDetail 
                            (entry_id, account, description, debit_amount, credit_amount, created_at, updated_at) 
                            VALUES (:entry_id, :account, :description, :debit_amount, :credit_amount, :created_at, :updated_at)";

                    foreach (var detail in details)
                    {
                        using (var command = new OracleCommand(query, connection))
                        {
                            command.Parameters.Add(new OracleParameter("entry_id", detail.entry_id));
                            command.Parameters.Add(new OracleParameter("account", detail.account));
                            command.Parameters.Add(new OracleParameter("description", detail.description));
                            command.Parameters.Add(new OracleParameter("debit_amount", detail.debit_amount));
                            command.Parameters.Add(new OracleParameter("credit_amount", detail.credit_amount));
                            command.Parameters.Add(new OracleParameter("created_at", detail.created_at));
                            command.Parameters.Add(new OracleParameter("updated_at", detail.updated_at));

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error en EntryDetail: {ex.Message}");
                throw;
            }
        }
    }
}
