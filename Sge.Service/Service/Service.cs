using FluentValidation;
using SGE.Domain.Interfaces;
using SGE.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sge.Service.Service
{
    public class Service<TEntity, VEntity> : IService<TEntity, VEntity> where TEntity : class where VEntity : AbstractValidator<TEntity>
    {
        private readonly IRepository<TEntity> _repository;
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            _repository.Delete(id);
        }

        public TEntity Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _repository.GetAll();
        }

        //public TEntity Post<V>(TEntity obj) where V : AbstractValidator<TEntity>
        //{
        //    Validate(obj, Activator.CreateInstance<V>());
        //    _repository.Add(obj);
        //    return obj;
        //}

        //public TEntity Put<V>(TEntity obj) where V : AbstractValidator<TEntity>
        //{
        //    Validate(obj, Activator.CreateInstance<V>());

        //    _repository.Update(obj);
        //    return obj;
        //}

        public TEntity Post(TEntity obj)
        {
            Validate(obj, Activator.CreateInstance<VEntity>());
            _repository.Add(obj);
            return obj;
        }        

        public TEntity Put(TEntity obj)
        {
            Validate(obj, Activator.CreateInstance<VEntity>());

            _repository.Update(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
