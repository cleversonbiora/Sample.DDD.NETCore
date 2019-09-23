using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TemplateDDD.Infra
{
    public class ConnectionManager : IDisposable
    {
        public Lazy<IDbConnection> conn;
        public IDbTransaction trans;
        public ConnType type;

        public ConnectionManager()
        {
            conn = new Lazy<IDbConnection>(() => ConnectionFactory.GetTemplateDDDOpenConnection());
            type = ConnType.Single;
        }

        public void BeginMultiTransaction()
        {
            type = ConnType.Multiple;
            if (trans == null || trans.Connection == null)
                trans = conn.Value.BeginTransaction();
        }

        internal void BeginTransaction()
        {
            if(trans == null || trans.Connection == null)
                trans = conn.Value.BeginTransaction();
        }

        public void Rollback()
        {
            trans.Rollback();
        }

        public void CommitAll()
        {
            try
            {
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                trans = null;
            }
        }

        internal void Commit()
        {
            if (type == ConnType.Multiple)
                return;
            try
            {
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                trans = null;
                //_trans = _conn.BeginTransaction();
            }
        }

        public void Dispose()
        {
            if (trans != null)
            {
                trans.Dispose();
                trans = null;
            }

            if (conn != null)
            {
                conn.Value.Dispose();
                conn = null;
            }
            GC.SuppressFinalize(this);
        }

        public enum ConnType {
            Single,
            Multiple
        }

    }
}
