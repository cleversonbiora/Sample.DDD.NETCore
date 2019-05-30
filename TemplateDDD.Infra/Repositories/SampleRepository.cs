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
        public SampleRepository(ConnectionManager connectionManager) : base(connectionManager) { }

        public Sample GetById(int id)
        {
            return _conn.Query<Sample>(QuerySelectById, new { Id = id }).FirstOrDefault();
        }

        public int Insert(Sample model)
        {
            try
            {
                BeginTransaction();
                var id = _conn.Query<int>(QueryInsert, model, _trans).Single(); //All queries are stored on partial class.
                Commit();
                return id;
            }
            catch (Exception)
            {
                Rollback();
                throw; //Always propagate the Exception!
            }
        }

        public bool Update(Sample model)
        {
            try
            {
                BeginTransaction();
                _conn.Query(QueryUpdate, model, _trans);
                Commit();
                return true;
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                BeginTransaction();
                _conn.Query(QueryUpdate, new { Id = id }, _trans);
                Commit();
                return true;
            }
            catch (Exception)
            {
                Rollback();
                throw; 
            }
        }
        
    }
}
