using TemplateDDD.Domain.Interfaces.Infra;
using TemplateDDD.Domain.Models;
using System;
using Dapper;
using System.Data;
using System.Linq;

namespace TemplateDDD.Infra.Repositories
{
    public partial class SampleRepository : BaseRepository, ISampleRepository
    {
        public Sample GetById(int id)
        {
            return _conn.Query<Sample>(QuerySelectById, new { Id = id }).FirstOrDefault();
        }

        public int Insert(Sample model)
        {
            IDbTransaction trans = _conn.BeginTransaction();
            try
            {
                var id = _conn.Query<int>(QueryInsert, model, trans).Single();

                trans.Commit();

                return id;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }

        public bool Update(Sample model)
        {
            IDbTransaction trans = _conn.BeginTransaction();
            try
            {
                _conn.Query(QueryUpdate, model, trans);

                trans.Commit();

                return true;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }
        public bool Delete(int id)
        {
            IDbTransaction trans = _conn.BeginTransaction();
            try
            {
                _conn.Query(QueryUpdate, new { Id = id }, trans);

                trans.Commit();

                return true;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }
        
    }
}
