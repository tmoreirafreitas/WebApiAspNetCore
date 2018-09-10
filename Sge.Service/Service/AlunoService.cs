using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Sge.Service.Validators;
using Sge.Service.Interfaces;

namespace Sge.Service.Service
{
    public class AlunoService : Service<Aluno, AlunoValidator>, IAlunoService
    {
        private readonly IAlunoRepository _repository;
        public AlunoService(IAlunoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Aluno Get(string matricula)
        {
            if (string.IsNullOrEmpty(matricula))
                throw new ArgumentException("The matricula can't be empty or null.");

            return _repository.GetByExpression(a => a.Matricula.Equals(matricula)).FirstOrDefault();
        }

        public IEnumerable<Aluno> GetByName(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("The nome can't be empty or null.");

            return _repository.GetByExpression(a => a.Nome.Contains(nome));
        }
    }
}
