using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Delete(int IdProfessor, int IdEscola)
        {
            if (IdProfessor == 0)
                throw new ArgumentException("O IdProfessor não pode ser zero.");

            if (IdEscola == 0)
                throw new ArgumentException("O IdEscola não pode ser zero.");

            _repository.Delete(peDel => peDel.IdEscola.Equals(IdEscola) && peDel.IdProfessor.Equals(IdProfessor));
        }

        public IQueryable<ProfessorEscola> GetByDate(DateTime date)
        {
            if (date == null)
                throw new ArgumentException("A data não pode ser nula.");

            return _repository.GetByExpression(t => t.Adimissao.Value.Day.Equals(date.Day)
            && t.Adimissao.Value.Month.Equals(date.Month)
            && t.Adimissao.Value.Year.Equals(date.Year));
        }

        public ProfessorEscola GetByIds(int IdProfessor, int IdEscola)
        {
            return _repository.GetByExpression(pe => pe.IdProfessor.Equals(IdProfessor)
            && pe.IdEscola.Equals(IdEscola)).FirstOrDefault();
        }
    }
}
