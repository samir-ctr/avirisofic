using Microsoft.Data.SqlClient;

internal static class DB_contextHelpers
{
    public static SqlConnection GetConnection()
    {
        string connectionString = "Data (localdb)\\MSSQLLocalDB;Initial Catalog=TurismoAvesDB3;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }
}