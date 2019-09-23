using System;
using System.Data;

namespace TemplateDDD.Infra.Repositories
{
    public class BaseRepository
    {
        public IDbConnection _conn { get { return _connectionManager.conn.Value; } }
        public IDbTransaction _trans { get { return _connectionManager.trans; } }
        internal ConnectionManager _connectionManager;

        public BaseRepository(ConnectionManager connectionManager) =>_connectionManager = connectionManager;

        public void BeginTransaction() => _connectionManager.BeginTransaction();

        public void Rollback() => _connectionManager.Rollback();

        public void Commit() => _connectionManager.Commit();
    }
}
