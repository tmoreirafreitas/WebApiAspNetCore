using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sge.Service.Service
{
    public class TrabalhaService : Service<Trabalha, TrabalhaValidator>, ITrabalhaService
    {
        private readonly ITrabalhaRepository _repository;
        public TrabalhaService(ITrabalhaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Trabalha> GetByDate(DateTime date)
        {
            if (date == null)
                throw new ArgumentException("The date can't be null.");

            return _repository.GetByExpression(t => t.Adimissao.Value.Day.Equals(date.Day)
            && t.Adimissao.Value.Month.Equals(date.Month)
            && t.Adimissao.Value.Year.Equals(date.Year));
        }
    }
}
