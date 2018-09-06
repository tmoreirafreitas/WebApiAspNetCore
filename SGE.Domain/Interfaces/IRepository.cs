using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void Delete(int id);
    }
}
