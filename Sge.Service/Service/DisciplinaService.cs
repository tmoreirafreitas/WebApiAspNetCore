using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Linq;

namespace Sge.Service.Service
{
    public class DisciplinaService : Service<Disciplina, DisciplinaValidator>, IDisciplinaService
    {
        private readonly IDisciplinaRepository _repository;
        public DisciplinaService(IDisciplinaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Disciplina GetByCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                throw new ArgumentException("O codigo não pode ser vazio ou nulo.");

            return _repository.GetByExpression(d => d.Codigo.Equals(codigo)).FirstOrDefault();
        }
    }
}
