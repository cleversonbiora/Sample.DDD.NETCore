using System;
using System.Data;

namespace TemplateDDD.Infra.Repositories
{
    public class BaseRepository : IDisposable
    {
        internal IDbConnection _conn;
        public BaseRepository()
        {
            _conn = ConnectionFactory.GetTemplateDDDOpenConnection();
        }
        public void Dispose()
        {
            _conn.Close();
            GC.SuppressFinalize(this);
        }
    }
}
