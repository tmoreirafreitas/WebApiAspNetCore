using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Collections.Generic;
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

        public IEnumerable<TurmaDisciplina> GetBetweenDates(DateTime dateStart, DateTime dateEnd)
        {
            if (dateStart == null)
                throw new ArgumentException("The dateStart can't be null.");

            if (dateEnd == null)
                throw new ArgumentException("The dateEnd can't be null.");

            return _repository.GetByExpression(td => (td.DataInicio.Year >= (dateStart.Year)
            && td.DataInicio.Month >= (dateStart.Month)
            && td.DataInicio.Day >= (dateStart.Day))
            && (td.DataTermino.Year <= dateEnd.Year
            && td.DataTermino.Month <= dateEnd.Month
            && td.DataTermino.Day <= dateEnd.Day));
        }

        public IEnumerable<TurmaDisciplina> GetByDateEnd(DateTime dateEnd)
        {
            if (dateEnd == null)
                throw new ArgumentException("The dateEnd can't be null.");

            return _repository.GetByExpression(td => td.DataTermino.Year.Equals(dateEnd.Year)
            && td.DataTermino.Month.Equals(dateEnd.Month)
            && td.DataTermino.Day.Equals(dateEnd.Day));
        }

        public IEnumerable<TurmaDisciplina> GetByDateStart(DateTime dateStart)
        {
            if (dateStart == null)
                throw new ArgumentException("The dateStart can't be null.");

            return _repository.GetByExpression(td => td.DataInicio.Year.Equals(dateStart.Year)
            && td.DataInicio.Month.Equals(dateStart.Month)
            && td.DataInicio.Day.Equals(dateStart.Day));
        }
    }
}