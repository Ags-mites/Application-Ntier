using Oracle.ManagedDataAccess.Client;
using ResourceLayer;
using System;

namespace PersistenceLayer.DTO
{
    public class UsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository()
        {
            _connectionString = DatabaseConfig.GetConnectionString();
        }

        // Método para verificar si el usuario existe y su estado es 'ACTIVE'
        public bool UserExists(string username)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE username = :username AND status = 'ACTIVE'";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("username", username));

                        var result = command.ExecuteScalar();
                        return Convert.ToInt32(result) > 0; // Retorna true si existe, false si no
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al verificar la existencia del usuario: {ex.Message}");
                return false;
            }
        }

        // Método para obtener la contraseña y el salt de un usuario
        public (string StoredPasswordHash, string Salt) GetPasswordAndSalt(string username)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT password, salt FROM Users WHERE username = :username AND status = 'ACTIVE'";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("username", username));

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var password = reader.GetString(0);
                                var salt = reader.GetString(1);

                                // Depuración de valores
                                Console.WriteLine($"Password: {password}");
                                Console.WriteLine($"Salt: {salt}");

                                return (password, salt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al obtener datos del usuario: {ex.Message}");
            }

            return (null, null); // Si no se encuentra el usuario o la consulta falla
        }
    }
}
