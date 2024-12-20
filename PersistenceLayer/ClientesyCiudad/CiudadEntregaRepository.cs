using Oracle.ManagedDataAccess.Client;
using PersistenceLayer.ClientesyCiudad;
using System;

using System.Collections.Generic;

namespace PersistenceLayer.ClientesyCiudad
{
    public class CiudadEntregaRepository
    {
        public List<CiudadEntrega> LeerCiudadesEntrega()
        {
            var ciudades = new List<CiudadEntrega>();

            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT codigo, nombre FROM ciudadentrega";
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ciudades.Add(new CiudadEntrega
                        {
                            Codigo = reader["codigo"].ToString(),
                            Nombre = reader["nombre"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al leer ciudades de entrega: " + ex.Message);
                }
            }

            return ciudades;
        }

        public void InsertarCiudadEntrega(string codigo, string nombre)
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO ciudadentrega (codigo, nombre) VALUES (:codigo, :nombre)";
                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add(":codigo", OracleDbType.Varchar2).Value = codigo;
                    command.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = nombre;

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar ciudad de entrega: " + ex.Message);
                }
            }
        }

        public void ActualizarCiudadEntrega(string codigo, string nombre)
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE ciudadentrega SET nombre = :nombre WHERE codigo = :codigo";
                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add(":codigo", OracleDbType.Varchar2).Value = codigo;
                    command.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = nombre;

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar ciudad de entrega: " + ex.Message);
                }
            }
        }

        public void EliminarCiudadEntrega(string codigo)
        {
            using (var connection = Conexion.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM ciudadentrega WHERE codigo = :codigo";
                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add(":codigo", OracleDbType.Varchar2).Value = codigo;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar ciudad de entrega: " + ex.Message);
                }
            }
        }
    }

    public class CiudadEntrega
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}

