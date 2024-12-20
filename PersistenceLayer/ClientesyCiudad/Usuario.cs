using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace PersistenceLayer.ClientesyCiudad
{
    public class Usuario
    {
        // Método para agregar un nuevo usuario
        public void InsertarUsuario(string nombreUsuario, string contrasena)
        {
            try
            {
                using (var connection = Conexion.ObtenerConexion())
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO usuario (NOMBRE_USUARIO, CONTRASENA) 
                        VALUES (:nombreUsuario, :contrasena)";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":nombreUsuario", OracleDbType.Varchar2)).Value = nombreUsuario;
                        command.Parameters.Add(new OracleParameter(":contrasena", OracleDbType.Varchar2)).Value = contrasena;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar usuario: {ex.Message}");
                throw;
            }
        }

        // Método para obtener todos los usuarios
        public DataTable ObtenerUsuarios()
        {
            var dataTable = new DataTable();

            try
            {
                using (var connection = Conexion.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT * FROM usuario";

                    using (var command = new OracleCommand(query, connection))
                    using (var adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
            }

            return dataTable;
        }

        // Método para actualizar un usuario
        public void ActualizarUsuario(string nombreUsuario, string nuevaContrasena)
        {
            try
            {
                using (var connection = Conexion.ObtenerConexion())
                {
                    connection.Open();
                    string query = @"
                        UPDATE usuario 
                        SET CONTRASENA = :nuevaContrasena 
                        WHERE NOMBRE_USUARIO = :nombreUsuario";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":nuevaContrasena", OracleDbType.Varchar2)).Value = nuevaContrasena;
                        command.Parameters.Add(new OracleParameter(":nombreUsuario", OracleDbType.Varchar2)).Value = nombreUsuario;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar usuario: {ex.Message}");
                throw;
            }
        }

        // Método para eliminar un usuario
        public void EliminarUsuario(string nombreUsuario)
        {
            try
            {
                using (var connection = Conexion.ObtenerConexion())
                {
                    connection.Open();
                    string query = @"
                        DELETE FROM usuario 
                        WHERE NOMBRE_USUARIO = :nombreUsuario";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":nombreUsuario", OracleDbType.Varchar2)).Value = nombreUsuario;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}");
                throw;
            }
        }
    }
}
