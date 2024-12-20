using Oracle.ManagedDataAccess.Client;
using PersistenceLayer;
using ResourceLayer;

public class EmpleadoRepository
{
    private readonly string _connectionString;

    public EmpleadoRepository()
    {
        _connectionString = DatabaseConfig.GetConnectionString();
    }

    public void Create(Empleados empleado)
    {
        try
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO EMPLEADO (CEDULA, NOMBRE, FECHA_INGRESO, SUELDO) " +
                               "VALUES (:cedula, :nombre, :fecha_ingreso, :sueldo)";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("cedula", empleado.cedula));
                    command.Parameters.Add(new OracleParameter("nombre", empleado.nombre));
                    command.Parameters.Add(new OracleParameter("fecha_ingreso", empleado.fecha_ingreso));
                    command.Parameters.Add(new OracleParameter("sueldo", empleado.sueldo));

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (OracleException ex)
        {
            Console.WriteLine($"Error de Oracle: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error general: {ex.Message}");
            throw;
        }
    }

    public void Update(Empleados empleado)
    {
        try
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                string query = @"UPDATE empleado
                             SET cedula = :cedula,
                                 nombre = :nombre,
                                 fecha_ingreso = :fecha_ingreso,
                                 sueldo = :sueldo
                             WHERE id = :id";

                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("cedula", empleado.cedula));
                    command.Parameters.Add(new OracleParameter("nombre", empleado.nombre));
                    command.Parameters.Add(new OracleParameter("fecha_ingreso", empleado.fecha_ingreso));
                    command.Parameters.Add(new OracleParameter("sueldo", empleado.sueldo));
                    command.Parameters.Add(new OracleParameter("id", empleado.id));

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (OracleException ex)
        {
            Console.WriteLine($"Error de Oracle: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error general: {ex.Message}");
            throw;
        }
    }

    public List<Empleados> GetAll()
    {
        try
        {
            var empleados = new List<Empleados>();
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT id, cedula, nombre, fecha_ingreso, sueldo FROM empleado";

                using (var command = new OracleCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var empleado = new Empleados
                        {
                            id = reader.GetInt32(0),
                            cedula = reader.GetString(1),
                            nombre = reader.GetString(2),
                            fecha_ingreso = reader.GetDateTime(3),
                            sueldo = reader.GetDecimal(4)
                        };

                        empleados.Add(empleado);
                    }
                }
            }
            return empleados;
        }
        catch (OracleException ex)
        {
            Console.WriteLine($"Error de Oracle: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error general: {ex.Message}");
            throw;
        }
    }
    public void Delete(int id)
    {
        try
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM empleado WHERE id = :id";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("id", id));
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (OracleException ex)
        {
            Console.WriteLine($"Error de Oracle: {ex.Message}");
            throw;
        }
    }
    public List<Empleados> Search(string keyword)
    {
        try
        {
            var accountTypes = new List<Empleados>();
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT id, cedula, nombre, FECHA_INGRESO, sueldo " +
                               "FROM empleado WHERE nombre LIKE :keyword OR cedula LIKE :keyword";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("keyword", $"%{keyword}%"));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accountTypes.Add(new Empleados
                            {
                                id = reader.GetInt32(0),
                                cedula = reader.GetString(1),
                                nombre = reader.GetString(2),
                                fecha_ingreso = reader.GetDateTime(3),
                                sueldo = reader.GetDecimal(4),
                            });
                        }
                    }
                }
            }
            return accountTypes;
        }
        catch (OracleException ex)
        {
            Console.WriteLine($"Error de Oracle: {ex.Message}");
            throw;
        }
    }

}
