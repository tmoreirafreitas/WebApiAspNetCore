using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sge.Service.Service
{
    public class TurmaDisciplinaService : Service<TurmaDisciplina, TurmaDisciplinaValidator>, ITurmaDisciplinaService
    {
        private readonly ITurmaDisciplinaRepository _repository;
        public TurmaDisciplinaService(ITurmaDisciplinaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public void Delete(int idTurma, int idDisciplina)
        {
            if (idTurma == 0)
                throw new ArgumentException("O idTurma não pode ser zero.");

            if (idDisciplina == 0)
                throw new ArgumentException("O idDisciplina não pode ser zero.");

            _repository.Delete(peDel => peDel.IdTurma.Equals(idTurma) && peDel.IdDisciplina.Equals(idDisciplina));
        }

        public IQueryable<TurmaDisciplina> GetBetweenDates(DateTime dateStart, DateTime dateEnd)
        {
            if (dateStart == null)
                throw new ArgumentException("A dateStart não pode ser nula.");

            if (dateEnd == null)
                throw new ArgumentException("A dateEnd não pode ser nula.");

            return _repository.GetByExpression(td => (td.DataInicio.Year >= (dateStart.Year)
            && td.DataInicio.Month >= (dateStart.Month)
            && td.DataInicio.Day >= (dateStart.Day))
            && (td.DataTermino.Year <= dateEnd.Year
            && td.DataTermino.Month <= dateEnd.Month
            && td.DataTermino.Day <= dateEnd.Day));
        }

        public IQueryable<TurmaDisciplina> GetByDateEnd(DateTime dateEnd)
        {
            if (dateEnd == null)
                throw new ArgumentException("A dateEnd não pode ser nula.");

            return _repository.GetByExpression(td => td.DataTermino.Year.Equals(dateEnd.Year)
            && td.DataTermino.Month.Equals(dateEnd.Month)
            && td.DataTermino.Day.Equals(dateEnd.Day));
        }

        public IQueryable<TurmaDisciplina> GetByDateStart(DateTime dateStart)
        {
            if (dateStart == null)
                throw new ArgumentException("A dateStart não pode ser nula.");

            return _repository.GetByExpression(td => td.DataInicio.Year.Equals(dateStart.Year)
            && td.DataInicio.Month.Equals(dateStart.Month)
            && td.DataInicio.Day.Equals(dateStart.Day));
        }

        public TurmaDisciplina GetByIds(int idTurma, int idDisciplina)
        {
            if (idTurma == 0)
                throw new ArgumentException("A idTurma não pode ser zero.");

            if (idDisciplina == 0)
                throw new ArgumentException("A idDisciplina não pode ser zero.");

            return _repository.GetByExpression(td => td.IdTurma.Equals(idTurma) && td.IdDisciplina.Equals(idDisciplina)).FirstOrDefault();
        }

        public IQueryable<TurmaDisciplina> GetByIdTurma(int idTurma)
        {
            if (idTurma == 0)
                throw new ArgumentException("A idTurma não pode ser zero.");

            return _repository.GetByExpression(td => td.IdTurma.Equals(idTurma));
        }
    }
}