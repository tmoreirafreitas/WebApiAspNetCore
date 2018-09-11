using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;

namespace SGE.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SgeContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(SgeContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj).State = EntityState.Modified;           
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
