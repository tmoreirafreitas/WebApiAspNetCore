using FluentValidation;
using SGE.Domain.Interfaces;
using SGE.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new ArgumentException("O id não pode ser zero.");

            _repository.Delete(id);
        }

        public async Task<TEntity> Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return await _repository.GetById(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _repository.GetAll();
        }

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
