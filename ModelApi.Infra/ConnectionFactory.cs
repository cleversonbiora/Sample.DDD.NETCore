using ModelApi.CrossCutting;
using System.Data.Common;
using System.Data.SqlClient;

namespace ModelApi.Infra
{
    public class ConnectionFactory
    {
        public static DbConnection GetModelApiOpenConnection()
        {
            var connection = new SqlConnection(ConnectionStrings.ModelApiConnection);

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            return connection;
        }
    }
}
