using Oracle.ManagedDataAccess.Client;
using PersistenceLayer.interfaces;
using ResourceLayer;
using System;

namespace PersistenceLayer
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository()
        {
            _connectionString = DatabaseConfig.GetConnectionString();
        }

        public void Create(Account account)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Account (code, name, account_type, status, created_at, updated_at) " +
                                   "VALUES (:code, :name, :account_type, :status, :created_at, :updated_at)";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("code", account.code));
                        command.Parameters.Add(new OracleParameter("name", account.name));
                        command.Parameters.Add(new OracleParameter("account_type", account.account_type));
                        string status = account.status ? "ACTIVE" : "INACTIVE";
                        command.Parameters.Add(new OracleParameter("status", status));
                        command.Parameters.Add(new OracleParameter("created_at", account.created_at));
                        command.Parameters.Add(new OracleParameter("updated_at", account.updated_at));

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

        public List<AccountType> GetAccountTypes()
        {
            try
            {
                var accountTypes = new List<AccountType>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, code, name, status FROM AccountType";
                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accountTypes.Add(new AccountType
                            {
                                id = reader.GetInt32(0),
                                code = reader.GetString(1),
                                name = reader.GetString(2),
                                status = reader.GetBoolean(3)
                            });
                        }
                    }
                }
                return accountTypes;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de Oracle: {ex.Message}");
                throw;
            }
        }
    }
}