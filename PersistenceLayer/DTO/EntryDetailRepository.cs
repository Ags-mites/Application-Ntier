using Oracle.ManagedDataAccess.Client;
using ResourceLayer;
using System;
using System.Collections.Generic;

namespace PersistenceLayer.DTO
{
    public class EntryDetailRepository
    {
        private readonly string _connectionString;

        public EntryDetailRepository()
        {
            _connectionString = DatabaseConfig.GetConnectionString();
        }

        public async Task CreateMultipleAsync(List<EntryDetail> details)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = @"
                INSERT INTO EntryDetail 
                (entry_id, account, description, debit_amount, credit_amount, created_at, updated_at) 
                VALUES (:entry_id, :account, :description, :debit_amount, :credit_amount, :created_at, :updated_at)";

                    using (var command = new OracleCommand(query, connection))
                    {
                        foreach (var detail in details)
                        {
                            command.Parameters.Clear();
                            command.Parameters.Add(new OracleParameter("entry_id", detail.entry_id));
                            command.Parameters.Add(new OracleParameter("account", detail.account));
                            command.Parameters.Add(new OracleParameter("description", detail.description));
                            command.Parameters.Add(new OracleParameter("debit_amount", detail.debit_amount ?? (object)DBNull.Value));
                            command.Parameters.Add(new OracleParameter("credit_amount", detail.credit_amount ?? (object)DBNull.Value));
                            command.Parameters.Add(new OracleParameter("created_at", detail.created_at));
                            command.Parameters.Add(new OracleParameter("updated_at", detail.updated_at));

                            await command.ExecuteNonQueryAsync();
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


        public void CreateMultiple(List<EntryDetail> details)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO EntryDetail 
                        (entry_id, account, description, debit_amount, credit_amount, created_at, updated_at) 
                        VALUES (:entry_id, :account, :description, :debit_amount, :credit_amount, :created_at, :updated_at)";

                    using (var command = new OracleCommand(query, connection))
                    {
                        foreach (var detail in details)
                        {
                            command.Parameters.Clear();
                            command.Parameters.Add(new OracleParameter("entry_id", detail.entry_id));
                            command.Parameters.Add(new OracleParameter("account", detail.account));
                            command.Parameters.Add(new OracleParameter("description", detail.description));
                            command.Parameters.Add(new OracleParameter("debit_amount", detail.debit_amount ?? (object)DBNull.Value));
                            command.Parameters.Add(new OracleParameter("credit_amount", detail.credit_amount ?? (object)DBNull.Value));
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

        public List<EntryDetail> GetEntryDetailsbyEntryHeader(int id)
        {
            try
            {
                var entryDetails = new List<EntryDetail>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT ed.id, ed.entry_id, a.name, ed.description, ed.debit_amount, ed.credit_amount, ed.created_at, ed.updated_at
                FROM EntryDetail ed
                INNER JOIN account a 
                ON ed.account = a.id
                WHERE ed.entry_id = :entry_id";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("entry_id", id));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                entryDetails.Add(new EntryDetail
                                {
                                    id = reader.GetInt32(0),
                                    entry_id = reader.GetInt32(1),
                                    accountName = reader.GetString(2),
                                    description = reader.GetString(3),
                                    debit_amount = reader.GetDecimal(4),
                                    credit_amount = reader.GetDecimal(5),
                                    created_at = reader.GetDateTime(6),
                                    updated_at = reader.GetDateTime(7)
                                });
                            }
                        }
                    }
                }

                return entryDetails;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error al consultar a la base de datos: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateMultiple(List<EntryDetail> entryDetails)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var detail in entryDetails)
                        {
                            string updateDetailQuery = @"
                    UPDATE EntryDetail 
                    SET 
                        account = :account,
                        description = :description,
                        debit_amount = :debit_amount,
                        credit_amount = :credit_amount,
                        updated_at = CURRENT_TIMESTAMP
                    WHERE id = :id";

                            using (var updateDetailCommand = new OracleCommand(updateDetailQuery, connection))
                            {
                                updateDetailCommand.Parameters.Add(new OracleParameter("account", detail.account));
                                updateDetailCommand.Parameters.Add(new OracleParameter("description", detail.description));
                                updateDetailCommand.Parameters.Add(new OracleParameter("debit_amount", detail.debit_amount));
                                updateDetailCommand.Parameters.Add(new OracleParameter("credit_amount", detail.credit_amount));
                                updateDetailCommand.Parameters.Add(new OracleParameter("id", detail.id));
                                updateDetailCommand.Transaction = transaction;

                                int rowsAffected = await updateDetailCommand.ExecuteNonQueryAsync();
                                Console.WriteLine($"Rows affected in EntryDetail: {rowsAffected}");
                            }
                        }

                        await transaction.CommitAsync();
                    }
                    catch (OracleException ex)
                    {
                        await transaction.RollbackAsync();
                        Console.WriteLine($"Error en EntryDetail: {ex.Message}");
                        throw;
                    }
                }
            }
        }


        public async Task DeleteDetailbyHeaderId(int headerId)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteEntryQuery = @"
                    DELETE FROM EntryDetail 
                    WHERE entry_id IN (SELECT id FROM EntryHeader WHERE id = :headerId)";

                        using (var deleteEntryCommand = new OracleCommand(deleteEntryQuery, connection))
                        {
                            deleteEntryCommand.Parameters.Add(new OracleParameter("headerId", headerId));
                            deleteEntryCommand.Transaction = transaction;

                            int rowsAffected = await deleteEntryCommand.ExecuteNonQueryAsync();
                            Console.WriteLine($"Rows affected in EntryDetail: {rowsAffected}");
                        }

                        await transaction.CommitAsync();
                    }
                    catch (OracleException ex)
                    {
                        await transaction.RollbackAsync();
                        Console.WriteLine($"Error en EntryDetail: {ex.Message}");
                        throw;
                    }
                }
            }
        }
    }
}
