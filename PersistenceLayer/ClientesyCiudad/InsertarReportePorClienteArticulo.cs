using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace PersistenceLayer.ClientesyCiudad
{
    public class InsertarReportePorClienteArticulo
    {
        public void Insertar(string clienteRuc, int codigoArticulo, decimal totalVenta, OracleTransaction transaction = null)
        {
            try
            {
                using (var connection = Conexion.ObtenerConexion())
                {
                    connection.Open();
                    string query = "INSERT INTO reporteclientearticulo (CLIENTERUC, CODIGOARTICULO, DOLARESVENDIDOS) VALUES (:clienteRuc, :codigoArticulo, :totalVenta)";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":clienteRuc", clienteRuc));  // Asegúrate de que el parámetro coincida con la columna CLIENTERUC
                        command.Parameters.Add(new OracleParameter(":codigoArticulo", codigoArticulo));
                        command.Parameters.Add(new OracleParameter(":totalVenta", totalVenta));
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar en reporteclientearticulo: {ex.Message}");
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
                    string query = "SELECT * FROM reporteclientearticulo"; // Ajusta la consulta según tu esquema
                    using (var command = new OracleCommand(query, connection))
                    using (var adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(dataTable); // Llena el DataTable con los resultados
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos de reporteclientearticulo: {ex.Message}");
            }

            return dataTable; // Retorna el DataTable con los datos
        }
    }
}