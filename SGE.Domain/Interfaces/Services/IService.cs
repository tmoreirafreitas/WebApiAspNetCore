using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SGE.Domain.Interfaces.Services
{
    public interface IService<TEntity, VEntity> where TEntity : class where VEntity : AbstractValidator<TEntity>
    {
        //TEntity Post<V>(TEntity obj) where V : AbstractValidator<TEntity>;
        //TEntity Put<V>(TEntity obj) where V : AbstractValidator<TEntity>;

        TEntity Post(TEntity obj);
        TEntity Put(TEntity obj);

        void Delete(int id);

        Task<TEntity> Get(int id);

        IQueryable<TEntity> Get();
    }
}
