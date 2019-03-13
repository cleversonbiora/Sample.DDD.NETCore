using System;
using System.Data;

namespace ModelApi.Infra.Repositories
{
    public class BaseRepository : IDisposable
    {
        internal IDbConnection _conn;
        public BaseRepository()
        {
            _conn = ConnectionFactory.GetModelApiOpenConnection();
        }
        public void Dispose()
        {
            _conn.Close();
            GC.SuppressFinalize(this);
        }
    }
}
