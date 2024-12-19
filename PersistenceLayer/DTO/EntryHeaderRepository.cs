using Oracle.ManagedDataAccess.Client;
using ResourceLayer;
using System;
using System.Collections.Generic;

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

                    string insertQuery = @"
                        INSERT INTO EntryHeader 
                        (entry_date, voucher_type, numeration, notes, created_at, updated_at)
                        VALUES (:entry_date, :voucher_type, :numeration, :notes, :created_at, :updated_at)";

                    using (var command = new OracleCommand(insertQuery, connection))
                    {
                        command.Parameters.Add(new OracleParameter("entry_date", header.entry_date));
                        command.Parameters.Add(new OracleParameter("voucher_type", header.voucher_type));
                        command.Parameters.Add(new OracleParameter("numeration", header.numeration));
                        command.Parameters.Add(new OracleParameter("notes", header.notes));
                        command.Parameters.Add(new OracleParameter("created_at", header.created_at));
                        command.Parameters.Add(new OracleParameter("updated_at", header.updated_at));

                        command.ExecuteNonQuery();
                    }

                    string selectQuery = "SELECT MAX(id) FROM EntryHeader";

                    using (var selectCommand = new OracleCommand(selectQuery, connection))
                    {
                        headerId = Convert.ToInt32(selectCommand.ExecuteScalar());
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error en EntryHeader: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
                throw;
            }

            return headerId;
        }

        public List<EntryHeader> GetAllEntryHeader()
        {
            try
            {
                var entryHeaders = new List<EntryHeader>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, entry_date, voucher_type, numeration, notes, created_at, updated_at FROM EntryHeader";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entryHeaders.Add(new EntryHeader
                            {
                                id = reader.GetInt32(0),
                                entry_date = reader.GetDateTime(1),
                                voucher_type = reader.GetString(2),
                                numeration = reader.GetString(3),
                                notes = reader.IsDBNull(4) ? null : reader.GetString(4),
                                created_at = reader.GetDateTime(5),
                                updated_at = reader.GetDateTime(6),
                            });
                        }
                    }
                }
                return entryHeaders;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de Oracle: {ex.Message}");
                throw;
            }
        }


        public async Task DeleteHeaderId(int id)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteEntryQuery = @"
                    DELETE FROM EntryHeader 
                    WHERE id = :id";

                        using (var deleteEntryCommand = new OracleCommand(deleteEntryQuery, connection))
                        {
                            deleteEntryCommand.Parameters.Add(new OracleParameter("id", id));
                            deleteEntryCommand.Transaction = transaction;

                            int rowsAffected = await deleteEntryCommand.ExecuteNonQueryAsync();
                            Console.WriteLine($"Rows affected in EntryHeader: {rowsAffected}");
                        }

                        await transaction.CommitAsync();
                    }
                    catch (OracleException ex)
                    {
                        await transaction.RollbackAsync();
                        Console.WriteLine($"Error en EntryHeader: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public async Task UpdateHeader(EntryHeader entryHeader)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateEntryQuery = @"
                UPDATE EntryHeader 
                SET 
                    entry_date = :entry_date,
                    voucher_type = :voucher_type,
                    numeration = :numeration,
                    notes = :notes,
                    updated_at = :updated_at
                WHERE id = :id";

                        using (var updateEntryCommand = new OracleCommand(updateEntryQuery, connection))
                        {
                            updateEntryCommand.Parameters.Add(new OracleParameter("entry_date", entryHeader.entry_date));
                            updateEntryCommand.Parameters.Add(new OracleParameter("voucher_type", entryHeader.voucher_type));
                            updateEntryCommand.Parameters.Add(new OracleParameter("numeration", entryHeader.numeration));
                            updateEntryCommand.Parameters.Add(new OracleParameter("notes", entryHeader.notes));
                            updateEntryCommand.Parameters.Add(new OracleParameter("updated_at", entryHeader.updated_at));
                            updateEntryCommand.Parameters.Add(new OracleParameter("id", entryHeader.id));
                            updateEntryCommand.Transaction = transaction;

                            int rowsAffected = await updateEntryCommand.ExecuteNonQueryAsync();
                            Console.WriteLine($"Rows affected in EntryHeader: {rowsAffected}");
                        }

                        await transaction.CommitAsync();
                    }
                    catch (OracleException ex)
                    {
                        await transaction.RollbackAsync();
                        Console.WriteLine($"Error en EntryHeader: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public List<EntryHeader> Search(string keyword)
        {
            try
            {
                var entryHeadersResult = new List<EntryHeader>();
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT id, entry_date, voucher_type, numeration, notes, created_at, updated_at
                FROM EntryHeader
                WHERE numeration LIKE :keyword OR notes LIKE :keyword OR voucher_type LIKE :keyword";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("keyword", $"%{keyword}%"));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                entryHeadersResult.Add(new EntryHeader
                                {
                                    id = reader.GetInt32(0),
                                    entry_date = reader.GetDateTime(1),
                                    voucher_type = reader.GetString(2),
                                    numeration = reader.GetString(3),
                                    notes = reader.IsDBNull(4) ? null : reader.GetString(4), 
                                    created_at = reader.GetDateTime(5),
                                    updated_at = reader.GetDateTime(6)
                                });
                            }
                        }
                    }
                }
                return entryHeadersResult;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de Oracle: {ex.Message}");
                throw;
            }
        }

    }
}
