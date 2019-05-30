using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TemplateDDD.Infra
{
    public class ConnectionManager : IDisposable
    {
        public IDbConnection conn;
        public IDbTransaction trans;

        public ConnectionManager()
        {
            conn = ConnectionFactory.GetTemplateDDDOpenConnection();
        }

        public void BeginTransaction()
        {
            trans = conn.BeginTransaction();
        }

        public void Rollback()
        {
            trans.Rollback();
        }

        public void Commit()
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
                conn.Dispose();
                conn = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
