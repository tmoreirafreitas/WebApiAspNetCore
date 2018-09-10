using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Linq;

namespace Sge.Service.Service
{
    public class TurmaService : Service<Turma, TurmaValidator>, ITurmaService
    {
        private readonly ITurmaRepository _repository;
        public TurmaService(ITurmaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Turma GetByCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                throw new ArgumentException("The codigo can't be empty or null.");

            return _repository.GetByExpression(t => t.Codigo.Equals(codigo)).FirstOrDefault();
        }
    }
}
