using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace PersistenceLayer.ClientesyCiudad
{
    public class Articulo
    {
        public int Codigo { get; set; } // Este es el CODIGO en la base de datos
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        // Método para insertar un artículo
        public static void Insertar(Articulo articulo)
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    var command = new OracleCommand("INSERT INTO articulo (CODIGO, NOMBRE, PRECIO) VALUES (:Codigo, :Nombre, :Precio)", connection);
                    command.Parameters.Add(new OracleParameter(":Codigo", articulo.Codigo));
                    command.Parameters.Add(new OracleParameter(":Nombre", articulo.Nombre));
                    command.Parameters.Add(new OracleParameter(":Precio", articulo.Precio));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error al insertar artículo: {ex.Message}");
                }
            }
        }

        // Método para obtener todos los artículos
        public static List<Articulo> ObtenerTodos()
        {
            var articulos = new List<Articulo>();

            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    var command = new OracleCommand("SELECT CODIGO, NOMBRE, PRECIO FROM articulo", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var articulo = new Articulo
                        {
                            Codigo = Convert.ToInt32(reader["CODIGO"]),  // Mapea CODIGO
                            Nombre = reader["NOMBRE"].ToString(),
                            Precio = Convert.ToDecimal(reader["PRECIO"])
                        };
                        articulos.Add(articulo);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error al obtener artículos: {ex.Message}");
                }
            }

            return articulos;
        }

        // Método para obtener un artículo por su CODIGO
        public static Articulo ObtenerPorCodigo(int codigo)
        {
            Articulo articulo = null;

            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    var command = new OracleCommand("SELECT CODIGO, NOMBRE, PRECIO FROM articulo WHERE CODIGO = :Codigo", connection);
                    command.Parameters.Add(new OracleParameter(":Codigo", codigo));

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        articulo = new Articulo
                        {
                            Codigo = Convert.ToInt32(reader["CODIGO"]),
                            Nombre = reader["NOMBRE"].ToString(),
                            Precio = Convert.ToDecimal(reader["PRECIO"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error al obtener artículo: {ex.Message}");
                }
            }

            return articulo;
        }

        // Método para actualizar un artículo
        public static void Actualizar(Articulo articulo)
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    var command = new OracleCommand("UPDATE articulo SET NOMBRE = :Nombre, PRECIO = :Precio WHERE CODIGO = :Codigo", connection);
                    command.Parameters.Add(new OracleParameter(":Codigo", articulo.Codigo));
                    command.Parameters.Add(new OracleParameter(":Nombre", articulo.Nombre));
                    command.Parameters.Add(new OracleParameter(":Precio", articulo.Precio));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error al actualizar artículo: {ex.Message}");
                }
            }
        }

        // Método para eliminar un artículo
        public static void Eliminar(int codigo)
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    var command = new OracleCommand("DELETE FROM articulo WHERE CODIGO = :Codigo", connection);
                    command.Parameters.Add(new OracleParameter(":Codigo", codigo));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error al eliminar artículo: {ex.Message}");
                }
            }
        }
    }
}