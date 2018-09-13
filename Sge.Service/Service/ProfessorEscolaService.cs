using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sge.Service.Service
{
    public class ProfessorEscolaService : Service<ProfessorEscola, ProfessorEscolaValidator>, IProfessorEscolaService
    {
        private readonly IProfessorEscolaRepository _repository;
        public ProfessorEscolaService(IProfessorEscolaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProfessorEscola> GetByDate(DateTime date)
        {
            if (date == null)
                throw new ArgumentException("A data não pode ser nula.");

            return _repository.GetByExpression(t => t.Adimissao.Value.Day.Equals(date.Day)
            && t.Adimissao.Value.Month.Equals(date.Month)
            && t.Adimissao.Value.Year.Equals(date.Year));
        }
    }
}
