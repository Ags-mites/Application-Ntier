using Oracle.ManagedDataAccess.Client;
using PersistenceLayer.ClientesyCiudad;
using System;
using System.Collections.Generic;

namespace PersistenceLayer.ClientesyCiudad
{
    public class Cliente
    {
        public string Ruc { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }

    public class ClienteRepository
    {
        public List<Cliente> LeerClientes()
        {
            var clientes = new List<Cliente>();

            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = "SELECT RUC, NOMBRE, DIRECCION FROM cliente"; ; // Corregido
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            Ruc = reader["Ruc"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            Direccion = reader["direccion"].ToString() // Ahora es válido
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al leer clientes: " + ex.Message);
                }
            }

            return clientes;
        }

        public void InsertarCliente(string Ruc, string nombre, string direccion)
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                connection.Open(); // Asegúrate de abrir la conexión aquí
                string query = "INSERT INTO cliente (Ruc, nombre, direccion) VALUES (:Ruc, :nombre, :direccion)";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":Ruc", OracleDbType.Varchar2).Value = Ruc;
                    command.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = nombre;
                    command.Parameters.Add(":direccion", OracleDbType.Varchar2).Value = direccion;

                    command.ExecuteNonQuery(); // Ejecuta la inserción
                }
            }
        }

        public void ActualizarCliente(string Ruc, string nombre, string direccion)
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();  // Asegúrate de abrir la conexión aquí
                    string query = "UPDATE cliente SET nombre = :nombre, direccion = :direccion WHERE Ruc = :Ruc"; // Corregido
                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = nombre;
                    command.Parameters.Add(":direccion", OracleDbType.Varchar2).Value = direccion; // Corregido
                    command.Parameters.Add(":Ruc", OracleDbType.Varchar2).Value = Ruc;

                    int rowsAffected = command.ExecuteNonQuery(); // Devuelve el número de filas afectadas
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Cliente actualizado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se actualizó ningún cliente. Verifica que el RUC sea correcto.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar cliente: " + ex.Message);
                }
            }
        }

        public void EliminarCliente(string Ruc)
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open(); // Asegúrate de abrir la conexión aquí
                    string query = "DELETE FROM cliente WHERE Ruc = :Ruc";  // Eliminar por Ruc
                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add(":Ruc", OracleDbType.Varchar2).Value = Ruc;
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Cliente eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ningún cliente con ese RUC.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar cliente: " + ex.Message);
                }
            }
        }
        public List<Cliente> BuscarClientes(string searchTerm)
        {
            var clientes = new List<Cliente>();

            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    // Usamos LIKE para buscar tanto por RUC como por nombre
                    string query = "SELECT Ruc, nombre, direccion FROM cliente WHERE nombre LIKE :searchTerm OR Ruc LIKE :searchTerm";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":searchTerm", OracleDbType.Varchar2).Value = "%" + searchTerm + "%";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientes.Add(new Cliente
                                {
                                    Ruc = reader["Ruc"].ToString(),
                                    Nombre = reader["Nombre"].ToString(),
                                    Direccion = reader["direccion"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al buscar clientes: " + ex.Message);
                }
            }

            return clientes;
        }
    }
}