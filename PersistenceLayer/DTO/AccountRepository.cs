using Oracle.ManagedDataAccess.Client;
using PersistenceLayer.interfaces;
using ResourceLayer;
using System;

namespace PersistenceLayer.DTO
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
                        command.Parameters.Add(new OracleParameter("account_type", account.account_type_id));
                        command.Parameters.Add(new OracleParameter("status", account.status));
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
                                status = reader.GetString(3),

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

        public List<Account> GetAccounts()
        {
            try
            {
                var accounts = new List<Account>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, code, name, account_type, status, created_at, updated_at FROM Account";
                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(new Account
                            {
                                id = reader.GetInt32(0),
                                code = reader.GetString(1),
                                name = reader.GetString(2),
                                account_type_id = reader.GetInt32(3),
                                status = reader.GetString(4),
                                created_at = reader.GetDateTime(5),
                                updated_at = reader.GetDateTime(6)
                            });
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

        public void Update(Account account)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Account SET name = :name, account_type = :account_type, " +
                                   "status = :status, updated_at = :updated_at WHERE id = :id";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("name", account.name));
                        command.Parameters.Add(new OracleParameter("account_type", account.account_type_id));
                        command.Parameters.Add(new OracleParameter("status", account.status));
                        command.Parameters.Add(new OracleParameter("updated_at", account.updated_at));
                        command.Parameters.Add(new OracleParameter("id", account.id));

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
                    string query = "DELETE FROM Account WHERE id = :id";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("id", accountId));
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

        public List<Account> Search(string keyword)
        {
            try
            {
                var accounts = new List<Account>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, code, name, account_type, status, created_at, updated_at " +
                                   "FROM Account WHERE name LIKE :keyword OR code LIKE :keyword";
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("keyword", $"%{keyword}%"));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                accounts.Add(new Account
                                {
                                    id = reader.GetInt32(0),
                                    code = reader.GetString(1),
                                    name = reader.GetString(2),
                                    account_type_id = reader.GetInt32(3),
                                    status = reader.GetString(4),
                                    created_at = reader.GetDateTime(5),
                                    updated_at = reader.GetDateTime(6)
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

        public List<Account> GetAccountsRepository()
        {
            try
            {
                var accounts = new List<Account>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    a.id, a.code, a.name, a.account_type, a.status, a.created_at, a.updated_at,
                    at.id AS account_type_id, at.code AS account_type_code, at.name AS account_type_name 
                FROM Account a
                JOIN AccountType at ON a.account_type = at.id
                WHERE 
                a.status = 'ACTIVE'";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var account = new Account
                            {
                                id = reader.GetInt32(0),
                                code = reader.GetString(1),
                                name = reader.GetString(2),
                                account_type_id = reader.GetInt32(3),
                                status = reader.GetString(4),
                                created_at = reader.GetDateTime(5),
                                updated_at = reader.GetDateTime(6),
                                AccountType = new AccountType
                                {
                                    id = reader.GetInt32(7),
                                    code = reader.GetString(8),
                                    name = reader.GetString(9),
                                }
                            };

                            accounts.Add(account);
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