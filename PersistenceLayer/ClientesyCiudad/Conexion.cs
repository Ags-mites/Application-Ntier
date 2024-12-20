using Oracle.ManagedDataAccess.Client;

public static class Conexion
{
    private static readonly string connectionString = "User Id=JEREMMY;Password=root;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)))";

    public static OracleConnection ObtenerConexion()
    {
        var connection = new OracleConnection(connectionString);
        return connection; // Devuelve una conexión nueva y cerrada
    }
}
