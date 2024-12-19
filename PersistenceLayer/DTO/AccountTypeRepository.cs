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
    public class AccountTypeRepository
    {
        private readonly string _connectionString;

        public AccountTypeRepository()
        {
            _connectionString = DatabaseConfig.GetConnectionString();
        }

        public void Create(AccountType accountType)
        {
            
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Accounttype (code, name, status, created_at, updated_at) " +
                                   "VALUES (:code, :name, :status, :created_at, :updated_at)";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("code", accountType.code));
                        command.Parameters.Add(new OracleParameter("name", accountType.name));
                        command.Parameters.Add(new OracleParameter("status", accountType.status));
                        command.Parameters.Add(new OracleParameter("created_at", accountType.created_at));
                        command.Parameters.Add(new OracleParameter("updated_at", accountType.updated_at));

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

        public void Update(AccountType accountType)
        {

            try
            {

                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    string query = "UPDATE accounttype SET name = :name, status = :status," +
                                       "updated_at = :updated_at WHERE id = :id";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("name", accountType.name));
                        command.Parameters.Add(new OracleParameter("status", accountType.status));
                        command.Parameters.Add(new OracleParameter("updated_at", accountType.updated_at));
                        command.Parameters.Add(new OracleParameter("id", accountType.id));

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

        public void Delete(int accountId)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string deleteEntryQuery = @"
                        DELETE FROM EntryDetail 
                        WHERE account IN (
                            SELECT id FROM Account WHERE account_type = :account_type
                        )";
                            using (var deleteEntryCommand = new OracleCommand(deleteEntryQuery, connection))
                            {
                                deleteEntryCommand.Parameters.Add(new OracleParameter("account_type", accountId));
                                deleteEntryCommand.Transaction = transaction;
                                deleteEntryCommand.ExecuteNonQuery();
                            }

                            string deleteAccountQuery = "DELETE FROM Account WHERE account_type = :account_type";
                            using (var deleteAccountCommand = new OracleCommand(deleteAccountQuery, connection))
                            {
                                deleteAccountCommand.Parameters.Add(new OracleParameter("account_type", accountId));
                                deleteAccountCommand.Transaction = transaction;
                                deleteAccountCommand.ExecuteNonQuery();
                            }

                            string deleteParentQuery = "DELETE FROM AccountType WHERE id = :id";
                            using (var deleteParentCommand = new OracleCommand(deleteParentQuery, connection))
                            {
                                deleteParentCommand.Parameters.Add(new OracleParameter("id", accountId));
                                deleteParentCommand.Transaction = transaction;
                                deleteParentCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error: {ex.Message}");
                            throw;
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de Oracle: {ex.Message}");
                throw;
            }
        }


        public List<AccountType> GetAccountTypesRepository()
        {
            try
            {
                var accountTypes = new List<AccountType>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT * FROM accounttype";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var accountType = new AccountType
                            {
                                id = reader.GetInt32(0),
                                code = reader.GetString(1),
                                name = reader.GetString(2),
                                status = (reader.GetString(3) == "ACTIVE") ? "Disponible" : "No disponible" ,
                                created_at = reader.GetDateTime(4),
                                updated_at = reader.GetDateTime(5),
                            };

                            accountTypes.Add(accountType);
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

        public List<AccountType> Search(string keyword)
        {
            try
            {
                var accountTypes = new List<AccountType>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, code, name, status, created_at, updated_at " +
                                   "FROM accounttype WHERE name LIKE :keyword OR code LIKE :keyword";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("keyword", $"%{keyword}%"));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                accountTypes.Add(new AccountType
                                {
                                    id = reader.GetInt32(0),
                                    code = reader.GetString(1),
                                    name = reader.GetString(2),
                                    status = reader.GetString(3),
                                    created_at = reader.GetDateTime(4),
                                    updated_at = reader.GetDateTime(5)
                                });
                            }
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
