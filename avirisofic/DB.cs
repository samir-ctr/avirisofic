using Microsoft.Data.SqlClient;

public class DB
{
    public class DB_context()
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "(localdb)\\MSSQLLocalDB";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
