using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Linq;

namespace Sge.Service.Service
{
    public class ProfessorService : Service<Professor, ProfessorValidator>, IProfessorService
    {
        private readonly IProfessorRepository _repository;
        public ProfessorService(IProfessorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Professor GetByCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException("o cpf não pode ser vazio ou nulo.");

            return _repository.GetByExpression(p => p.Cpf.Equals(cpf)).FirstOrDefault();
        }

        public Professor GetByMatricula(string matricula)
        {
            if (string.IsNullOrEmpty(matricula))
                throw new ArgumentException("A matricula não pode ser vazia ou nula.");

            return _repository.GetByExpression(p => p.Matricula.Equals(matricula)).FirstOrDefault();
        }
    }
}
