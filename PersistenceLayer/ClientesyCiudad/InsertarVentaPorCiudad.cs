using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace PersistenceLayer.ClientesyCiudad
{
    public class InsertarVentaPorCiudad
    {
        public void Insertar(string ciudad, decimal totalVenta)
        {
            try
            {
                using (var connection = Conexion.ObtenerConexion()) // Asegúrate de que la conexión esté configurada correctamente
                {
                    connection.Open();
                    string query = "INSERT INTO VentasPorCiudad (NombreCiudad, DolaresVendidos) VALUES (:ciudad, :totalVenta)";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("ciudad", ciudad));
                        command.Parameters.Add(new OracleParameter("totalVenta", totalVenta));
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes agregar un mejor manejo de errores dependiendo de tus necesidades
                Console.WriteLine($"Error al insertar en VentasPorCiudad: {ex.Message}");
            }

        }
        public DataTable ObtenerTodos()
        {
            var dataTable = new DataTable();

            try
            {
                using (var connection = Conexion.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT * FROM VentasPorCiudad"; // Ajusta la consulta según tu esquema
                    using (var command = new OracleCommand(query, connection))
                    using (var adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(dataTable); // Llena el DataTable con los resultados
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos de VentasPorCiudad: {ex.Message}");
            }

            return dataTable; // Retorna el DataTable con los datos
        }
    }
}