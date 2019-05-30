using TemplateDDD.CrossCutting;
using System.Data.Common;
using System.Data.SqlClient;

namespace TemplateDDD.Infra
{
    public class ConnectionFactory
    {
        public static DbConnection GetTemplateDDDOpenConnection()
        {
            var connection = new SqlConnection(ConnectionStrings.TemplateDDDConnection);

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public static DbConnection GetTemplateDDDConnection()
        {
            var connection = new SqlConnection(ConnectionStrings.TemplateDDDConnection);

            return connection;
        }

    }
}
