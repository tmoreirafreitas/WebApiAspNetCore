using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void Delete(int id);
        void Delete(Expression<Func<TEntity, bool>> predicate);
    }
}
