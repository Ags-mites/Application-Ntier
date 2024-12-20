using Oracle.ManagedDataAccess.Client;
using PersistenceLayer.ClientesyCiudad;
using System;
using System.Collections.Generic;

namespace PersistenceLayer.ClientesyCiudad
{
    public static class RegistrarLog
    {
        public static void GuardarLog(string actividad)
        {
            try
            {
                using (var connection = Conexion.ObtenerConexion())
                {
                    connection.Open();
                    string query = "INSERT INTO Log_JDVR (ACTIVIDAD_JDVR, FECHA_JDVR, HORA_JDVR) " +
                                   "VALUES (:actividad, :fecha, :hora)";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("actividad", actividad));
                        command.Parameters.Add(new OracleParameter("fecha", DateTime.Now.Date));
                        command.Parameters.Add(new OracleParameter("hora", DateTime.Now.ToString("HH:mm")));

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Error al registrar log: {ex.Message}");
            }
        }
    }
}
