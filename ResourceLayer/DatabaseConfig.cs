using Microsoft.Extensions.Configuration;
namespace ResourceLayer
{
    public static class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("OracleDbConnection");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new Exception("La cadena de conexión no se encontró o está vacía.");
                }

                return connectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer la cadena de conexión: {ex.Message}");
                throw;
            }
        }

    }
}
